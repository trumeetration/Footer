using System;
using System.Collections.Generic;
using System.Text;

namespace Footer.Interfaces
{
    public interface IStatistic
    {
        DateTime Date { get; }
        int Steps { get; }
    }
}
