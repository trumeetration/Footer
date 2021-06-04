using System;
using System.Collections.Generic;
using System.Text;

namespace Footer.Interfaces
{
    public interface IStepCounter
    {
        int Steps { get; set; }

        void InitSensorService();

        void StopSensorService();
    }
}
