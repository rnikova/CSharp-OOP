namespace MortalEngines.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities.Models;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models.Mashines;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;
        private string result;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {

            if (this.pilots.Any(p => p.Name == name))
            {
                result = string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                IPilot pilot = new Pilot(name);
                pilots.Add(pilot);

                result = string.Format(OutputMessages.PilotHired, name);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Tank)))
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                IMachine tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);

                result = string.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
            }

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.Any(m => m.Name == name && m.GetType().Name == nameof(Fighter)))
            {
                result = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                IFighter fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);

                result = string.Format(OutputMessages.FighterManufactured,
                    fighter.Name,
                    fighter.AttackPoints,
                    fighter.DefensePoints,
                    "ON");
            }

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var searchedPilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var searchedMachine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (searchedPilot == null)
            {
                result = string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (searchedMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (searchedMachine.Pilot != null)
            {
                result = string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                searchedMachine.Pilot = searchedPilot;
                searchedPilot.AddMachine(searchedMachine);

                result = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }

            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine == null)
            {
                return result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attackingMachine.HealthPoints <= 0)
            {
                return result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defendingMachine.HealthPoints <= 0)
            {
                return result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            else
            {
                attackingMachine.Attack(defendingMachine);

                result = string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
            }

            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            var searchedPilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return searchedPilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var searchedMachine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return searchedMachine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var searchedFighter = this.machines
                .FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == nameof(Fighter));

            if (searchedFighter == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                IFighter fighter = (IFighter)searchedFighter;
                fighter.ToggleAggressiveMode();

                result = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var searchedTank = this.machines
                .FirstOrDefault(m => m.Name == tankName && m.GetType().Name == nameof(Tank));

            if (searchedTank == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                ITank tank = (ITank)searchedTank;
                tank.ToggleDefenseMode();

                result = string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return result;
        }
    }
}