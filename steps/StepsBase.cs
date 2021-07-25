using System.Configuration;
using Microsoft.Extensions.Configuration;
using karthickSpecflowCourse_linux_gl.models;

namespace karthickSpecflowCourse_linux_gl.steps
{
    public class StepsBase
    {
        protected IConfiguration config;
        protected Bag _bag;

        public StepsBase(){
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _bag = new Bag();
        }
    }
}