using Joyeria.Core;
using Joyeria.Core.Models;
using Joyeria.Core.Report;
using Joyeria.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Services.Services
{
    public class OrderService : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateAsync(Order orderToCreate)
        {
            await _unitOfWork.Orders.CreateAsync(orderToCreate);
            await _unitOfWork.SaveChangesAsync();

            return orderToCreate;
        }

        Task IOrderService.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrdeByIdAsync(Guid id)
        {
            return await _unitOfWork.Orders.GetOrdeByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await this._unitOfWork.Orders.GetOrdersAsync();
        }

        Task<Order> IOrderService.UpdateAsync(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<ReporteVentas>> GetResumen()
        {
           
                return await _unitOfWork.Orders.GetResumen();
            }
        }
    }

