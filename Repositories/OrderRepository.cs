using ModernWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Repositories
{
    internal class OrderRepository : RepositoryBase, IOrderRepository
    {
        public static List<Order> Orders = new List<Order>();

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Orders;
        }

        public IEnumerable<Order> GetOrdersByRange(decimal lowAmt, decimal highAmt)
        {
            return Orders.Where(x=> x.MenuItem.Price >= lowAmt && x.MenuItem.Price <= highAmt);
        }
    }
}
