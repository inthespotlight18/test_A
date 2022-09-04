﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                // decoding authToken we get decode value in 'Username:Password' format  
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                // spliting decodeauthToken using ':'   
                var arrUserNameandPassword = decodeauthToken.Split(':');

                // at 0th postion of array we get username and at 1st we get password  
                if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                {
                    // setting current principle  
                    Thread.CurrentPrincipal = new GenericPrincipal(
                           new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // In this method we can handle our database logic here...  
            return Username == "Daniil" && Password == "1234";
        }

    }
}

namespace BasicAuthentication.Controllers
{

    public class ValuesController : ApiController
    {
        [BasicAuthentication]
        public string Get()
        {
            return "WebAPI Method Called";
        }
    }
}








/*


public class BasicAuthentication : AuthorizationFilterAttribute
{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        if (actionContext.Request.Headers.Authorization != null)
        {
            var authToken = actionContext.Request.Headers
                .Authorization.Parameter;

            // decoding authToken we get decode value in 'Username:Password' format  
            var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                Convert.FromBase64String(authToken));

            // spliting decodeauthToken using ':'   
            var arrUserNameandPassword = decodeauthToken.Split(':');

            // at 0th postion of array we get username and at 1st we get password  
            if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
            {
                // setting current principle  
                Thread.CurrentPrincipal = new GenericPrincipal(
                       new GenericIdentity(arrUserNameandPassword[0]), null);
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        else
        {
            actionContext.Response = actionContext.Request
                .CreateResponse(HttpStatusCode.Unauthorized);
        }
    }

    public static bool IsAuthorizedUser(string Username, string Password)
    {
        // In this method we can handle our database logic here...  
        return Username == "Daniil" && Password == "1234";
    }

}

public class ValuesController : ApiController
{
    [BasicAuthentication]
    public string Get()
    {
        return "WebAPI Method Called";
    }
}


*/