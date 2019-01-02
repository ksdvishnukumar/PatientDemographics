using System.ComponentModel.DataAnnotations;

namespace BusinessModels
{
    public class ContactNumbers
    {
        [RegularExpression(@"([0-9]+)", ErrorMessage="Must be a Number")]
        [MaxLength(10)]
        [MinLength(0)]
        [DataType(DataType.PhoneNumber)]
        public string HomeNumber { get; set; }


        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number")]
        [MaxLength(10)]
        [MinLength(0)]
        [DataType(DataType.PhoneNumber)]
        public string WorkNumber { get; set; }


        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number")]
        [MaxLength(10)]
        [MinLength(0)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}