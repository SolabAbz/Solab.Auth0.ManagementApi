using NUnit.Framework;
using Solab.Auth0.ManagementApi;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class Settings
    {
        public String TestGroupId { get; set; }
        public String ApiUrl { get; set; }
        public String Auth0Domain { get; set; }
        public String Auth0ClientId { get; set; }
        public String Auth0ClientSecret { get; set; }
    }

    [TestFixture]
    public class Auth0AuthenticationApiClientTests
    {
        Auth0AuthenticationApiClient sut;

        [SetUp]
        public async Task SetUpAsync()
        {
            //sut = new Auth0AuthenticationApiClient(apiUrl, token);
        }

    }
}
