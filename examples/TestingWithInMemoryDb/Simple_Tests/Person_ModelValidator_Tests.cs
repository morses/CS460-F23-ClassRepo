using Simple.Models;

namespace Simple_Tests
{
    public class Person_ModelValidator_Tests
    {
        [TestCase("541-838-8480")]
        [TestCase("432-845-7777")]
        [TestCase("8237394456")]
        [TestCase("534-5490874")]
        public void Person_TenDigitPhoneNumbers_AreValid(string number)
        {
            // Arrange
            Person person = new Person { Id = 1, PhoneNumber = number };

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.That(mv.Valid, Is.True);
        }

        [TestCase("838-8480")]
        [TestCase("845-7777")]
        [TestCase("7394456")]
        [TestCase("5490874")]
        public void Person_SixDigitPhoneNumbers_AreValid(string number)
        {
            // Arrange
            Person person = new Person { Id = 1, PhoneNumber = number };

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.That(mv.Valid, Is.True);
        }

        [TestCase("+15418388480")]
        [TestCase("+15418388480")]
        [TestCase("+442012341234")]
        [TestCase("+37060112345")]
        [TestCase("+49-89-636-48018")]
        [TestCase("+880 1712 345 678")]
        public void Person_InternationalPhoneNumbers_AreValid(string number)
        {
            // Arrange
            Person person = new Person { Id = 1, PhoneNumber = number };

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.That(mv.Valid, Is.True);
        }

        [TestCase("044-555-6666")]
        [TestCase("144-555-6666")]
        [TestCase("444-055-6666")]
        [TestCase("444-155-6666")]
        public void Person_USDomesticPhoneNumberWithInvalidAreaAndCentralOfficeCodes_AreInvalid(string number)
        {
            // Arrange
            Person person = new Person { Id = 1, PhoneNumber = number };

            // Act
            ModelValidator mv = new ModelValidator(person);

            // Assert
            Assert.That(mv.Valid, Is.False);
        }
    }
}
