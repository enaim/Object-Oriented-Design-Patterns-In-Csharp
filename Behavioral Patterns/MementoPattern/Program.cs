using System;
using System.Collections.Generic;

namespace MementoPattern
{
    class Memento
    {
        private string state;
        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return this.state;
        }
    }

    class Originator
    {
        private string state;
        public void SetState(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return this.state;
        }

        public Memento SaveStateToMemento()
        {
            return new Memento(this.state);
        }

        public void GetStateFromMemento(Memento memento)
        {
            this.state = memento.GetState();
        }
    }

    class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void Add(Memento memento)
        {
            mementoList.Add(memento);
        }

        public Memento Get(int index)
        {
            return mementoList[index];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();

            originator.SetState("State #1");
            originator.SetState("State #2");
            careTaker.Add(originator.SaveStateToMemento());

            originator.SetState("State #3");
            careTaker.Add(originator.SaveStateToMemento());

            originator.SetState("State #4");
            Console.WriteLine("Current state -> " + originator.GetState());

            originator.GetStateFromMemento(careTaker.Get(0));
            Console.WriteLine("First saved state -> " + originator.GetState());

            originator.GetStateFromMemento(careTaker.Get(1));
            Console.WriteLine("Second saved state -> " + originator.GetState());
        }
    }
}

/*
Output:
Current state -> State #4
First saved state -> State #2
Second saved state -> State #3
*/