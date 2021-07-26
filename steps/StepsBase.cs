using System.Configuration;
using Microsoft.Extensions.Configuration;
using karthickSpecflowCourse_linux_gl.models;
using karthickSpecflowCourse_linux_gl.Hooks;

namespace karthickSpecflowCourse_linux_gl.steps
{
    public class StepsBase
    {
        protected SharedSettings _sharedSettings;

        public StepsBase(SharedSettings sharedSettings){
            _sharedSettings = sharedSettings;
        }
    }
}