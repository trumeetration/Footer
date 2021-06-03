using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Footer.Interfaces;

namespace Footer.Models
{
    public class User: INotifyPropertyChanged, IUser
    {
        private string _nickname;
        //todo private string _password;
        private string _email;
        private string _firstName;
        private string _lastName;
        public User()
        {
            StatisticsCollection = StatisticsCollection ?? new ObservableCollection<IStatistic>();
            AchievementsCollection = AchievementsCollection ?? new ObservableCollection<IAchievement>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string Nickname { 
            get => _nickname;
            set
            {
                _nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }

        public bool ChangeCredentials(string newPass, string currentPassword, string newUsername = "")
        {
            //В будущем отсылать данные на сервер, проверять ответ от сервера
            //Если ответ смены пароля успешен, сменить
            Nickname = newUsername;
            return true;
        }

        public bool Logout()
        {
            //Если сервер подтверждает выход с аккаунта, очищаем данные юзера
            Nickname = string.Empty;
            StatisticsCollection.Clear();
            return true;
        }

        public ObservableCollection<IStatistic> StatisticsCollection { get; set; }

        public ObservableCollection<IAchievement> AchievementsCollection { get; set; }
    }
}
