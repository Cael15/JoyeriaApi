using System;
using System.ComponentModel.DataAnnotations;
namespace Joyeria.APIs.ViewModels
{
    public class OrderItemVM
    {
        public Guid Id { get; set; }
        [Required] 
        public int Amount { get; set; }
        [Required] 
        public decimal Price { get; set; }
        [Required] 
        public decimal TotalAmount { get; set; }
        [Required] 
        public Guid ProductId { get; set; }
        [Required] 
        public Guid OrderId { get; set; }
    }
}
