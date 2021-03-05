using System;
using System.Collections;

namespace BuilderPattern
{
    interface IItem
    {
        public string Name();
        public IPacking PackingType();
        public float Price();
    }

    interface IPacking
    {
        public string Pack();
    }

    class Wrapper : IPacking
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }

    class Bottle : IPacking
    {
        public string Pack()
        {
            return "Bottle";
        }
    }

    abstract class Burger : IItem
    {
        public IPacking PackingType()
        {
            return new Wrapper();
        }

        public abstract string Name();
        public abstract float Price();
    }

    abstract class ColdDrink : IItem
    {
        public IPacking PackingType()
        {
            return new Bottle();
        }

        public abstract string Name();
        public abstract float Price();
    }

    class VegBurger : Burger
    {
        public override string Name()
        {
            return "Vegetable Burger";
        }

        public override float Price()
        {
            return 50.5f;
        }
    }

    class ChickenBurger : Burger
    {
        public override string Name()
        {
            return "Chicken Burger";
        }

        public override float Price()
        {
            return 80.5f;
        }
    }

    class Coke : ColdDrink
    {
        public override string Name()
        {
            return "Coke";
        }

        public override float Price()
        {
            return 30.0f;
        }
    }

    class Pepsi : ColdDrink
    {
        public override string Name()
        {
            return "Pepsi";
        }

        public override float Price()
        {
            return 35.0f;
        }
    }

    class Meal
    {
        private ArrayList items = new ArrayList();

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public float GetCost()
        {
            float cost = 0.0f;
            foreach(IItem items in items)
            {
                cost += items.Price();
            }
            return cost;
        }

        public void ShowItems()
        {
            foreach(IItem item in items)
            {
                Console.Write("Item: " + item.Name());
                Console.Write(", Packing: " + item.PackingType().Pack());
                Console.WriteLine(", Price: " + item.Price());
            }
        }
    }

    class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }

        public Meal PrepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Vegetable Meal -> ");
            vegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetCost());

            Meal nonVegMeal = mealBuilder.PrepareNonVegMeal();
            Console.WriteLine("Non-Vegetable Meal -> ");
            nonVegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
        }
    }
}

/*
Output:
Vegetable Meal ->
Item: Vegetable Burger, Packing: Wrapper, Price: 50.5
Item: Coke, Packing: Bottle, Price: 30
Total Cost: 80.5
Non-Vegetable Meal ->
Item: Chicken Burger, Packing: Wrapper, Price: 80.5
Item: Pepsi, Packing: Bottle, Price: 35
Total Cost: 115.5
*/