﻿namespace Animals
{
    using System;

    public abstract class Animal
    {
        private string name;

        private int age;

        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value == null)
                {
                    throw new Exception("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid input!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            private set
            {
                if (string.IsNullOrEmpty(value) || value == null)
                {
                    throw new Exception("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("");
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}