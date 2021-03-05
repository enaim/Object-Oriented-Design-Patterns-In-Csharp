using System;

namespace FactoryPattern
{
    interface IShape
    {
        public void Draw();
    }

    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }

    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }

    class ShapeFactory
    {
        public IShape GetShape(string shapeType)
        {
            if (shapeType == null)
                return null;
            if (shapeType.ToUpper() == "RECTANGLE")
                return new Rectangle();
            if (shapeType.ToUpper() == "SQUARE")
                return new Square();
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape shape1 = shapeFactory.GetShape("Square");
            shape1.Draw();

            IShape shape2 = shapeFactory.GetShape("Rectangle");
            shape2.Draw();

            try
            {
                IShape shape3 = shapeFactory.GetShape("Circle");
                shape3.Draw();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exception received.");
            }
        }
    }
}

/*
Output:
Inside Square::draw() method.
Inside Rectangle::draw() method.
Object reference not set to an instance of an object.
Exception received.
*/