﻿using System;
using System.Collections.Generic;
using System.Text;

namespace engine.Models
{
    public class Location
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
    }
}
