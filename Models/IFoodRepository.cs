using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Models
{
    public interface IFoodRepository
    {
        IEnumerable<FoodProvider> GetFoodProviders();
    }
}
