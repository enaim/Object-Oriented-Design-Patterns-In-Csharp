using System;

namespace SingletonPattern
{
    class Singleton
    {
        private Singleton() { }

        private static Singleton _instance = new Singleton();

        public static Singleton GetInstance()
        {
            return _instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instance.");
            }
        }
    }
}

/*
Output:
Singleton works, both variables contain the same instance.
*/