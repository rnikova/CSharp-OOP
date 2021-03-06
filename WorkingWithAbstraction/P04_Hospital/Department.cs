﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
