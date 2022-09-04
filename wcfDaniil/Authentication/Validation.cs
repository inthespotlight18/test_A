using System;
using System.IdentityModel.Selectors;
using System.ServiceModel;


namespace wcfDaniil
{
    public class Validation : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "Daniil" && password == "1234") && !(userName == "Test" && password == "tttt"))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
                // When you do not want to throw an infomative fault to the client,
                // throw the following exception.
                // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }


        }
    }
}
