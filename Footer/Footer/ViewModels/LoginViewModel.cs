using System;
using System.Diagnostics;
using System.Windows.Input;
using Footer.Interfaces;
using Footer.Models;
using Footer.Views;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Footer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool _isloginvisible = true;
        private bool _isregvisible = false;
        private bool _isrecoveryvisible = false;

        public IUser User;

        public LoginViewModel()
        {
            
        }

        
        public bool IsLoginVisible
        {
            get => _isloginvisible;
            set
            {
                if (_isloginvisible != value)
                {
                    _isloginvisible = value;
                    OnPropertyChanged(nameof(IsLoginVisible));
                }
            }
        }

        public bool IsRegisterVisible
        {
            get => _isregvisible;
            set
            {
                if (_isregvisible != value)
                {
                    _isregvisible = value;
                    OnPropertyChanged(nameof(IsRegisterVisible));
                }
            }
        }

        public ICommand ShowLoginForm
        {
            get => new Command(() =>
            {
                IsLoginVisible = true;
                IsRegisterVisible = false;
            });
        }

        public ICommand ShowRegisterForm
        {
            get => new Command(() =>
            {
                IsRegisterVisible = true;
                IsLoginVisible = false;
            });
        }

        private string _nicknameField;
        public string NicknameField
        {
            get => _nicknameField;
            set
            {
                if (_nicknameField != value)
                    _nicknameField = value;
                OnPropertyChanged(nameof(NicknameField));
            }
        }

        private string _passwordField;
        public string PasswordField
        {
            get => _passwordField;
            set
            {
                if (_passwordField != value)
                    _passwordField = value;
                OnPropertyChanged(nameof(PasswordField));
            }
        }

        private string _passwordFieldAgain;
        public string PasswordFieldAgain
        {
            get => _passwordFieldAgain;
            set
            {
                if (_passwordFieldAgain != value)
                    _passwordFieldAgain = value;
                OnPropertyChanged(nameof(PasswordFieldAgain));
            }
        }

        public ICommand LoginCommand
        {
            get => new Command(() =>
            {
                User = new User();
                if (User.Login(NicknameField, PasswordField) != true)
                    User = User;//toast that user insert bad data
                else
                {
                    Preferences.Set("nickname", NicknameField);
                    App.Current.MainPage = new MainPage();
                }
            });
        }

        public ICommand RegisterCommand
        {
            get => new Command(() =>
            {
                User = new User();
                if (User.Register(NicknameField, PasswordField) != true)
                    User = User;//toast that user insert bad data
                else
                {
                    Preferences.Set("nickname", NicknameField);
                    App.Current.MainPage = new MainPage();
                }
            });
        }
    }
}