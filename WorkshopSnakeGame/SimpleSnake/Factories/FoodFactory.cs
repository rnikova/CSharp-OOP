namespace SimpleSnake.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;

    public static class FoodFactory
    {
        private static Random random;

        static FoodFactory()
        {
            random = new Random();
        }

        public static Food GetRandomFood(int borderWigth, int borderHeigth)
        {
            List<Type> foodType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(Food))
                .ToList();

            Type currentFoodType = foodType[random.Next(0, foodType.Count)];

            int coordinateX = random.Next(1, borderWigth - 1);
            int coordinateY = random.Next(1, borderHeigth - 1);

            Coordinate foodCoordinate = new Coordinate(coordinateX, coordinateY);

            return Activator.CreateInstance(currentFoodType, new object[] { foodCoordinate }) as Food;
        }
    }
}
