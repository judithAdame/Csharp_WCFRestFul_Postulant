using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFRestFul_Postulant
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/postulants/{id}",
                    //BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        Postulant GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/postulants",
                   // BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        List<Postulant> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/postulants/nbMatch/{nbMatch}/langages/{lPostes}",
            //BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]        
        List<Postulant> GetByLangages(string nbMatch, string lPostes);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "/postulants/count",
                    //BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        int Count();

        [OperationContract]
        [WebInvoke(Method = "POST",
                    UriTemplate = "/postulants",
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        void Add(Postulant postulant);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/postulants/{id}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/postulants/{id}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void Update(string id, Postulant postulant);
    }
}
