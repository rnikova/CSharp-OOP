using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;

namespace WildFarm.Models.Animals
{
    public static class AnimalFactory
    {
        public static Animal Create(params string[] animalArgs)
        {
            string animalType = animalArgs[0];
            string animalName = animalArgs[1];
            double animalWeight = double.Parse(animalArgs[2]);

            if (animalType == "Cat" || animalType == "Tiger")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                if (animalType == "Cat")
                {
                    return new Cat(animalName, animalWeight, livingRegion, breed);
                }
                else
                {
                    return new Tiger(animalName, animalWeight, livingRegion, breed);
                }
            }
            else if (animalType == "Dog" || animalType == "Mouse")
            {
                string livingRegion = animalArgs[3];

                if (animalType == "Dog")
                {
                    return new Dog(animalName, animalWeight, livingRegion);
                }
                else
                {
                    return new Mouse(animalName, animalWeight, livingRegion);
                }
            }
            else if (animalType == "Hen" || animalType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

                if (animalType == "Hen")
                {
                    return new Hen(animalName, animalWeight, wingSize);
                }
                else
                {
                    return new Owl(animalName, animalWeight, wingSize);
                }
            }

            return null;
        }
    }
}
