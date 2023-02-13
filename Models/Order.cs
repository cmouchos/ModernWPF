using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Models
{
    public class Order
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public FoodProvider FoodProvider { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
