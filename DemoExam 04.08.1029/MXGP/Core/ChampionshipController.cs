using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        RiderRepository riderRepository;
        MotorcycleRepository motorcycleRepository;
        RaceRepository raceRepository;

        string message;

        public ChampionshipController()
        {
            riderRepository = new RiderRepository();
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            riderRepository.GetByName(riderName).AddMotorcycle(motorcycleRepository.GetByName(motorcycleModel));

            return message = string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            raceRepository.GetByName(raceName).AddRider(riderRepository.GetByName(riderName));

            return message = string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle;

            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
                motorcycleRepository.Add(motorcycle);
                message = string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
                motorcycleRepository.Add(motorcycle);
                message = string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, motorcycle.Model);
            }

            return message;
        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race(name, laps);

            if ((raceRepository.GetAll().FirstOrDefault(r => r.Name == name)) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            raceRepository.Add(race);

            return message = string.Format(OutputMessages.RaceCreated, race.Name);
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);

            if (riderRepository.GetByName(rider.Name) == null)
            {
                riderRepository.Add(rider);
                message = string.Format(OutputMessages.RiderCreated, rider.Name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, rider.Name));
            }

            return message;
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = raceRepository.GetByName(raceName);
            List<IRider> bestRiders = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(raceRepository.GetByName(raceName).Laps)).ToList();

            if (bestRiders.Count() < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {bestRiders.ElementAt(0).Name} wins {raceRepository.GetByName(raceName).Name} race.")
                .AppendLine($"Rider {bestRiders.ElementAt(1).Name} is second in {raceRepository.GetByName(raceName).Name} race.")
                .AppendLine($"Rider {bestRiders.ElementAt(2).Name} is third in {raceRepository.GetByName(raceName).Name} race.");

            raceRepository.Remove(raceRepository.GetByName(raceName));

            return sb.ToString().TrimEnd();
        }

        public void End()
        {
            Environment.Exit(0);
        }
    }
}
