using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        ChampionshipController championshipController;

        public Engine()
        {
            championshipController = new ChampionshipController();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] inputTokens = input.Split();
                string result = string.Empty;

                try
                {
                    switch (inputTokens[0])
                    {
                        case "CreateRider":
                            result = championshipController.CreateRider(inputTokens[1]);
                            break;
                        case "CreateMotorcycle":
                            result = championshipController.CreateMotorcycle(inputTokens[1], inputTokens[2], int.Parse(inputTokens[3]));
                            break;
                        case "AddMotorcycleToRider":
                            result = championshipController.AddMotorcycleToRider(inputTokens[1], inputTokens[2]);
                            break;
                        case "AddRiderToRace":
                            result = championshipController.AddRiderToRace(inputTokens[1], inputTokens[2]);
                            break;
                        case "CreateRace":
                            result = championshipController.CreateRace(inputTokens[1], int.Parse(inputTokens[2]));
                            break;
                        case "StartRace":
                            result = championshipController.StartRace(inputTokens[1]);
                            break;
                        case "End":
                            championshipController.End();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
