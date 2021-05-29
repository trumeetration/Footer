using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Footer.Interfaces
{
    public interface IUser
    {
        string Nickname { get; set; }
        //todo string Password { get; set; }
        string Email { get; set; }
        //string FirstName { get; set; }
        //string LastName { get; set; }
        ObservableCollection<IStatistics> Statistic { get; }
    }
}
