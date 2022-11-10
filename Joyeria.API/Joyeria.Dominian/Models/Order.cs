using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.Core.Models
{
    public class Order

    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public decimal Total { get; set; }

        public virtual List<OrderItem> detalle { get; set; }

    }
}
