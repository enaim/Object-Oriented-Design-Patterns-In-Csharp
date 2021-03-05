using System;

namespace StatePattern
{
    interface IState
    {
        public void Handle(Context context);
    }

    class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    class Context
    {
        private IState _state;
        public Context(IState state)
        {
            this.State = state;
        }

        public IState State
        {
            get { return _state; }
            set 
            { 
                _state = value;
                Console.WriteLine("State: {0}.", _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Context _context = new Context(new ConcreteStateA());

            _context.Request();
            _context.Request();
            _context.Request();
            _context.Request();
        }
    }
}

/*
Output:
State: ConcreteStateA.
State: ConcreteStateB.
State: ConcreteStateA.
State: ConcreteStateB.
State: ConcreteStateA.
*/