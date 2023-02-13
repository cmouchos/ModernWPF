using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.Models
{
    public interface IOrderRepository
    {
        void Add(Order order);

        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrdersByRange(decimal lowAmt, decimal highAmt);
    }
}
