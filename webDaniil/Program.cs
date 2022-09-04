// DZ220718 - wcfDaniil
//
// Version : 1.4
// Release : August 17/2022
//                
// Re : wcfDaniil REST API                                                                     
//
// Update : DZ220718 - Reorganised and cleaned up code
// Update : DZ220817 - Cleaned up references


using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace webDaniil
{
    class Program
    {

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static WebServiceHost _HOST { get; set; }
       


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        static void Main(string[] args)
        {
            Console.WriteLine(GAPP.Gap.AssemblyVersion());

            Console.WriteLine("Begin");
            //  Console.WriteLine(GPC.get_the_ip());

            Uri httpUrl = new Uri("http://localhost:80/");

            _HOST = new WebServiceHost(typeof(wcfDaniil.oWCFDaniil), httpUrl);

            var binding = new WebHttpBinding();
            _HOST.AddServiceEndpoint(typeof(wcfDaniil.iWCFDaniil), binding, "test_Authentication");

            _HOST.Open();

            Console.WriteLine("Commence with the testing!");
            Console.ReadLine();

            _HOST.Close();

            Console.WriteLine("End");
            Console.ReadLine();
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/


    }

}

