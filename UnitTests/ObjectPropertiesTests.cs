using NUnit.Framework;
using ObjectsInfo;
using System;

namespace GenericPropertiesValidator_NunitTests
{
    public class ObjectPropertiesTests
    {
        ObjectToAssert expectedObject;
        ObjectToAssert actualObject;

        [SetUp]
        public void Setup()
        {
            expectedObject = new ObjectToAssert()
            {
                FirstName = "Victor",
                PoNumber = "TestPONumber",
                LastName = "Vakareev",
                Price = 10.3M,
                SkipDateTime = new DateTime(1981, 07, 22)
            };
            actualObject = new ObjectToAssert()
            {
                FirstName = "Victor",
                PoNumber = "TestPONumber",
                LastName = "Vakareev",
                Price = 10.3M,
                SkipDateTime = new DateTime(1981, 07, 22)
            };
        }

        [Test]
        public void CheckEveryObjectPropertyOneAtATime()
        {

            Assert.AreEqual(expectedObject.FirstName, actualObject.FirstName, "The first name was not as expected.");
            Assert.AreEqual(expectedObject.LastName, actualObject.LastName, "The last name was not as expected.");
            Assert.AreEqual(expectedObject.PoNumber, actualObject.PoNumber, "The PO Number was not as expected.");
            Assert.AreEqual(expectedObject.Price, actualObject.Price, "The price was not as expected.");
            DateTimeAssert.AreEqual(
            expectedObject.SkipDateTime,
            actualObject.SkipDateTime,
            DateTimeDeltaType.Days, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void CheckObjectUsingGenericPropertieValidator()
        {

            ObjectToAssertValidator.Instance.Validate(expectedObject, actualObject);

        }
    }
}