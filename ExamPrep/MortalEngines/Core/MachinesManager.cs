namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);

            if (this.pilots.Contains(pilot))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            this.pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            ITank tank = new Tank(name, attackPoints, defensePoints);

            if (this.machines.Contains(tank))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            this.machines.Add(tank);

            return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            Fighter fighter = new Fighter(name, attackPoints, defensePoints);

            if (this.machines.Any(f => f.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            this.machines.Add(fighter);

            return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            string result = string.Empty;

            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                result = string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            else if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            else if (machine.Pilot != null)
            {
                result = string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                result = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }

            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            string result = string.Empty;

            var attackingMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attackingMachine.HealthPoints == 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defendingMachine.HealthPoints == 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
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
            var pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var searshedFigther = this.machines.FirstOrDefault(f => f.Name == fighterName);

            if (searshedFigther == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            Fighter fighter = (Fighter)searshedFigther;
            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var searshedTank = this.machines.FirstOrDefault(t => t.Name == tankName);

            if (searshedTank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            Tank tank = (Tank)searshedTank;
            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}