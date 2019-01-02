using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientDemographicsUI.Model
{
    public class Person
    {
        public string Forname { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}