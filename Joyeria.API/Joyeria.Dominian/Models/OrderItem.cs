using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.Core.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

    }
}