using System.IO;
using System.Net;
using karthickSpecflowCourse_linux_gl.models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace karthickSpecflowCourse_linux_gl.Hooks
{
    public class SharedSettings
    {
        private const string testDataFileName = "testdata.txt";
        public IConfiguration config;
        public HttpStatusCode statusCode;
        public object currentValue;
        public object expectedValue;
        public JObject response;
        
        public int lastCreatedReqresId {
            set{
                File.WriteAllLines(testDataFileName, new string[]{ value.ToString() });
            }
            get{ 
                int value = int.Parse(File.ReadAllText(testDataFileName)); 
                TestContext.WriteLine($"Recovered '{value}' from {testDataFileName}");
                return value;
            }
        }

        public string reqresUrl { get{ return config["reqresUrl"]; } }

        public SharedSettings(){
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}