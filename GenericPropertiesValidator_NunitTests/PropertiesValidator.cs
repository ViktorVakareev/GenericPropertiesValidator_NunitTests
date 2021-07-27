using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace ObjectsInfo
{
    public class PropertiesValidator<K, T> where T : new() where K : new()
    {
        private static K instance;
        public static K Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new K();
                }
                return instance;
            }
        }
        public void Validate(T expectedObject, T realObject, params string[] propertiesNotToCompare)
        {
            PropertyInfo[] properties = realObject.GetType().GetProperties();
            foreach (PropertyInfo currentRealProperty in properties)
            {
                if (!propertiesNotToCompare.Contains(currentRealProperty.Name))
                {
                    PropertyInfo currentExpectedProperty = expectedObject.GetType().GetProperty(currentRealProperty.Name);
                    string exceptionMessage =
                    string.Format("The property {0} of class {1} was not as expected.", currentRealProperty.Name, currentRealProperty.DeclaringType.Name);
                    if (currentRealProperty.PropertyType != typeof(DateTime) && currentRealProperty.PropertyType != typeof(DateTime?))
                    {
                        Assert.AreEqual(currentExpectedProperty.GetValue(expectedObject, null), currentRealProperty.GetValue(realObject, null), exceptionMessage);
                    }
                    else
                    {
                        DateTimeAssert.AreEqual(
                        currentExpectedProperty.GetValue(expectedObject, null) as DateTime?,
                        currentRealProperty.GetValue(realObject, null) as DateTime?,
                        DateTimeDeltaType.Minutes,
                        TimeSpan.FromSeconds(10));
                    }
                }
            }
        }
    }
}
