using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAgan.Example4
{

    internal class MyOwnEventArgs : EventArgs 
    {
        public bool IsCompleted {  get; set; }
        public DateTime dateTime { get; set; }
    }

    internal class BussinessLogic4
    {
        public event EventHandler<MyOwnEventArgs> OnCompleted;

        public void StartEvent() 
        {

            MyOwnEventArgs myOwnEventArgs = new MyOwnEventArgs();

            try 
            {
                Console.WriteLine("Process started");

                myOwnEventArgs.dateTime = DateTime.Now;
                myOwnEventArgs.IsCompleted = true;
                OnProcessCompleted(myOwnEventArgs);
            }catch (Exception ex) 
            {
                myOwnEventArgs.dateTime= DateTime.Now;
                myOwnEventArgs.IsCompleted = false;
                OnProcessCompleted(myOwnEventArgs );
            }

           
        }

        protected virtual void OnProcessCompleted(MyOwnEventArgs e) 
        {
            OnCompleted?.Invoke(this, e);
        }

        
    }

    internal class SomeSubscriber4
    {
        public static void ConnectToEvent()
        {
            BussinessLogic4 bussinessLogic4 = new BussinessLogic4();
            bussinessLogic4.OnCompleted += bl_ProcessCompleted;
            bussinessLogic4.StartEvent();
        }

        public static void bl_ProcessCompleted(object obj, MyOwnEventArgs e)
        {
            Console.WriteLine("Process " + (e.IsCompleted ? "Completed Succsecfully " : "Failed"));
            Console.WriteLine("Completion Time " + e.dateTime.ToString());
        }
    }
}
