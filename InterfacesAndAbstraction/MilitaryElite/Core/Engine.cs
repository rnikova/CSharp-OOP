using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.Exeptions;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                if (type == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);

                    this.army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAdd = commandArgs.Skip(5).ToArray();

                    foreach (var privateId in privatesToAdd)
                    {
                        ISoldier currentSoldier = this.army.First(x => x.Id == privateId);

                        general.AddPrivate(currentSoldier);
                    }

                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairArgs = commandArgs.Skip(6).ToArray();
                        AddRepairs(engineer, repairArgs);

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsException ice)
                    {
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missions = commandArgs.Skip(6).ToArray();

                        for (int i = 0; i < missions.Length; i += 2)
                        {
                            try
                            {
                                string codeName = missions[i];
                                string state = missions[i + 1];

                                IMission mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException ise)
                            {
                                continue;
                            }
                        }

                        this.army.Add(commando);
                    }
                    catch (InvalidCorpsException ice)
                    {
                    }
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    this.army.Add(spy);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();

                object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
            }
        }

        private static void AddRepairs(Engineer engineer, string[] repairArgs)
        {
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hours = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hours);
                engineer.AddRepair(repair);
            }
        }
    }
}
