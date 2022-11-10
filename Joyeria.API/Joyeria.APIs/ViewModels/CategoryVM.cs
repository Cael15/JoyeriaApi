using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Joyeria.APIs.ViewModels
{
    
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
