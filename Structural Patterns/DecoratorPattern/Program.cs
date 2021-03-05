using System;

namespace DecoratorPattern
{
    interface IShape
    {
        void Draw();
    }

    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape: Circle");
        }
    }

    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape: Rectangle");
        }
    }

    abstract class ShapeDecorator : IShape
    {
        protected IShape decoratedShape;

        public ShapeDecorator(IShape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }
        public virtual void Draw()
        {
            decoratedShape.Draw();
        }
    }

    class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape decoratedShape) : base(decoratedShape) {}

        public override void Draw()
        {
            decoratedShape.Draw();
            Console.WriteLine("Border Color: Red");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle();
            IShape redCircle = new RedShapeDecorator(circle);
            IShape redRectangle = new RedShapeDecorator(new Rectangle());

            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.Draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.Draw();
        }
    }
}

/*
Output:
Circle with normal border
Shape: Circle

Circle of red border
Shape: Circle
Border Color: Red

Rectangle of red border
Shape: Rectangle
Border Color: Red
*/