using ModernWPF.Models;
using ModernWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        private ObservableCollection<UserModel> _userCollection;
        private IUserRepository userRepository;

        public ObservableCollection<UserModel> UserCollection { 
            get => _userCollection;
            set
            {
                _userCollection = value;
                OnPropertyChanged(nameof(UserCollection));
            }
        }

        public HomeViewModel()
        {
            userRepository = new UserRepository();
            //Retrieve the users from the database 
            var userList = userRepository.GetAllUsers();
            UserCollection = new ObservableCollection<UserModel>(userList);
        }
    }
}
