using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.Http
{
    public class DvlDevHttpResponse
    {
        public HttpStatusCode HttpStatusCode { get; init; }
        public string ResponseMessage { get; init; }
        public HttpResponseHeaders HttpResponseHeaders { get; init; }
    }
}
