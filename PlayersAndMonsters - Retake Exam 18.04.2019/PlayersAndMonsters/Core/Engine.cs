namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private ManagerController managerController;

        public Engine()
        {
            managerController = new ManagerController();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Exit")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string result = string.Empty;

                try
                {
                    switch (commandArgs[0])
                    {
                        case "AddPlayer":
                            result += this.managerController.AddPlayer(commandArgs[1], commandArgs[2]);
                            break;
                        case "AddCard":
                            result += this.managerController.AddCard(commandArgs[1], commandArgs[2]);
                            break;
                        case "AddPlayerCard":
                            result += this.managerController.AddPlayerCard(commandArgs[1], commandArgs[2]);
                          break;
                        case "Fight":
                            result += this.managerController.Fight(commandArgs[1], commandArgs[2]);
                            break;
                        case "Report":
                            result += this.managerController.Report();
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
