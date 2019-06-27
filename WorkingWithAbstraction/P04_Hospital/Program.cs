using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            List<Department> hospital = new List<Department>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] jetoni = command.Split();
                var departmentName = jetoni[0];
                var patient = jetoni[3];
                var doctor = jetoni[1] + jetoni[2];

                Department department = new Department(departmentName, doctor);

                if (department.Patients.Count <= 60)
                {
                    department.AddPatient(patient);
                }

                hospital.Add(department);       

                bool hasRoom = departments[departmentName].SelectMany(x => x).Count() < 60;
                if (hasRoom)
                {
                    int room = 0;
                    doctors[doctor].Add(patient);
                    for (int st = 0; st < departments[departmentName].Count; st++)
                    {
                        if (departments[departmentName][st].Count < 3)
                        {
                            room = st;
                            break;
                        }
                    }
                    departments[departmentName][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
