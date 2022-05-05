using Microsoft.AspNetCore.Mvc.Testing;
using PsychoHelp_API;
using PsychoHelp_API.Appointments.Resources;
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

namespace PsychoHelp_API_Tests.Appointment
{
    [Binding]
    public class AppointmentServiceTestSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;

        private ConfiguredTaskAwaitable<HttpResponseMessage> Response { get; set; }

        public AppointmentServiceTestSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/appointment is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAppointmentIsAvailable(int port, int version)
        {
            _baseUri = new Uri($"https://localhost:{port}/api/v{version}/appointment");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }

        [When(@"A Appointment Request is sent")]
        public void WhenAAppointmentRequestIsSent(Table saveAppointmentResource)
        {
            var resource = saveAppointmentResource.CreateSet<SaveAppointmentResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Response with Status (.*) is received for the appointment")]
        public void ThenAResponseWithStatusIsReceivedForTheAppointment(int expectedStatus)
        {
            HttpStatusCode statusCode = (HttpStatusCode)expectedStatus;
            Assert.Equal(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }
    }
}