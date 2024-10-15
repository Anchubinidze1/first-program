using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAgan.Task1
{

    internal class MyEventArgs : EventArgs
    {
        public string NameOfUser {  get; set; }
        public string LastnameOfUser { get; set; }
        public string message {  get; set; }

        public override string ToString()
        {
            return "Name of the user : " + NameOfUser + "\n" + "lastname of the user " + LastnameOfUser + "\n" + "Message :" + message + "\n";
        }
    }

    public delegate void MyDelegate<MyEventArgs> (MyEventArgs my);

    internal class Users
    {
        public event MyDelegate<MyEventArgs> LoggedIn;
        public event MyDelegate<MyEventArgs> LoggedOut;

        public MyEventArgs my = new MyEventArgs();

        public void Start() 
        {
           
            Login();
            Logout();
        }
        protected virtual void Login() 
        {
            int number;
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Lastname");
            string lastname = Console.ReadLine();

            

            if(name == null || lastname == null ) 
            {
                throw new InvalidNameOrLastNameException("name or username can not be null");
            }
            else if(int.TryParse(name,out number) || int.TryParse(lastname,out number ) )
            {
                throw new NameOrUsernameCanNotBeNumberException("name or username can not be number");
            }

            Console.WriteLine("\nEnter the message");
            string message = Console.ReadLine();

            my.NameOfUser = name;
            my.LastnameOfUser = lastname;
            my.message = message;

            LoggedIn?.Invoke(my);


        }

        protected virtual void Logout() 
        {
            Console.WriteLine(my);
            LoggedOut?.Invoke(my); 
        }
    }

    interface TemplateForEventHandling 
    {
        public  void SubscribeToEvents(Users users);
        public void OnLogIn(MyEventArgs my);
        public void OnLogOut(MyEventArgs my);
    }

    internal class NotificationService : TemplateForEventHandling
    {
        
        public void SubscribeToEvents(Users users) 
        {

            users.LoggedIn += OnLogIn;
            users.LoggedOut += OnLogOut;

            
           
            
        }

        public void OnLogIn(MyEventArgs my) 
        {
            Console.WriteLine("User has Logged in");
        }

        public void OnLogOut(MyEventArgs my) 
        {
            Console.WriteLine("User had logged out");
        }
    }

    internal class AnalyticsService : TemplateForEventHandling
    {
        public int counterForLogIn = 0;
        public int counterForLogOut = 0;
        public void SubscribeToEvents(Users users )
        {
           
            users.LoggedIn += OnLogIn;
            users.LoggedOut += OnLogOut;
            
        }

        public void OnLogIn(MyEventArgs my)
        {
            counterForLogIn++;
            Console.WriteLine("Analytics: User Login recorded");
            
        }

        public void OnLogOut(MyEventArgs my)
        {
            counterForLogOut++;
            Console.WriteLine("Analytics: User Logout recorded");
            
        }
    }
}
