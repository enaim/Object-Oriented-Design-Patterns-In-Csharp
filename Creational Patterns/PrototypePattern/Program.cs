using System;

namespace PrototypePattern
{
    class Person
    {
        public int age;
        public DateTime birthDate;
        public string name;
        public IdInfo idInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.idInfo = new IdInfo(idInfo.idNumber);
            clone.name = String.Copy(name);
            return clone;
        }
    }

    class IdInfo
    {
        public int idNumber;
        public IdInfo(int idNumber)
        {
            this.idNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.age = 42;
            p1.birthDate = Convert.ToDateTime("1977-01-01");
            p1.name = "Sharif Hossain";
            p1.idInfo = new IdInfo(666);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("    p1 instance values:");
            DisplayValues(p1);
            Console.WriteLine("    p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("    p3 instance values:");
            DisplayValues(p3);

            p1.age = 32;
            p1.birthDate = Convert.ToDateTime("1987-01-01");
            p1.name = "Ashraful Islam";
            p1.idInfo.idNumber = 7878;

            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("    p1 instance values:");
            DisplayValues(p1);
            Console.WriteLine("    p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("    p3 instance values:");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("       Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}", p.name, p.age, p.birthDate);
            Console.WriteLine("       ID#: {0:d}", p.idInfo.idNumber);
        }
    }
}

/*
Output:
Original values of p1, p2, p3:
    p1 instance values:
       Name: Sharif Hossain, Age: 42, BirthDate: 01/01/77
       ID#: 666
    p2 instance values:
       Name: Sharif Hossain, Age: 42, BirthDate: 01/01/77
       ID#: 666
    p3 instance values:
       Name: Sharif Hossain, Age: 42, BirthDate: 01/01/77
       ID#: 666

Values of p1, p2 and p3 after changes to p1:
Original values of p1, p2, p3:
    p1 instance values:
       Name: Ashraful Islam, Age: 32, BirthDate: 01/01/87
       ID#: 7878
    p2 instance values:
       Name: Sharif Hossain, Age: 42, BirthDate: 01/01/77
       ID#: 7878
    p3 instance values:
       Name: Sharif Hossain, Age: 42, BirthDate: 01/01/77
       ID#: 666
*/