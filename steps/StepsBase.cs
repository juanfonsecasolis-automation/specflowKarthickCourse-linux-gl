using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace karthickSpecflowCourse_linux_gl.steps
{
    public class StepsBase
    {
        protected IConfiguration config;

        public StepsBase(){
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}