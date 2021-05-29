using System;
using System.Collections.Generic;
using System.Text;

namespace Footer.Interfaces
{
    public interface IStatistics
    {
        DateTime Date { get; }
        int Steps { get; }
    }
}
