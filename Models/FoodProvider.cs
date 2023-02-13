using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Models
{
    public class FoodProvider
    {
        public string Name { get; set; }
        public List<MenuItem> Menu { get; set; }

        public FoodProvider(string name)
        {
            this.Name = name;
            this.Menu = new List<MenuItem>();
        }

        public void AddToMenu(string food, decimal price)
        {
            if (!Menu.Any(x => string.Compare(x.Food, food, true) == 0))
            {
                Menu.Add(new MenuItem() { Food = food, Price = price });
            }
        }
    }
}
