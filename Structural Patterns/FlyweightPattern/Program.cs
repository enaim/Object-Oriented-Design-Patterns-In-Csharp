using System;
using System.Collections;

namespace FlyweightPattern
{ 
    interface Flyweight
    {
        void Operation(int extrinsicstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public void Operation(int extrinsicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }

    class UnSharedConcreteFlyweight : Flyweight
    {
        public void Operation(int extrinsicstate)
        {
            Console.WriteLine("UnSharedConcreteFlyweight: " + extrinsicstate);
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)flyweights[key];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;

            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            UnSharedConcreteFlyweight fu = new UnSharedConcreteFlyweight();
            fu.Operation(extrinsicstate);
        }
    }
}

/*
Output:
ConcreteFlyweight: 21
ConcreteFlyweight: 20
ConcreteFlyweight: 19
UnSharedConcreteFlyweight: 19
*/