using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAgan.Example2
{
    internal class ProcessBusinessLogic2
    {
        // creating event using special delegate called EventHandler
        public event EventHandler ProcessCompleted;

        public void StartProcess() 
        {
            Console.WriteLine("Starting Process");


            OnProcessCompleted(EventArgs.Empty);
        }

        // giving EventArgs argument to protected virtual class
        protected virtual void OnProcessCompleted(EventArgs args) 
        {
            //invoking event and giving 2 arguments , first one is informationa about source of the event , in this case source is the publisher class
            ProcessCompleted?.Invoke(this, args);
        }
    }

    internal class SomeSubcscriber2 
    {
        //event handler class must have 2 arguments in this case , we need source of the senders object , and just a argument
        public static void bl_ProcessCompleted(object sender, EventArgs e) 
        {
            Console.WriteLine("Process Completed");
        }

        public static void ConnectWithPublisher()
        {
            ProcessBusinessLogic2 processBusinessLogic2 = new ProcessBusinessLogic2();
            processBusinessLogic2.ProcessCompleted += bl_ProcessCompleted;
            processBusinessLogic2.StartProcess();
        }
    }
}
