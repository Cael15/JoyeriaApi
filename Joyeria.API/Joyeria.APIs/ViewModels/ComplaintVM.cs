using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Joyeria.APIs.ViewModels
{
    public class ComplaintVM
    {
        public int Id { get; set; }
      
        public DateTime Datec { get; set; }
        
        public string Name { get; set; }
       
        public string Address { get; set; }
      
        public string Ndoc { get; set; }
        
        public string Email { get; set; }
       
        public string Cellphone { get; set; }
        
        public string Repre { get; set; }
       
        public string Typep { get; set; }
        public string Price { get; set; }
     
        public string Descp { get; set; }
      
        public string Typc { get; set; }
      
        public string Descc { get; set; }
      
        public string Pedic { get; set; }
        
        public int StatusC { get; set; }
    }
}
