using System.Net;
using System.Text.Json;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using lab3.Database.Entities;
using lab3.Services;

namespace CdvAzure.Functions
{
    public class AddressesFn
    {
        private readonly ILogger _logger;
        private readonly DatabaseAddressesService addressesService;

        public AddressesFn(ILoggerFactory loggerFactory, DatabaseAddressesService addressesService)
        {
            _logger = loggerFactory.CreateLogger<PeopleFn>();
            this.addressesService = addressesService;
        }

        [Function("AddressesFn")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "delete", "put")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            switch (req.Method){
                case "POST":
                    StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var address = JsonSerializer.Deserialize<Address>(json);
                    var res = addressesService.AddAddress(address);
                    response.WriteAsJsonAsync(res);
                    break;
                case "PUT":
                    StreamReader put_reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var put_json = put_reader.ReadToEnd();
                    var put_address = JsonSerializer.Deserialize<Address>(put_json);
                    break;
                case "GET":
                    var people = addressesService.GetAddresses();
                    response.WriteAsJsonAsync(people);
                    break;
                case "DELETE":
                    StreamReader delete_reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var delete_json = delete_reader.ReadToEnd();
                    var delete_address = JsonSerializer.Deserialize<Address>(delete_json);
                    break;
            }

            return response;
        }
    }
}