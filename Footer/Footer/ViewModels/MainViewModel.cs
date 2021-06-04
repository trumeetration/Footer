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
        private bool _isLanguageVisible = false;

        public IUser User => App.CurrentUser;

        public MainViewModel()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () =>
            {
                Task.Run(async () => { StepsCountField = DependencyService.Get<IStepCounter>().Steps.ToString(); });
                return true;
            });
            User.AchievementsCollection.Add(new Achievement()
            {
                Title = "Beginner",
                Description = "Make 100 steps",
                StepsNeed = 100,
                Claimed = false
            });
            User.AchievementsCollection.Add(new Achievement()
            {
                Title = "Middle",
                Description = "Make 500 steps",
                StepsNeed = 500,
                Claimed = false
            });
            User.AchievementsCollection.Add(new Achievement()
            {
                Title = "Runner",
                Description = "Make 1000 steps",
                StepsNeed = 1000,
                Claimed = false
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(5000), () =>
            {
                Task.Run(async () => {
                    for (int i = 0; i < User.AchievementsCollection.Count; i++)
                    {
                        if (User.AchievementsCollection[i].StepsNeed <= Convert.ToInt32(StepsCountField) &&
                            User.AchievementsCollection[i].Claimed == false)
                        {
                            User.OwnedAchievementsCollection.Add(User.AchievementsCollection[i]);
                            User.AchievementsCollection[i].Claimed = true;
                        }
                    }
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

        public ICommand ShowLanguage
        {
            get => new Command(() =>
            {
                if (isLanguageVisible)
                {
                    isLanguageVisible = false;
                }
                else
                    isLanguageVisible = true;
            });

        }
    }
}