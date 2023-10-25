using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.ReferenceParser.Options;

namespace WebApiParser.ReferenceParser
{
    public class AuthorizationReferencesMessageHandler : DelegatingHandler
    {
        private readonly IOptions<ReferenceApiOption> _options;
        public AuthorizationReferencesMessageHandler(IOptions<ReferenceApiOption> options)
        {
            _options = options;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancelToken)
        {
            if (request.Headers.Authorization == null)
                request.Headers.Authorization = new AuthenticationHeaderValue(_options.Value.AuthorizationScheme, _options.Value.Token);
            return await base.SendAsync(request, cancelToken);
        }
    }
}
