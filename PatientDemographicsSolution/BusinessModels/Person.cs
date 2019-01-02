using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessModels
{
    //This model is used to pass the data from the UI to Web API for POST and PUT Operation
    public class Person
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Forename { get; set; }


        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string DOB { get; set; }


        [Required]
        public string Gender { get; set; }


        public ContactNumbers TelephoneNumbers { get; set; }
    }
}
