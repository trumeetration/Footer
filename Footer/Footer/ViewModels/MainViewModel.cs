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
    public class MainViewModel : BaseViewModel
    {
        private bool _isloginvisible = true;
        private bool _isregvisible = false;
        private bool _isrecoveryvisible = false;
        private bool _isLanguageVisible = false;

        public IUser User => App.CurrentUser;

        public MainViewModel()
        {
            Title = "Login";
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

        public bool IsRecoveryVisible
        {
            get => _isrecoveryvisible;
            set
            {
                if (_isrecoveryvisible != value)
                {
                    _isrecoveryvisible = value;
                    OnPropertyChanged(nameof(IsRecoveryVisible));
                }
            }
        }

        public bool isLanguageVisible
        {
            get => _isLanguageVisible;
            set
            {
                if (_isLanguageVisible != value)
                {
                    _isLanguageVisible = value;
                    OnPropertyChanged(nameof(isLanguageVisible));
                }
            }
        }

        public ICommand ShowLanguage
        {
            get => new Command(() =>
            {
                if (isLanguageVisible) isLanguageVisible = false;
                else isLanguageVisible = true;
            });
        }

        public ICommand ShowLoginForm
        {
            get => new Command(() =>
            {
                IsLoginVisible = true;
                IsRecoveryVisible = IsRegisterVisible = false;
            });
        }

        public ICommand ShowRegisterForm
        {
            get => new Command(() =>
            {
                IsRegisterVisible = true;
                IsLoginVisible = IsRecoveryVisible = false;
            });
        }

        public ICommand ShowRecoveryForm
        {
            get => new Command(() =>
            {
                IsRecoveryVisible = true;
                IsLoginVisible = IsRegisterVisible = false;
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

        private string _emailField;
        public string EmailField
        {
            get => _emailField;
            set
            {
                if (_emailField != value)
                    _emailField = value;
                OnPropertyChanged(nameof(EmailField));
            }
        }

        public ICommand LoginCommand
        {
            get => new Command(() =>
            {
                App.CurrentUser = new User()
                {
                    Nickname = NicknameField
                };
                Preferences.Set("nickname", NicknameField);
                App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
            });
        }

        public ICommand RegisterCommand
        {
            get => new Command(() =>
            {
                App.CurrentUser = new User()
                {
                    Nickname = NicknameField
                };
                Preferences.Set("nickname", NicknameField);
                App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
            });
        }
    }
}