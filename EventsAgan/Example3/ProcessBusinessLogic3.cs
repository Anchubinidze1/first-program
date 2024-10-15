using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAgan.Example3
{
    internal class ProcessBusinessLogic3
    {
        public event EventHandler<bool> ProcessBusinessLogicCompleted;

        public void StartProcess() 
        {
            try 
            {
                Console.WriteLine("Process Started");

                OnProcessCompleted(true);
            }catch (Exception ex) 
            {
                OnProcessCompleted(false); 
            }
        }

        protected virtual void OnProcessCompleted(bool isSuccesful) 
        {
            ProcessBusinessLogicCompleted?.Invoke(this, isSuccesful);
        }
    }

    internal class SomeSubscriber3 
    {
    
        public static void bl_ProcessCompleted(object sender, bool isSuccesful) 
        {
            Console.WriteLine("Process Completed");
        }

        public static void ConntectWithEvent() 
        {
            ProcessBusinessLogic3 processBusinessLogic3 = new ProcessBusinessLogic3();
            processBusinessLogic3.ProcessBusinessLogicCompleted += bl_ProcessCompleted;

            processBusinessLogic3.StartProcess();
        }
    }
}
