using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDAPI;
using BusinessModels;
using System.Collections.Generic;
using PDAPI.DTO;
using PDAPI.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Results;
using System.Threading;
using System.Net;

namespace PatientDemographicsUnitTestProject.Test
{
    [TestClass]
    public class PDAPITESTOLD
    {
        ////Declaration Section
        //DBAccess obj = null;
        //int input, expected;
        //string expectedMessage = string.Empty;
        //PersonController ctrlr;
        //ResponseResult rr;
        //CompletePerson cp;
        //PersonData c;
        //List<CompletePerson> lst;
        //HttpResponseMessage responseMessage;

        //[TestMethod]
        //public void Get_ShouldReturnNumberOfPersonData()
        //{
        //    //Call this method to seed the test data and to create a instance of the DB AccessLogic
        //    Setup();

        //    expected = 3;

        //    //Act
        //    //To get all the person list
        //    //List<CompletePerson> lst = (List<CompletePerson>)result.ReturnResult;
        //    var httpResult = ctrlr.Get();
        //    var conNegResult = httpResult as NegotiatedContentResult<object>;
        //    lst = (List<CompletePerson>)conNegResult.Content;

        //    //Assert
        //    Assert.AreEqual(expected, lst.Count);
        //}

        //[TestMethod]
        //public void Get_ShouldReturnPersonDataByID()
        //{
        //    // Arrange
        //    //Call this method to seed the test data and to create a instance of the DB AccessLogic
        //    Setup();

        //    input = 1;
        //    expected = 1;

        //    //Act
        //    //To get person data By ID            
        //    var httpResult = ctrlr.Get(input);
        //    var conNegResult = httpResult as NegotiatedContentResult<object>;
        //    cp = (CompletePerson)conNegResult.Content;

        //    //Assert
        //    Assert.AreEqual(1, cp.PID);
        //}

        //[TestMethod]
        //public void Get_ShouldReturnPersonDataByIDWhichisNotAvailable()
        //{
        //    // Arrange
        //    //Call this method to seed the test data and to create a instance of the DB AccessLogic
        //    Setup();

        //    input = 10;
        //    expectedMessage = "No record found";

        //    //Act
        //    //To get all the person list
        //    var httpResult = ctrlr.Get(input);
        //    var conNegResult = httpResult as NegotiatedContentResult<object>;

        //    //Assert
        //    Assert.IsNull(conNegResult);
        //}


        //[TestMethod]
        //public void Post_NewPersonData()
        //{
        //    // Arrange
        //    //Call this method to seed the test data and to create a instance of the DB AccessLogic
        //    Setup();

        //    Person p = postPerson();

        //    //Act
        //    //To create a new person
        //    var httpResult = ctrlr.Post(p);
        //    responseMessage = httpResult.ExecuteAsync(CancellationToken.None).Result;

        //    //Assert
        //    Assert.AreEqual(HttpStatusCode.Created, responseMessage.StatusCode);
        //}

        //[TestMethod]
        //public void Update_PersonData()
        //{
        //    // Arrange
        //    //Call this method to seed the test data and to create a instance of the DB AccessLogic
        //    Setup();

        //    Person p = updatePerson();

        //    //Act
        //    //To create a new person to update subsequently
        //    var httpResult = ctrlr.Put(p, 2);
        //    responseMessage = httpResult.ExecuteAsync(CancellationToken.None).Result;


        //    //Assert
        //    Assert.AreEqual(HttpStatusCode.OK, responseMessage.StatusCode);
        //}

        //private void Setup()
        //{
        //    //Create a object of InMemory Entity
        //    //obj = new DBAccess(EntityType.InMemory, InitializeTest.TestData());

        //    IEntity inMemoryEntity = new InMemoryEntity(InitializeTest.TestData());
        //    IDAL mockDAL = new DBAccess(inMemoryEntity);
        //    ctrlr = new PersonController(mockDAL);
        //    ctrlr.Request = new HttpRequestMessage();
        //    ctrlr.Configuration = new HttpConfiguration();
        //}

        //private Person postPerson()
        //{
        //    return new Person
        //    {
        //        Forename = "Vijayalakshmi",
        //        Surname = "K S D",
        //        Gender = "Female",
        //        DOB = "02/10/1990",
        //        TelephoneNumbers = new ContactNumbers
        //        {
        //            HomeNumber = "9739269031",
        //            WorkNumber = "9739269031",
        //            PhoneNumber = "9739269031"
        //        }
        //    };
        //}

        //private Person updatePerson()
        //{
        //    return new Person
        //    {
        //        Forename = "Arun",
        //        Surname = "Kumar",
        //        Gender = "Male",
        //        DOB = "05/12/1990",
        //        TelephoneNumbers = new ContactNumbers
        //        {
        //            HomeNumber = "9739269032",
        //            WorkNumber = "9739269032",
        //            PhoneNumber = "9739269032"
        //        }
        //    };
        //}
    }
}
