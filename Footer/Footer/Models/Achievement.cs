using System;
using System.Collections.Generic;
using System.Text;
using Footer.Interfaces;

namespace Footer.Models
{
    public class Achievement : IAchievement
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //Image Icon { get; }
    }
}
