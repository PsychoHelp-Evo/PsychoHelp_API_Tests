using Microsoft.AspNetCore.Mvc.Testing;
using PsychoHelp_API;
using PsychoHelp_API.Publications.Resources;
using SpecFlow.Internal.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace PsychoHelp_API_Tests
{
    [Binding]
    public class PublicationServiceTestSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;

        private ConfiguredTaskAwaitable<HttpResponseMessage> Response { get; set; }


        public PublicationServiceTestSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/publications is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPublicationsIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/publications");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }

        [When(@"A Publication Request is sent")]
        public void WhenAPublicationRequestIsSent(Table savePublicationResource)
        {
            var resource = savePublicationResource.CreateSet<SavePublicationResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Response with Status (.*) is received for the publication")]
        public void ThenAResponseWithStatusIsReceivedForThePublication(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}