using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.APIs.ViewModels
{
    public class OrderVM
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public decimal Total { get; set; }

        public List<OrderItemVM> detalle { get; set; }


    }
}