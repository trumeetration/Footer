using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public IUser User => App.CurrentUser;

        public MainViewModel()
        {
            Title = "Login";
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                Task.Run(async () =>
                {
                    StepsCountField = DependencyService.Get<IStepCounter>().Steps.ToString();
                });
                return true;
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

        private string _newPassField;
        public string NewPassField
        {
            get => _newPassField;
            set
            {
                if (_newPassField != value)
                    _newPassField = value;
                OnPropertyChanged(nameof(NewPassField));
            }
        }

        private string _currentPasswordField;
        public string CurrentPasswordField
        {
            get => _currentPasswordField;
            set
            {
                if (_currentPasswordField != value)
                    _currentPasswordField = value;
                OnPropertyChanged(nameof(CurrentPasswordField));
            }
        }

        private string _newNicknameField;
        public string NewNicknameField
        {
            get => _newNicknameField;
            set
            {
                if (_newNicknameField != value)
                    _newNicknameField = value;
                OnPropertyChanged(nameof(NewNicknameField));
            }
        }

        private string _stepsCountField;

        public string StepsCountField
        {
            get => _stepsCountField;
            set
            {
                if (_stepsCountField != value)
                    _stepsCountField = value;
                OnPropertyChanged(nameof(StepsCountField)); // DependencyService.Get<IStepCounter>().Steps.ToString()
            }
        }

        private string _x;
        public string X
        {
            get => _x;
            set
            {
                if (_x != value)
                    _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private string _y;
        public string Y
        {
            get => _y;
            set
            {
                if (_y != value)
                    _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        private string _z;
        public string Z
        {
            get => _z;
            set
            {
                if (_z != value)
                    _z = value;
                OnPropertyChanged(nameof(Z));
            }
        }

        public ICommand ChangeUserDataCommand
        {
            get => new Command(() =>
            {
                if (User.ChangeCredentials(NewPassField, CurrentPasswordField, NewNicknameField) != true)
                {
                    NewNicknameField = NewNicknameField; //todo toast user input bad data
                }
            });
        }

    }
}