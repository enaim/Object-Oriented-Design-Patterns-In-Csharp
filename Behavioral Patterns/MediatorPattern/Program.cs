using System;
using System.Collections.Generic;

namespace MediatorPattern
{
    interface IChatMediator
    {
        public void SendMessage(string msg, User user);
        void AddUser(User user);
    }
    class User
    {
        protected IChatMediator mediator;
        protected string name;

        public User(IChatMediator mediator, string name)
        {
            this.mediator = mediator;
            this.name = name;

            this.mediator.AddUser(this);
        }

        public void Send(string message)
        {
            Console.WriteLine("{0} Sending Message: {1}", name, message);
            mediator.SendMessage(message, this);
        }
        public void Receive(string message)
        {
            Console.WriteLine("{0} Received Message: {1}", name, message);
        }
    }

    class ChatMediator : IChatMediator
    {
        private List<User> _users = new List<User>();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string msg, User user)
        {
            foreach(User _user in _users)
            {
                if( _user != user )
                {
                    _user.Receive(msg);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IChatMediator mediator = new ChatMediator();
            User user1 = new User(mediator, "A");
            User user2 = new User(mediator, "B");
            User user3 = new User(mediator, "C");
            User user4 = new User(mediator, "D");

            user1.Send("Hello");
        }
    }
}

/*
Output:
A Sending Message: Hello
B Received Message: Hello
C Received Message: Hello
D Received Message: Hello
*/