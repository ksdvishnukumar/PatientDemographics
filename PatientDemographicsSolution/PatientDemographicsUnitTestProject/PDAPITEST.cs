using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDAPI;
using BusinessModels;
using System.Collections.Generic;
using PDAPI.DTO;
using PDAPI.Controllers;
using System.Web.Http.Results;
using System.Threading;
using System.Net;
using Moq;
using System.Net.Http;
using System.Web.Http;

namespace PatientDemographicsUnitTestProject.Test
{
    [TestClass]
    public class PDAPITEST
    {
        //Declaration Section
        int input, expected;
        string expectedMessage = string.Empty;
        CompletePerson cp;
        PersonData c;
        List<PersonData> lst;
        List<CompletePerson> list;
        PersonController personController;
        Mock<InMemoryEntity> entity;
        HttpResponseMessage responseMessage;

        [TestMethod]
        public void Get_ShouldReturnNumberOfPersonData()
        {
            // Arrange
            //Call this method to seed the test data and to create a instance of Mock Object of In Memory Entity
            Setup();
            expected = 3;

            //Act
            //Calling Web Api HTTP Get Action Method
            var httpResult = personController.Get();
            //Converting the httpresult to Content Result
            var conNegResult = httpResult as NegotiatedContentResult<object>;
            //Casting the Content of Content Result to Target Object
            list = ((List<CompletePerson>)conNegResult.Content);

            //Assert
            Assert.AreEqual(expected, lst.Count);
        }

        [TestMethod]
        public void Get_ShouldReturnPersonDataByID()
        {
            // Arrange
            //Call this method to seed the test data and to create a instance of Mock Object of In Memory Entity
            Setup();
            input = 1;
            expected = 1;

            //Act
            //Calling Web Api HTTP Get Action Method by passing the ID
            var httpResult = personController.Get(input);
            //Converting the httpresult to Content Result
            var conNegResult = httpResult as NegotiatedContentResult<object>;
            //Casting the Content of Content Result to Target Object
            cp = (CompletePerson)conNegResult.Content;

            //Assert
            Assert.AreEqual(1, cp.PID);
        }

        [TestMethod]
        public void Get_ShouldReturnPersonDataByIDWhichisNotAvailable()
        {
            // Arrange
            //Call this method to seed the test data and to create a instance of Mock Object of In Memory Entity
            Setup();
            input = 10;
            expectedMessage = "No record found";

            //Act
            //Calling Web Api HTTP Get Action Method by passing the ID which is not present
            var httpResult = personController.Get(input);
            //Converting the httpresult to Content Result
            var conNegResult = httpResult as NegotiatedContentResult<object>;

            //Assert
            Assert.IsNull(conNegResult);
        }


        [TestMethod]
        public void Post_NewPersonData()
        {
            // Arrange
            //Call this method to seed the test data and to create a instance of Mock Object of In Memory Entity
            Setup();
            //Creating the New Person object to Post the object to the Test Data Collection
            Person p = postPerson();

            //Act
            //Calling Web Api HTTP Post Action Method by passing the New Person Object
            var httpResult = personController.Post(p);
            //Getting the Response Message from the HttpResult
            responseMessage = httpResult.ExecuteAsync(CancellationToken.None).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, responseMessage.StatusCode);
        }

        [TestMethod]
        public void Update_PersonData()
        {
            // Arrange
            //Call this method to seed the test data and to create a instance of Mock Object of In Memory Entity
            Setup();
            //Creating the New Person object to Update the object to the Test Data Collection
            Person p = updatePerson();

            //Act
            //Calling Web Api HTTP Put Action Method by passing the New Person Object
            var httpResult = personController.Put(p, 2);
            //Getting the Response Message from the HttpResult
            responseMessage = httpResult.ExecuteAsync(CancellationToken.None).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        private void Setup()
        {
            //Create a Mock object of InMemory Entity and injecting to Web APi Controller using Moq Library
            
            //Creating the Test Data
            lst = InitializeTest.TestData();
            //Creating the Mock InMemory Entity Object
            entity = new Mock<InMemoryEntity>();
            //Loading the Test data to In Memory Object
            entity.Object.LoadTestData(lst);
            //Injecting to Mock Object which is type of IEntity to Web APi Controller
            personController = new PersonController(entity.Object);
            //Request and Configuration need to set to the Controller other wise Update and Post Http Call will fail
            personController.Request = new HttpRequestMessage();
            personController.Configuration = new HttpConfiguration();
        }

        private Person postPerson()
        {
            return new Person
            {
                Forename = "Vijayalakshmi",
                Surname = "K S D",
                Gender = "Female",
                DOB = "02/10/1990",
                TelephoneNumbers = new ContactNumbers
                {
                    HomeNumber = "9739269031",
                    WorkNumber = "9739269031",
                    PhoneNumber = "9739269031"
                }
            };
        }

        private Person updatePerson()
        {
            return new Person
            {
                Forename = "Arun",
                Surname = "Kumar",
                Gender = "Male",
                DOB = "05/12/1990",
                TelephoneNumbers = new ContactNumbers
                {
                    HomeNumber = "9739269032",
                    WorkNumber = "9739269032",
                    PhoneNumber = "9739269032"
                }
            };
        }
    }
}
