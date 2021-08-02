using System.Net;
using karthickSpecflowCourse_linux_gl.models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace karthickSpecflowCourse_linux_gl.Hooks
{
    public class SharedSettings
    {
        
        public IConfiguration config;
        public HttpStatusCode statusCode;
        public object currentValue;
        public object expectedValue;
        public JObject response;
        
        public SharedSettings(){
            
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}