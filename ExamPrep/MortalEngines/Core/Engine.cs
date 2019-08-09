using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;

        public Engine()
        {
            machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string result = string.Empty;

                try
                {
                    switch (commandArgs[0])
                    {
                        case "HirePilot":
                            result += this.machinesManager.HirePilot(commandArgs[1]);
                            break;
                        case "PilotReport":
                            result += this.machinesManager.PilotReport(commandArgs[1]);
                            break;
                        case "ManufactureTank":
                            result += this.machinesManager.ManufactureTank(commandArgs[1],
                                double.Parse(commandArgs[2]),
                                double.Parse(commandArgs[3]));
                            break;
                        case "ManufactureFighter":
                            result += this.machinesManager.ManufactureFighter(commandArgs[1],
                                double.Parse(commandArgs[2]),
                                double.Parse(commandArgs[3]));
                            break;
                        case "MachineReport":
                            result += this.machinesManager.MachineReport(commandArgs[1]);
                            break;
                        case "AggressiveMode":
                            result += this.machinesManager.ToggleFighterAggressiveMode(commandArgs[1]);
                            break;
                        case "DefenseMode":
                            result += this.machinesManager.ToggleTankDefenseMode(commandArgs[1]);
                            break;
                        case "Engage":
                            result += this.machinesManager.EngageMachine(commandArgs[1], commandArgs[2]);
                            break;
                        case "Attack":
                            result += this.machinesManager.AttackMachines(commandArgs[1], commandArgs[2]);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine(result);
                }

                input = Console.ReadLine();
            }
        }
    }
}
