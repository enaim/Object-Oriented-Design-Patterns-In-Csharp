using System;

namespace VisitorPattern
{
    interface IComputerPart
    {
        void Accept(IComputerPartVisitor computerPartVisitor);
    }

    class Keyborad : IComputerPart
    {
        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    class Mouse : IComputerPart
    {
        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    class Monitor : IComputerPart
    {
        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    class Computer : IComputerPart
    { 
        IComputerPart[] parts;

        public Computer()
        {
            parts = new IComputerPart[] { new Mouse(), new Keyborad(), new Monitor() };
        }

        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            for(int i=0; i<parts.Length; i++)
            {
                parts[i].Accept(computerPartVisitor);
            }
            computerPartVisitor.Visit(this);
        }
    }

    interface IComputerPartVisitor
    {
        void Visit(Computer computer);
        void Visit(Mouse mouse);
        void Visit(Keyborad keyborad);
        void Visit(Monitor monitor);
    }

    class ComputerPartDisplayVisitor : IComputerPartVisitor
    {
        public void Visit(Computer computer)
        {
            Console.WriteLine("Displaying Computer.");
        }

        public void Visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse.");
        }

        public void Visit(Keyborad keyborad)
        {
            Console.WriteLine("Displaying Keyborad.");
        }

        public void Visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Monitor.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IComputerPart computer = new Computer();
            computer.Accept(new ComputerPartDisplayVisitor());
        }
    }
}

/*
Output:
Displaying Mouse.
Displaying Keyborad.
Displaying Monitor.
Displaying Computer.
*/