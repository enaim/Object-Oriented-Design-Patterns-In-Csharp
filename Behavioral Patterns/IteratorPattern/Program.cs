using System;

namespace IteratorPattern
{
    class Weeks
    {
        private string[] weeks = new string[]
        {
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"
        };

        public IWeeksIterator GetWeeksIterator()
        {
            return new WeeksIterator(weeks);
        }
    }

    interface IWeeksIterator
    {
        string Current { get; }
        bool MoveNext();
    }

    class WeeksIterator : IWeeksIterator
    {
        private readonly string[] weeks;
        private int position;
        public WeeksIterator(string[] weeks)
        {
            this.weeks = weeks;
            this.position = -1;
        }
        public string Current => weeks[position];

        public bool MoveNext()
        {
            if (++position == weeks.Length)
                return false;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Weeks weeks = new Weeks();
            IWeeksIterator iterator = weeks.GetWeeksIterator();

            while(iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
        }
    }
}

/*
Output:
Saturday
Sunday
Monday
Tuesday
Wednesday
Thursday
Friday
*/