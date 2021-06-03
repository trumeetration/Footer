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
        public ObservableCollection<IStatistic> StatisticsCollection { get; set; }

        public ObservableCollection<IAchievement> AchievementsCollection { get; set; }
        public ObservableCollection<IAchievement> OwnedAchievementsCollection { get; set; }
        public User()
        {
            StatisticsCollection = StatisticsCollection ?? new ObservableCollection<IStatistic>();
            AchievementsCollection = AchievementsCollection ?? new ObservableCollection<IAchievement>();
            OwnedAchievementsCollection = OwnedAchievementsCollection ?? new ObservableCollection<IAchievement>();
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

        public bool Login(string login, string password)
        {
            //Если авторизация гуд, присвоить свойствам значения из ответа от сервера (ник, стата, ачивки, заработанные ачивки)
            Nickname = login;
            return true;
        }

        public bool Logout()
        {
            //Если сервер подтверждает выход с аккаунта, очищаем данные юзера
            Nickname = string.Empty;
            StatisticsCollection.Clear();
            return true;
        }

        public bool Register(string login, string password)
        {
            //Если сервер подтверждает регу аккаунта, очищаем данные юзера
            Nickname = login;
            return true;
        }
    }
}
