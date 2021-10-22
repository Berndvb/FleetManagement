using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Setup
{
    public abstract class AuthenticatedFixture<T> : BaseFixture<T>
           where T : class
    {
        private AuthenticationHeaderValue _authenticationHeaderValue;
        private bool _useApiKeyAuthentication;

        public override async Task<HttpClient> CreateClient()
        {
            ClientOptions.AllowAutoRedirect = false;

            var httpClient = await base.CreateClient();

            return httpClient;
        }
    }
}
