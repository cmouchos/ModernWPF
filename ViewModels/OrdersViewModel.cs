using ModernWPF.Models;
using ModernWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernWPF.ViewModels
{
    public class OrdersViewModel: ViewModelBase
    {
        private IOrderRepository orderRepository;
        private const string lowAmountPlaceholder = "";
        private const string highAmountPlaceholder = "";
        private ObservableCollection<Order> orders;

        private string highAmountStr;
        private string lowAmountStr;

        public string HighAmountStr { get => highAmountStr;
            set { highAmountStr = value; 
                OnPropertyChanged(nameof(HighAmountStr)); 
            }
        }
        public string LowAmountStr { get => lowAmountStr;
            set
            {
                lowAmountStr = value;
                OnPropertyChanged(nameof(LowAmountStr));
            }
        }

        public ObservableCollection<Order> Orders { get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
                OnPropertyChanged(nameof(Total));
            }
        }

        public string Total
        {
            get
            {
                decimal sum =0;
                foreach(var item in Orders)
                {
                    sum += item.MenuItem.Price;
                }
                return sum.ToString();
            }
        }

        public OrdersViewModel()
        {
            ClearSearchFields();
            orderRepository = new OrderRepository();
            Orders = new ObservableCollection<Order>(orderRepository.GetAllOrders());
            ClearCommand = new RelayCommand(ExecuteClearFilterCommand);
            SearchCommand = new RelayCommand(ExecuteSearchCommand);
        }

        private void ClearSearchFields()
        {
            LowAmountStr = lowAmountPlaceholder;
            HighAmountStr = highAmountPlaceholder;
        }

        private bool CanExecuteSearchCommand(object obj)
        {
            if (string.IsNullOrEmpty(HighAmountStr) || string.IsNullOrEmpty(LowAmountStr))
                return false;
            return true;
        }

        private void ExecuteSearchCommand(object obj)
        {
            decimal lowAmt = 0;
            decimal highAmt = 0;
            if (decimal.TryParse(HighAmountStr, out highAmt) && decimal.TryParse(LowAmountStr, out lowAmt))
            {
                Orders = new ObservableCollection<Order>(orderRepository.GetOrdersByRange(lowAmt, highAmt));
            }
        }

        private void ExecuteClearFilterCommand(object obj)
        {
            ClearSearchFields();
            Orders = new ObservableCollection<Order>(orderRepository.GetAllOrders());
        }

        public ICommand ClearCommand { get; }

        public ICommand SearchCommand { get; }
    }
}
