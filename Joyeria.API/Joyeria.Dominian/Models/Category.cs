using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joyeria.Core.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
