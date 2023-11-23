using System.IO;
using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CdvAzure.Functions
{
    public class PeopleFn
    {
        private readonly ILogger<PeopleFn> _logger;
        private readonly PeopleService _peopleService;

        public PeopleFn(ILoggerFactory loggerFactory, PeopleService peopleService)
        {
            _logger = loggerFactory.CreateLogger<PeopleFn>();
            _peopleService = peopleService;
        }

        [Function("PeopleFn")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", "put", "delete")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            switch (req.Method)
            {
                case "POST":
                    using (var reader = new StreamReader(req.Body))
                    {
                        var json = reader.ReadToEnd();
                        var person = JsonSerializer.Deserialize<Person>(json);
                        var addedPerson = _peopleService.Add(person.FirstName, person.LastName);
                        response.WriteAsJsonAsync(addedPerson);
                    }
                    break;
                case "PUT":
                    using (var reader = new StreamReader(req.Body))
                    {
                        var json = reader.ReadToEnd();
                        var updatedPerson = JsonSerializer.Deserialize<Person>(json);
                        var updated = _peopleService.Update(updatedPerson.Id, updatedPerson.FirstName, updatedPerson.LastName);
                        response.WriteAsJsonAsync(updated);
                    }
                    break;
                case "GET":
                    var people = _peopleService.Get();
                    response.WriteAsJsonAsync(people);
                    break;
                case "DELETE":
                    using (var reader = new StreamReader(req.Body))
                    {
                        var json = reader.ReadToEnd();
                        var personToDelete = JsonSerializer.Deserialize<Person>(json);
                        _peopleService.Delete(personToDelete.Id);
                        response.WriteString("Person deleted successfully");
                    }
                    break;
            }

            return response;
        }
    }
}
