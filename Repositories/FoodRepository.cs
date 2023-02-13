using ModernWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Repositories
{
    internal class FoodRepository : RepositoryBase, IFoodRepository
    {
        private static List<FoodProvider> _foodProviders = new List<FoodProvider>();

        public FoodRepository()
        {
            InitData();
        }

        public IEnumerable<FoodProvider> GetFoodProviders()
        {
            return _foodProviders;
        }

        public static void InitData()
        {
            AddPizzaHut();
            AddMcDonalds();
            AddBurgerKing();
            AddKFC();
        }

        private static void AddKFC()
        {
            FoodProvider kfc = new FoodProvider("KFC");
            kfc.AddToMenu("Hamburger", 5);
            kfc.AddToMenu("Chicken Wings", 4);
            kfc.AddToMenu("Salad", 5);
            _foodProviders.Add(kfc);
        }

        private static void AddBurgerKing()
        {
            FoodProvider burgerKing = new FoodProvider("Burger King");
            burgerKing.AddToMenu("Hamburger", 4);
            burgerKing.AddToMenu("Spaghetti", 8);
            burgerKing.AddToMenu("Chicken Wings", 5);
            burgerKing.AddToMenu("Salad", 5);
            _foodProviders.Add(burgerKing);
        }

        private static void AddMcDonalds()
        {
            FoodProvider mcDonalds = new FoodProvider("McDonalds");
            mcDonalds.AddToMenu("Hamburger", 2);
            mcDonalds.AddToMenu("Salad", 3);
            _foodProviders.Add(mcDonalds);
        }

        private static void AddPizzaHut()
        {
            FoodProvider pizzaHut = new FoodProvider("Pizza Hut");
            pizzaHut.AddToMenu("Pizza", 15);
            pizzaHut.AddToMenu("Hamburger", 6);
            pizzaHut.AddToMenu("Spaghetti", 8);
            pizzaHut.AddToMenu("Chicken Wings", 6);
            pizzaHut.AddToMenu("Salad", 4);
            _foodProviders.Add(pizzaHut);
        }
    }
}
