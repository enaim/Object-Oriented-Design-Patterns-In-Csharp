using System;

namespace AdapterPattern
{
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    class Adapter : Target
    {
        private readonly Adaptee _adaptee = new Adaptee();
        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Request();
        }
    }
}

/*
Output:
Called SpecificRequest()
*/