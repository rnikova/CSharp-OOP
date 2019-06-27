using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        public Department(string name, string doctor)
        {
            this.Name = name;
            this.Doctor = doctor;
            this.Patients = new List<string>();
        }

        public string Name { get; set; }

        public string Doctor { get; set; }

        public List<string> Patients { get; set; }

        public void AddPatient(string patientName)
        {
            this.Patients.Add(patientName);
        }
    }
}
