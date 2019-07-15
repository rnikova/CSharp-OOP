namespace WildFarm.Models.Foods
{
    public static class FoodFactory
    {
        public static Food Create(params string[] foodArgs)
        {
            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            if (foodType == "Vegetable")
            {
                return new Vegetable(foodQuantity);
            }
            else if (foodType=="Seeds")
            {
                return new Seeds(foodQuantity);
            }
            else if (foodType=="Meat")
            {
                return new Meat(foodQuantity);
            }
            else if (foodType=="Fruit")
            {
                return new Fruit(foodQuantity);
            }

            return null;
        }
    }
}
