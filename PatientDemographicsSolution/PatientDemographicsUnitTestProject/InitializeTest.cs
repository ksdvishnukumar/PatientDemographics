using Effort.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDAPI;
using System;
using System.Collections.Generic;

namespace PatientDemographicsUnitTestProject.Test
{
    public class InitializeTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            //EffortProviderConfiguration.RegisterProvider();
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            //EffortProviderFactory.ResetDb();
        }

        public static List<PersonData> TestData()
        {
            List<PersonData> lst = new List<PersonData>();
            var personData1 = new PersonData
            {
                PID = 1,
                PersonXML = "<?xml version='1.0' encoding='utf - 16'?>  <Person xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>    <Forename>Vishnu</Forename>    <Surname>K S D</Surname>    <DOB>12/13/2018</DOB>    <Gender>Male</Gender>    <TelephoneNumbers>      <HomeNumber>9886635089</HomeNumber>      <WorkNumber>9886635090</WorkNumber>      <PhoneNumber>9886635091</PhoneNumber>    </TelephoneNumbers>  </Person>",
                CreatedDate = Convert.ToDateTime("2018-12-12"),
                UpdatedDate = Convert.ToDateTime("2018-12-13")
            };
            lst.Add(personData1);

            var personData2 = new PersonData
            {
                PID = 2,
                PersonXML = "<?xml version='1.0' encoding='utf - 16'?>  <Person xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>    <Forename>Vijayalakshmi</Forename>    <Surname>K S D</Surname>    <DOB>02/10/1990</DOB>    <Gender>Female</Gender>    <TelephoneNumbers>      <HomeNumber>9875842761</HomeNumber>      <WorkNumber>9875842762</WorkNumber>      <PhoneNumber />    </TelephoneNumbers>  </Person>",
                CreatedDate = Convert.ToDateTime("2018-12-11"),
                UpdatedDate = Convert.ToDateTime("2018-12-12")

            };
            lst.Add(personData2);

            var personData3 = new PersonData
            {
                PID = 3,
                PersonXML = "<?xml version='1.0' encoding='utf - 16'?>  <Person xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>    <Forename>Swetha</Forename>    <Surname>Ritha</Surname>    <DOB>03/07/1995</DOB>    <Gender>Female</Gender>    <TelephoneNumbers>      <HomeNumber>9987562480</HomeNumber>      <WorkNumber>9987562480</WorkNumber>      <PhoneNumber />9987562480</TelephoneNumbers>  </Person>",
                CreatedDate = Convert.ToDateTime("2018-11-23"),
                UpdatedDate = Convert.ToDateTime("2018-12-12")

            };
            lst.Add(personData3);

            return lst;

            //using (var model = new PatientDemographicsEntities())
            //{
            //    var personData1 = new PersonData {
            //        PID = 1,
            //        PersonXML = "<?xml version='1.0' encoding='utf - 16'?>  <Person xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>    <Forename>Vishnu</Forename>    <Surname>K S D</Surname>    <DOB>12/13/2018</DOB>    <Gender>Male</Gender>    <TelephoneNumbers>      <HomeNumber>9886635089</HomeNumber>      <WorkNumber>9886635090</WorkNumber>      <PhoneNumber>9886635091</PhoneNumber>    </TelephoneNumbers>  </Person>",
            //        CreatedDate = Convert.ToDateTime("2018-12-12"),
            //        UpdatedDate =Convert.ToDateTime("2018-12-13")
            //    };

            //    var personData2 = new PersonData
            //    {
            //        PID = 2,
            //        PersonXML = "<?xml version='1.0' encoding='utf - 16'?>  <Person xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>    <Forename>Vijayalakshmi</Forename>    <Surname>K S D</Surname>    <DOB>02/10/1990</DOB>    <Gender>Female</Gender>    <TelephoneNumbers>      <HomeNumber>9875842761</HomeNumber>      <WorkNumber>9875842762</WorkNumber>      <PhoneNumber />    </TelephoneNumbers>  </Person>",
            //        CreatedDate = Convert.ToDateTime("2018-12-11"),
            //        UpdatedDate = Convert.ToDateTime("2018-12-12")

            //    };

            //    //category.Products.Add(new Product()
            //    //{ Name = "Notepad", Category = category, Price = 10.0 });
            //    //category.Products.Add(new Product()
            //    //{ Name = "Pencil", Category = category, Price = 4.0 });
            //    //category.Products.Add(new Product()
            //    //{ Name = "Pen", Category = category, Price = 6.0 });
            //    //otherCategory.Products.Add(new Product()
            //    //{ Name = "Pear", Category = otherCategory, Price = 2.0 });

            //    model.PersonDatas.Add(personData1);
            //    model.PersonDatas.Add(personData2);
            //    model.SaveChanges();
            //}
        }
    }
}
