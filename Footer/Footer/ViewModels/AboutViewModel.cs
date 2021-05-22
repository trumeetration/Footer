using System;
using System.Windows.Input;
using Footer.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Footer.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private bool _isloginvisible = true;
        private bool _isregvisible = false;
        private bool _isrecoveryvisible = false;
        public AboutViewModel()
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

        public  ICommand LoginCommand
        {
            get => new Command(() =>
            {
                App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
            });
        }
    }
}