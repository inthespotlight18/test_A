using System;
using System.Text;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using View;

namespace wcfDaniil
{
    
    public class oWCFDaniil : iWCFDaniil
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public int GetInfo()
        {
            return 99;
        }

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
 
        private string GetClientIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
               prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;

            return ip;
        }


        public Stream ShowClientIP()
        {
            string html = "<html><body>";

            html += string.Format("<h3>{0}|{1}</h3>", DateTime.Now, GetClientIP());
            html += "</body></html>";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Stream GetPage()
        {
            string html = "<html><body>";

            html += "<h3>Hello Daniil</h3>";
            html += "</body></html>";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public Stream Info()
        {
            WebServiceHost h = (WebServiceHost)OperationContext.Current.Host;


              string html = View.DataPresenter.ListToHTML(DataGetter.GetWebMethods(h, typeof(iWCFDaniil)));
            //string html = "info";

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(Encoding.UTF8.GetBytes(html));
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/


        public DataSet SampleDS()
        {
            DataTable dt = new DataTable("Nadia");
            dt.Columns.Add("code");
            dt.Columns.Add("First Name");
            dt.Rows.Add("1", "sister");
            dt.Rows.Add("2", "brother");

            DataSet ds = new DataSet("dsTest");
            ds.Tables.Add(dt);

            return ds;
        }


        public int PostTest(DataSet ds)
        {
            return ds.Tables.Count;
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public string Trap(int n)
        {
            try
            {
                if (n == 666) throw new ArgumentNullException(paramName: nameof(n), message: "parameter can't be 666.");
                return String.Format("OK|{0}|{1}", DateTime.Now, n);
            }
            catch (Exception ex)
            {
                return String.Format("FAIL |{0}", ex.Message);
            }
        }


        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        public string CallMS()
        {
            try
            {
                int[] array = { 12 };
                return array[2].ToString();
            }
            catch (Exception ex)
            {
                string msg = "additional info";
                Console.WriteLine(ex.Message);
                new XRAY.clientXRAY().Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
                return string.Format("FAIL|[{0}]", ex.Message);

            }
            return "nothing";
        }


        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/



        public DataSet dsExcelSheetGet()
        {
            try
            {
                DataTable dt = Model.lclExcel.dtExcelSheetGet(@"Book2.xlsx");
                DataSet ds = new DataSet(String.Format("{0}_{1}", "dsExcelSheetGet", DateTime.Now));
                ds.Tables.Add(dt.Copy());
                return ds;
            }
            catch (Exception ex)
            {
                new XRAY.clientXRAY().Error(System.Reflection.MethodBase.GetCurrentMethod(), ex.Source, ex);
                return new DataSet(ex.Message);
            }
        }

        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/


        //public string checkUser(string userName, string password)
        //{
        //    if (userName == null || password == null) { userName = "Test"; password = "tttt"; }

        //    Validation v = new Validation();

        //    v.Validate(userName, password);

        //    return "If no exception were thrown, you are in!";
        //}


        public string ttt(string pass, string w)
        {
            Console.WriteLine(w);
            Console.WriteLine(pass);
            return "smth";
        }

        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/

        public string ValidatePOST(string userName, string password)
        {
            Console.WriteLine("ValidatePOST : u[{0}] p[{1}]", userName, password);

            Validation2 V2 = new Validation2();

            return V2.ValidateT(userName, password);
        }


        /*******************************************************************************************************************\
         *                                                                                                                  *
        \*******************************************************************************************************************/


        public string Version()
        {         
            return Gapp.Gap.AssemblyVersion();
        }

    }

}