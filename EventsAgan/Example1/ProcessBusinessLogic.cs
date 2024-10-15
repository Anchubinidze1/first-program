using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAgan.Example1
{
    public delegate void Notify(); // creating of delegate

    //this class is a publisher
    internal class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // creation of event

        public void StartProcess() 
        {
            Console.WriteLine("Process started");

            //logic

            OnProcessCompleted();
        }


        protected virtual void OnProcessCompleted() 
        {
            //will call delegate with event , and will also invoke all the eventHandler methoods , that are registered in this event
            ProcessCompleted?.Invoke();
        }
    }

    // this is a subscriber class
    internal class SomeSubscriber 
    {
        //method that maches registration of delegate (returns void and does not have argument) , and this method will handle the event
        public static void bl_Completed() 
        {
            Console.WriteLine("Process completed");
        }

        public static void ConnectWithEvent() 
        {
            //creating Publisher class object
            ProcessBusinessLogic process = new ProcessBusinessLogic();

            // adding method bl_completed to event called ProcessCompleted
            process.ProcessCompleted += bl_Completed;

            //calling process method
            process.StartProcess();


        }

    }
}
