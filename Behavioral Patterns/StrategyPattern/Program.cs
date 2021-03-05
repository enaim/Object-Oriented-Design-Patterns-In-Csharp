using System;

namespace StrategyPattern
{
    class Program
    {
        interface IStrategy
        {
            public int DoOperation(int num1, int num2);
        }

        class AddOperation : IStrategy
        {
            public int DoOperation(int num1, int num2)
            {
                return num1 + num2;
            }
        }

        class SubstractOperation : IStrategy
        {
            public int DoOperation(int num1, int num2)
            {
                return num1 - num2;
            }
        }

        class MultiplyOperation : IStrategy
        {
            public int DoOperation(int num1, int num2)
            {
                return num1 * num2;
            }
        }

        class Context
        {
            private IStrategy strategy;

            public Context(IStrategy strategy)
            {
                this.strategy = strategy;
            }

            public int ExecuteStrategy(int num1, int num2)
            {
                return strategy.DoOperation(num1, num2);
            }
        }

        static void Main(string[] args)
        {
            Context context = new Context(new AddOperation());
            Console.WriteLine("10 + 5 = {0}", context.ExecuteStrategy(10, 5));

            context = new Context(new SubstractOperation());
            Console.WriteLine("10 - 5 = {0}", context.ExecuteStrategy(10, 5));

            context = new Context(new MultiplyOperation());
            Console.WriteLine("10 X 5 = {0}", context.ExecuteStrategy(10, 5));
        }
    }
}

/*
Output:
10 + 5 = 15
10 - 5 = 5
10 X 5 = 50
*/