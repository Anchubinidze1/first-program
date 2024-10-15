
using EventsAgan.Example1;
using EventsAgan.Example2;
using EventsAgan.Example3;
using EventsAgan.Example4;

namespace EventsAgan 
{
    class Program 
    {
        
        public static void Main(string[] args) 
        {
            SomeSubscriber.ConnectWithEvent();
            SomeSubcscriber2.ConnectWithPublisher();
            SomeSubscriber3.ConntectWithEvent();
            SomeSubscriber4.ConnectToEvent();
        }
    }
}