using Joyeria.Core.Models;
using Joyeria.Core.Report;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Core.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrdeByIdAsync(Guid id);
        Task<Order> UpdateAsync(Order orderToUpdate);
        Task<Order> CreateAsync(Order orderToCreate);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ReporteVentas>> GetResumen();
    }
}


