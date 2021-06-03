using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Footer.Interfaces
{
    public interface IUser
    {
        string Nickname { get; set; }
        ObservableCollection<IStatistic> StatisticsCollection { get; set; }
        ObservableCollection<IAchievement> AchievementsCollection { get; set; }
    }
}
