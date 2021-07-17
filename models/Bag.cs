using System.Collections.Generic;

namespace karthickSpecflowCourse_linux_gl.models
{
    public enum Items{
        currentValue,
        expectedValue,
        pokemonID
    }
    public class Bag : Dictionary<Items, string>
    {
        
    }
}