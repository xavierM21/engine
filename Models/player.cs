using System;
using System.Collections.Generic;
using System.Text;

namespace engine.Models
{
    public class player // public is there to make this class and vars visiable to the entire program.
    {
        // get and set means that you can get the value and set the value of the string and int
        public string Name { get; set; }
        public string CharClass { get; set; }
        public int HP { get; set; }
        public int XP { get; set; }
        public int Lvl { get; set; }
        public int Gold { get; set; }
    }
}
