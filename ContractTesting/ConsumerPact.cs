using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace karthickSpecflowCourse_linux_gl.ContractTesting
{
    public class ConsumerPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService {get; private set;}

        public int MockServerPort { 
            get { return 3000; }
        }
        public string MockProviderServiceBaseUri {
            get{
                return string.Format("http://localhost:{0}", MockServerPort);
            }
        }

        public ConsumerPact(){
            var pactConfig = new PactConfig{
                SpecificationVersion = "2.0.0",
                PactDir = @"ContractTesting/Pacts",
                LogDir = @"ContractTesting/logs"
            };
            PactBuilder = new PactBuilder(pactConfig);
            PactBuilder.ServiceConsumer("Service_Consumer").HasPactWith("EmployeeList");

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose(){
            PactBuilder.Build();
        }
    }
}