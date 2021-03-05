using System;

namespace AbstractFactoryPattern
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

    class RoundRectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside RoundRectangle::draw() method.");
        }
    }

    class RoundSquare : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside RoundSquare::draw() method.");
        }
    }

    abstract class AbstractFactory
    {
        abstract public IShape GetShape(string shapeType);
    }

    class ShapeFactory : AbstractFactory
    {
        public override IShape GetShape(string shapeType)
        {
            if (shapeType.ToUpper() == "RECTANGLE")
                return new Rectangle();
            if (shapeType.ToUpper() == "SQUARE")
                return new Square();
            return null;
        }
    }

    class RoundShapeFactory : AbstractFactory
    {
        public override IShape GetShape(string shapeType)
        {
            if (shapeType.ToUpper() == "RECTANGLE")
                return new RoundRectangle();
            if (shapeType.ToUpper() == "SQUARE")
                return new RoundSquare();
            return null;
        }
    }

    class FactoryProducer
    {
        public static AbstractFactory GetFactory(bool rounded)
        {
            if (rounded == true)
                return new RoundShapeFactory();
            else
                return new ShapeFactory();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory shapeFactory = FactoryProducer.GetFactory(false);
            IShape shape1 = shapeFactory.GetShape("Square");
            shape1.Draw();
            IShape shape2 = shapeFactory.GetShape("Rectangle");
            shape2.Draw();

            AbstractFactory roundShapeFactory = FactoryProducer.GetFactory(true);
            IShape shape3 = roundShapeFactory.GetShape("Square");
            shape3.Draw();
            IShape shape4 = roundShapeFactory.GetShape("Rectangle");
            shape4.Draw();
        }
    }
}

/*
Output:
Inside Square::draw() method.
Inside Rectangle::draw() method.
Inside RoundSquare::draw() method.
Inside RoundRectangle::draw() method.
*/