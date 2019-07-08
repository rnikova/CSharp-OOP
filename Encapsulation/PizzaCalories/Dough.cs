using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double caloriesPerGram = 2;

        private Dictionary<string, double> flourModifiers;
        private Dictionary<string, double> techniqueModifiers;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourModifiers = new Dictionary<string, double>();
            this.techniqueModifiers = new Dictionary<string, double>();
            this.AddFlourModifiers();
            this.AddTechniqueModifiers();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            set
            {
                if (!flourModifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (!techniqueModifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private void AddFlourModifiers()
        {
            this.flourModifiers.Add("white", 1.5);
            this.flourModifiers.Add("wholegrain", 1.0);
        }

        private void AddTechniqueModifiers()
        {
            this.techniqueModifiers.Add("crispy", 0.9);
            this.techniqueModifiers.Add("chewy", 1.1);
            this.techniqueModifiers.Add("homemade", 1.0);
        }

        public double GetTotalCalories()
        {
            return (caloriesPerGram * this.Weight) * this.flourModifiers[this.FlourType.ToLower()] * this.techniqueModifiers[this.BakingTechnique.ToLower()];
        }
    }
}
