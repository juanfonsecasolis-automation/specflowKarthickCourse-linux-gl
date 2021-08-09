using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace karthickSpecflowCourse_linux_gl.ContractTesting
{
    public class APIClient
    {
        private readonly HttpClient _client;

        public APIClient(string baseUri = null){
            _client = new HttpClient{BaseAddress = new Uri(baseUri ?? "localhost:3000")};
        }

        public EmployeeModel GetEmployeeDetails(string id){
            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, "/employee/"+id);
            request.Headers.Add("Accept","application/json");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase;

            request.Dispose(); // por que se hace un dispose? liberar memoria?
            response.Dispose();

            if(status == HttpStatusCode.OK){
                return !String.IsNullOrEmpty(content)? 
                    JsonConvert.DeserializeObject<EmployeeModel>(content) : null;
            }
            throw new Exception(reasonPhrase);
        }
    }
}