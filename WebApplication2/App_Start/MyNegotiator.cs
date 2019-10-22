using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WebApplication2.App_Start
{
    public class MyNegotiator : DefaultContentNegotiator
    {
        public override ContentNegotiationResult Negotiate(Type type,
            HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            if (request.Headers.UserAgent.ToString().ToLower().Contains("android"))
            {
                return new ContentNegotiationResult(new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json")
                );
            }

            return base.Negotiate(type, request, formatters);
        }
    }
}