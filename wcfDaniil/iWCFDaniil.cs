using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using System.Data;


namespace wcfDaniil
{
    [ServiceContract]
    public interface iWCFDaniil
    {
        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/

        [OperationContract]

        [WebGet]
        Stream Info();

        [WebGet]
        Stream ShowClientIP();

        [WebGet]
        int GetInfo();

        [WebGet]
        Stream GetPage();

        [WebGet]
        DataSet SampleDS();//

        [WebInvoke(Method = "POST")]
        int PostTest(DataSet ds);//

        [WebGet]
        string Trap(int n);//

        [WebGet]
        string CallMS();//

        [WebGet]
        DataSet dsExcelSheetGet();


        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "PutTestDataMulti")]
        //string ttt(string pass, string w);


        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
        //   ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //   UriTemplate = "ValidatePOST")]

        [WebInvoke(Method = "POST", UriTemplate = "/ValidatePOST?userName={userName}")]
        string ValidatePOST(string userName, string password);

        [WebGet]
        string Version();

        /*******************************************************************************************************************\
         *                                                                                                                 *
        \*******************************************************************************************************************/
    }
}
