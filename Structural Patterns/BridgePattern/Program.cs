using System;

namespace BridgePattern
{
    abstract class Abstraction
    {
        protected IMplementor implementor;

        public IMplementor Implementor
        {
            set { implementor = value; }
        }
        public abstract void Operation();
    }

    interface IMplementor
    {
        public void Operation();
    }

    class RedefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }

    class ConcreteImplementorA : IMplementor
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation."); ;
        }
    }

    class ConcreteImplementorB : IMplementor
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation."); ;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RedefinedAbstraction();

            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();
        }
    }
}

/*
Output:
ConcreteImplementorA Operation.
ConcreteImplementorB Operation.
*/