using Joyeria.Core.Models;
using Joyeria.Core.Report;
using Joyeria.Core.Repositories;
using Joyeria.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joyeria.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public OrderRepository(JoyeriaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Order> CreateAsync(Order orderToCreate)
        {
            await _dbContext.Orders.AddAsync(orderToCreate);
            return orderToCreate;
        }


        Task IOrderRepository.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrdeByIdAsync(Guid id)
        {
            //var order = await _dbContext.Orders.FindAsync(id);
            //return order;
            return await this._dbContext.Orders.Include(det => det.detalle).Where(sql=>sql.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await this._dbContext.Orders.Include(det => det.detalle).ToListAsync();
           // return await this._dbContext.Orders.Include<OrderItem>
        }

         Task<Order> IOrderRepository.UpdateAsync(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReporteVentas>> GetResumen()
        {
            return await (from cab in  this._dbContext.Orders
                     join usuario in this._dbContext.Users
                     on cab.UserId equals usuario.Id
                     group new {cab,usuario} by new {mes=cab.Date.Month,name=usuario.Name,usuario.LastName   } into gr
                     select new ReporteVentas { cliente=gr.Key.name +"- "+gr.Key.LastName,mes= gr.Key.mes.ToString()
                     ,total=gr.Sum(ord=>ord.cab.Total)}).ToListAsync();
            
        }
        private string obtenerMes(int idMes)
        {
            switch (idMes)
            {
                case 1:
                    return "Enero";
                   
                default:
                    break;
            }
            return "";
        }
    }
}
