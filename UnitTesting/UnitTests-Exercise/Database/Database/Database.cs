using System;
using System.Collections.Generic;

namespace DatabaseProblem
{
    public class Database
    {
        private const int DEFAULT_SIZE = 16;
        private int[] database;
        private int index;

        public Database(params int[] collection)
        {
            this.ValidateCollenctionSize(collection);
            this.database = new int[DEFAULT_SIZE];
            this.DatabaseElements = collection;
        }

        public int[] DatabaseElements
        {
            get
            {
                List<int> numbers = new List<int>();

                for (int i = 0; i < index; i++)
                {
                    numbers.Add(this.database[i]);
                }

                return numbers.ToArray();
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this.database[index] = value[i];
                    index++;
                }
            }
        }

        public void Add(int number)
        {
            if (index >= DEFAULT_SIZE)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.database[this.index] = number;
            this.index++;
        }

        public void Remove()
        {
            if (this.index <= 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.database[this.index - 1] = default;
            this.index--;
        }

        private void ValidateCollenctionSize(int[] value)
        {
            if (value.Length > DEFAULT_SIZE || value.Length < 1)
            {
                throw new InvalidOperationException("Filled capacity");
            }
        }
    }
}
