using System;


namespace wcfDaniil
{
    public class Validation2
    {
        public string ValidateT(string userName, string password)
        {
            Console.WriteLine("ValidateT");
            if (null == userName || null == password)
            {

                return "NULL error";
            }

            if ((userName == "Daniil" && password == "1234") || (userName == "Test" && password == "tttt"))
            {
                return "Welcome";
            }
            else
            {
                return "Unknown user";
            }


            
        }
    }
}
