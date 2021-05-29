using System;
using System.Collections.Generic;
using System.Text;
using Footer.Interfaces;

namespace Footer.Models
{
    public class Statistics : IStatistics
    {
        public DateTime Date { get; }
        public int Steps { get; }
    }
}
