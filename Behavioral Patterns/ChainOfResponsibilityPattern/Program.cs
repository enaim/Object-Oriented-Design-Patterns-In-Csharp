using System;

namespace ChainOfResponsibilityPattern
{
    abstract class Handler
    {
        protected Handler successor;
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if( request >= 0 && request < 10 )
            {
                Console.WriteLine("{0} handled request {1}.", this.GetType().Name, request);
            }
            else
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}.", this.GetType().Name, request);
            }
            else
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}.", this.GetType().Name, request);
            }
            else
            {
                successor.HandleRequest(request);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] _request = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach(int request in _request)
            {
                h1.HandleRequest(request);
            }
        }
    }
}

/*
Output:
ConcreteHandler1 handled request 2.
ConcreteHandler1 handled request 5.
ConcreteHandler2 handled request 14.
ConcreteHandler3 handled request 22.
ConcreteHandler2 handled request 18.
ConcreteHandler1 handled request 3.
ConcreteHandler3 handled request 27.
ConcreteHandler3 handled request 20.
*/