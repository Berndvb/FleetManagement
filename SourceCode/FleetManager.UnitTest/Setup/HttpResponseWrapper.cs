using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Setup
{
    public class HttpResponseWrapper<T, Y>
    {
        public HttpResponseMessage ResponseMessage { get; }
        public T ParsedResponse { get; }
        public Y ErrorResponse { get; }

        public HttpResponseWrapper(HttpResponseMessage responseMessage, T parsedResponse, Y errorResponse)
        {
            ResponseMessage = responseMessage;
            ParsedResponse = parsedResponse;
            ErrorResponse = errorResponse;
        }
    }
}
