using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using AvaloniaClientMVVM.Models;

namespace AvaloniaClientMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private User _user;
        private Role _role;
        private ObservableCollection<User> _users;
        private ObservableCollection<Role> _roles;
        public User User
        {
            get => _user;
            set
            {
                if (value != _user)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }
        
        public Role Role
        {
            get => _role;
            set
            {
                if (value != _role)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                if (value != _users)
                {
                    _users = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Role> Roles
        {
            get => _roles;
            set
            {
                if (value != _roles)
                {
                    _roles = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainWindowViewModel()
        {
            _users = new ObservableCollection<User>
            {
                new User{Id = 1, CreationDate = DateTime.Now, Name = "Владимир", Surname = "Бурбах"},
                new User{Id = 2, CreationDate = DateTime.Now, Name = "Андрей", Surname = "Бурбах"},
                new User{Id = 3, CreationDate = DateTime.Now, Name = "Ксения", Surname = "Алексеева"}
            };
            _roles = new ObservableCollection<Role>
            {
                new Role { Id = 1, CreationDate = DateTime.Now, RoleName = "Администратор" },
                new Role { Id = 2, CreationDate = DateTime.Now, RoleName = "Пользователь" },
            };
        }

    }
}