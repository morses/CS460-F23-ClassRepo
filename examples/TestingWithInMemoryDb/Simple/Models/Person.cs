

using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    // Class used for showing how to use the ModelValidator helper to test data annotations in model classes
    // This particular example is not used in the Simple app or in the Db but would work just the same
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [Required]
        // Regular expression for a valid phone number, including international numbers
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
    }
}
