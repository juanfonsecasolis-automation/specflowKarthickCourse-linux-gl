using System.Collections.Generic;

namespace karthickSpecflowCourse_linux_gl.models
{
    public enum BagItems{
        currentValue,
        expectedValue,
        pokemonID
    }
    public class Bag : Dictionary<BagItems, object>
    {
        
    }
}