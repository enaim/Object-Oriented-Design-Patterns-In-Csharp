using System;

namespace FacadePattern
{
    interface IShape
    {
        void Draw();
    }

    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Rectangle::Draw()");
        }
    }

    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Square::Draw()");
        }
    }

    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Circle::Draw()");
        }
    }

    class ShapeMaker
    {
        private IShape circle;
        private IShape rectangle;
        private IShape square;

        public ShapeMaker()
        {
            circle = new Circle();
            rectangle = new Rectangle();
            square = new Square();
        }

        public void DrawRectangle()
        {
            rectangle.Draw();
        }

        public void DrawSquare()
        {
            square.Draw();
        }

        public void DrawCircle()
        {
            circle.Draw();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShapeMaker shapeMaker = new ShapeMaker();
            shapeMaker.DrawCircle();
            shapeMaker.DrawSquare();
            shapeMaker.DrawRectangle();
        }
    }
}

/*
Output:
Circle::Draw()
Square::Draw()
Rectangle::Draw()
*/