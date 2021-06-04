using System;
using System.Collections.Generic;
using System.Text;

namespace Footer.Interfaces
{
    public interface IAchievement
    {
        string Title { get; set; }
        string Description { get; set; }
        int StepsNeed { get; set; }
        bool Claimed { get; set; }
        //Image Icon { get; }
    }
}
