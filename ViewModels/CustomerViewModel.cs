using ModernWPF.Models;
using ModernWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernWPF.ViewModels
{
    public class CustomerViewModel: ViewModelBase
    {
        private IFoodRepository foodRepository;
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;

        private ObservableCollection<FoodProvider> _foodProviders;
        private FoodProvider _selectedFoodProvider;
        private ObservableCollection<MenuItem> _menu;
        private MenuItem _selectedMenuItem;

        public ObservableCollection<FoodProvider> FoodProviders { 
            get => _foodProviders; 
            set
            {
                _foodProviders = value;
                OnPropertyChanged(nameof(FoodProviders));
            }
        }

        public FoodProvider SelectedFoodProvider
        {
            get
            {
                return _selectedFoodProvider;
            }
            set
            {
                _selectedFoodProvider = value;
                OnPropertyChanged(nameof(SelectedFoodProvider));
                OnPropertyChanged(nameof(Menu));
            }
        }

        public ObservableCollection<MenuItem> Menu
        {
            get
            {
                if (this.SelectedFoodProvider == null)
                    return null;
                _menu.Clear();
                foreach (MenuItem item in this.SelectedFoodProvider.Menu)
                {
                    _menu.Add(item);
                }
                return _menu;
            }
            private set
            {
                _menu = value;
                OnPropertyChanged(nameof(Menu));
            }
        }

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged(nameof(SelectedMenuItem));
            }
        }

        public CustomerViewModel()
        {
            foodRepository = new FoodRepository();
            orderRepository = new OrderRepository();
            userRepository = new UserRepository();
            FoodProviders = new ObservableCollection<FoodProvider>(foodRepository.GetFoodProviders());
            this.Menu = new ObservableCollection<MenuItem>();
            PlaceOrderCommand = new RelayCommand(ExecutePlaceOrderCommand, CanExecutePlaceOrderCommand);
        }

        private bool CanExecutePlaceOrderCommand(object obj)
        {
            if (SelectedFoodProvider != null && SelectedMenuItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecutePlaceOrderCommand(object obj)
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            Order newOrder = new Order()
            {
                FirstName = user.Name,
                Surname = user.LastName,
                MenuItem = SelectedMenuItem,
                FoodProvider = SelectedFoodProvider,
            };
            orderRepository.Add(newOrder);
        }

        //Commands 
        public ICommand PlaceOrderCommand { get; }
    }
}
