using BusinessModels;
using Logger;
using PDAPI.DTO;
using PDAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PDAPI
{
    public class DBAccessOLD : IDAL
    {
        //private IEntity context;
        //By Deafult its uses the DBEntity to connect to DB.
        //public DBAccess()
        //{
        //    context = EntityCreation.GetEntity(EntityType.DB);
        //}

        ////Creating the Entity Type to support the multiple data sources.
        //public DBAccess(EntityType eType, List<PersonData> lst = null)
        //{
        //    context = EntityCreation.GetEntity(eType, lst);
        //}

        private readonly IEntity context;

        public DBAccessOLD(IEntity entityContext)
        {
            this.context = entityContext;
        }

        //This method is used to List out all the Person details if Id passed as 0 or no Paramater passed. 
        //If its passed >0 then it will return the Singlt Person
        public ResponseResult PersonListDetail(int PID = 0)
        {
            ResponseResult r = new ResponseResult();
            try
            {
                List<CompletePerson> cp = new List<CompletePerson>();
                Person p = new Person();
                if (PID == 0)
                {
                    var pds = this.context.GetList();
                    foreach (PersonData item in pds)
                    {
                        //Converts the XML String to .Net objects
                        p = HelperMethods.XMLStringToObject<Person>(item.PersonXML);
                        cp.Add(new CompletePerson
                        {
                            PID = item.PID,
                            PersomXML = p,
                            CreatedDate = item.CreatedDate.ToString("MM/dd/yyyy"),
                            UpdatedDate = item.UpdatedDate?.ToString("MM/dd/yyyy")
                        });
                    }

                    if (cp.Count == 0)
                    {
                        r.ReturnResult = cp;
                        r.Message = "No record found";
                        r.status = ResponseStatus.Fail;
                    }
                    else
                    {
                        r.ReturnResult = cp;
                        r.Message = "Retrived successfully.";
                        r.status = ResponseStatus.Success;
                    }
                }
                else
                {
                    CompletePerson c = null;
                    var pd = context.GetList().SingleOrDefault<PersonData>(req => req.PID == PID);
                    if (pd != null)
                    {
                        //Converts the XML String to .Net objects
                        p = HelperMethods.XMLStringToObject<Person>(pd.PersonXML);
                        c = new CompletePerson
                        {
                            PID = pd.PID,
                            PersomXML = p,
                            CreatedDate = pd.CreatedDate.ToString("MM/dd/yyyy"),
                            UpdatedDate = pd.UpdatedDate?.ToString("MM/dd/yyyy")
                        };
                    }

                    if (c == null)
                    {
                        r.ReturnResult = c;
                        r.Message = "No record found";
                        r.status = ResponseStatus.Fail;
                        LogFactory.Log(LogType.Error, LogMode.TextFile, "No record found.");
                    }
                    else
                    {
                        r.ReturnResult = c;
                        r.Message = "Retrived successfully.";
                        r.status = ResponseStatus.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                r.ReturnResult = null;
                r.Message = "Bad Request / Internal Server error.";
                r.status = ResponseStatus.Error;

                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
            }
            return r;
        }

        //This method is used to Create a new Person
        public ResponseResult PostPerson(Person p)
        {
            ResponseResult r = new ResponseResult();
            int result = 0;
            try
            {
                PersonData pd = new PersonData()
                {
                    //Converts the .Net objects to XML String
                    PersonXML = HelperMethods.ObjectToXMLString<Person>(p),
                    CreatedDate = DateTime.Now
                };

                if (context.Add(pd) == 1)
                {
                    result = context.SaveChanges();
                    if (result == 1)
                    {
                        r.ReturnResult = pd;
                        r.Message = "Inserted successfully.";
                        r.status = ResponseStatus.Success;
                    }
                    else
                    {
                        r.ReturnResult = pd;
                        r.Message = "Fail to insert.";
                        r.status = ResponseStatus.Fail;
                    }
                }
                else
                {
                    r.ReturnResult = pd;
                    r.Message = "Fail to insert.";
                    r.status = ResponseStatus.Fail;
                }
            }
            catch (Exception ex)
            {
                r.ReturnResult = null;
                r.Message = "Bad Request / Internal Server error.";
                r.status = ResponseStatus.Error;

                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
            }
            return r;
        }

        //The below method is used to Update the existing person
        public ResponseResult UpdatePerson(Person p, int id)
        {
            ResponseResult r = new ResponseResult();
            int result = 0;
            try
            {
                var pdet = context.GetList().SingleOrDefault<PersonData>(req => req.PID == id);
                //Converts the .net Object to XML String
                pdet.PersonXML = HelperMethods.ObjectToXMLString<Person>(p);
                pdet.UpdatedDate = DateTime.Now;
                context.Update(pdet);
                result = context.SaveChanges();
                if (result == 1)
                {
                    r.ReturnResult = pdet;
                    r.Message = "Updated successfully.";
                    r.status = ResponseStatus.Success;
                }
                else
                {
                    r.ReturnResult = pdet;
                    r.Message = "Failed to update.";
                    r.status = ResponseStatus.Fail;
                }
            }
            catch (Exception ex)
            {
                r.ReturnResult = null;
                r.Message = "Bad Request / Internal Server error.";
                r.status = ResponseStatus.Error;

                LogFactory.Log(LogType.Error, LogMode.TextFile, $"{ex.Message} \r\n {new StackTrace(ex, true).GetFrame(0).GetFileLineNumber()}");
            }
            return r;
        }
    }
}