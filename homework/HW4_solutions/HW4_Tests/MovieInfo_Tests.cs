using HW4.Services;

namespace HW4_Tests
{
    public class MovieInfo_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2021-03-31", "March 31, 2021")]
        [TestCase("2021-03-01", "March 1, 2021")]
        [TestCase("1970-08-12", "August 12, 1970")]
        [TestCase("1998-12-27", "December 27, 1998")]
        public void TmdbShowService_FormatDate_ABunchOfValidDates_AreConvertedCorrectly(string input, string expectedOutput)
        {
            // Arrange
            // Act
            string actualOutput = TmdbShowService.ConvertDateToHumanReadableForm(input);
            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }

        [Test]
        [TestCase("", "not available")]
        [TestCase("2021-03-31T00:00:00.000Z", "not available")]
        [TestCase("2021-03-31T00:00:00.000", "not available")]
        [TestCase("2021-03-31T00:00:00", "not available")]
        [TestCase("2021-03-31T00:00", "not available")]
        [TestCase("2021-03-31T00", "not available")]
        [TestCase("2021-03-31T", "not available")]
        [TestCase(null, "not available")]
        [TestCase("   ", "not available")]
        [TestCase("---", "not available")]
        [TestCase("March 31, 2021", "not available")]
        public void TmdbShowService_FormatDate_InvalidDate_Returns_NotAvailable(string input, string expectedOutput)
        {
            // Arrange
            // Act
            string actualOutput = TmdbShowService.ConvertDateToHumanReadableForm(input);
            // Assert
            Assert.That(expectedOutput, Is.EqualTo(actualOutput));
        }
    }
}