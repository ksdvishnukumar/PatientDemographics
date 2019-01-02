using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessModels;
using Logger;
using System.Diagnostics;
using PDAPI.DTO;

namespace PDAPI.Controllers
{
    public class PersonOldController : ApiController
    {
        private readonly IDAL dal;

        public PersonOldController(IDAL dalRepostory)
        {
            this.dal = dalRepostory;
        }

        [ActionName("PersonListDetail")]
        public IHttpActionResult Get(int id = 0)
        {
            try
            {
                ResponseResult result;
                result = dal.PersonListDetail(id);
                if (result.status == ResponseStatus.Success)
                {
                    //var message = Request.CreateResponse(HttpStatusCode.Created, personData);
                    //message.Headers.Location = new Uri(Request.RequestUri +"/" + ((PersonData)result.ReturnResult).PID.ToString());
                    return Content(HttpStatusCode.OK, result.ReturnResult);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, result.Message);
                }
            }
            catch (Exception ex)
            {
                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [ActionName("SavePerson")]
        public IHttpActionResult Post([FromBody]Person personData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseResult result;
                    result = dal.PostPerson(personData);
                    if (result.status == ResponseStatus.Success)
                    {
                        //var message = Request.CreateResponse(HttpStatusCode.Created, personData);
                        //message.Headers.Location = new Uri(Request.RequestUri +"/" + ((PersonData)result.ReturnResult).PID.ToString());
                        return Content(HttpStatusCode.Created, result.Message);
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, result.Message);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Model Validation failure");
                }
            }
            catch (Exception ex)
            {
                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [ActionName("UpdatePerson")]
        public IHttpActionResult Put([FromBody]Person personData, [FromUri] int id)
        {
            try
            {
                ResponseResult result;
                result = dal.UpdatePerson(personData, id);
                if (result.status == ResponseStatus.Success)
                {
                    //var message = Request.CreateResponse(HttpStatusCode.Created, personData);
                    //message.Headers.Location = new Uri(Request.RequestUri +"/" + ((PersonData)result.ReturnResult).PID.ToString());
                    return Content(HttpStatusCode.OK, result.Message);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, result.Message);
                }
            }
            catch (Exception ex)
            {
                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
