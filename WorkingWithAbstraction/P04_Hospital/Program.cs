using System;
using System.Collections.Generic;
using System.Linq;

namespace P04Hospital
{
    public class Program
    {
        static List<Department> departments;
        static List<Doctor> doctors;

        public static void Main()
        {
            departments = new List<Department>();
            doctors = new List<Doctor>();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Output")
            {
                var departmentName = command[0];
                var patient = command[3];
                var doctorName = command[1] + " " + command[2];

                Department department = GetDepartment(departmentName);
                Doctor doctor = GetDoctor(doctorName);

                bool hasRoom = department.Rooms.Sum(x => x.Patients.Count) < 60;

                if (hasRoom)
                {
                    int targetRoom = 0;
                    doctor.Patients.Add(patient);

                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }

                    department.Rooms[targetRoom].Patients.Add(patient);
                }

                command = Console.ReadLine().Split();
            }

            command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                string[] args = command;

                if (args.Length == 1)
                {
                    var department = GetDepartment(args[0]);

                    foreach (var room in department.Rooms.Where(x => x.Patients.Count > 0))
                    {
                        foreach (var patient in room.Patients)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var department = GetDepartment(args[0]);

                    foreach (var patient in department.Rooms[room-1].Patients.OrderBy(x=>x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {

                    var doctor = GetDoctor(args[0] + " " + args[1]);

                    foreach (var patient in doctor.Patients.OrderBy(x=>x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                command = Console.ReadLine().Split();
            }
        }

        private static Doctor GetDoctor(string doctorName)
        {
            Doctor doctor = doctors.FirstOrDefault(x => x.Name == doctorName);

            if (doctor == null)
            {
                doctor = new Doctor(doctorName);
                doctors.Add(doctor);
            }

            return doctor;
        }

        private static Department GetDepartment(string departmentName)
        {
            Department department = departments.FirstOrDefault(x => x.Name == departmentName);

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);

                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
            }

            return department;
        }
    }
}