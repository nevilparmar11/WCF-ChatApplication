using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatServiceLibrary;

namespace ChatServiceHost
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Starting Chat Service...");
                // Note: Do not put this service host constructor within a using clause.
                // Errors in Open will be trumped by errors from Close (implicitly called from ServiceHost.Dispose).
                ServiceHost chatHost = new ServiceHost(typeof(ChatService));
                chatHost.Open();

                ServiceHost userHost = new ServiceHost(typeof(UserService));
                userHost.Open();

                Console.WriteLine("The Chat Service has started.");
                Console.WriteLine("The User Service has started.");
                Console.WriteLine("Press <ENTER> to quit.");
                Console.ReadLine();
                chatHost.Close();
                userHost.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Press <ENTER> to quit.");
                Console.ReadLine();
            }

        } // end of method
    } // end of class
} // end of namespace
