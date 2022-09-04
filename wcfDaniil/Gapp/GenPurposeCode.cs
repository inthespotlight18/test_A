using System.Web;
using System;
using System.Reflection;
using System.Threading;
using System.Reflection.Emit;


namespace Gapp
{
    public class Gap
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string get_the_ip()
        {
            var ip = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "No IP";
            //Console.WriteLine(ip);
            return ip;
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public static string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

    }



}
