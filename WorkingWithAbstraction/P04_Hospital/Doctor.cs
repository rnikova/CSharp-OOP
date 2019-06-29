using System;
using System.Collections.Generic;
using System.Text;

namespace P04Hospital
{
    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Patients { get; set; }
    }
}
