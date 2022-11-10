using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.Core.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        [Column("Category_id")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
