using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsInfo
{
    public class ObjectToAssertValidator : PropertiesValidator<ObjectToAssertValidator, ObjectToAssert>
    {
        public void Validate(ObjectToAssert expected, ObjectToAssert actual)
        {
            this.Validate(expected, actual, "FirstName");
        }
    }
}
