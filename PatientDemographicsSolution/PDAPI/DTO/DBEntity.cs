using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PDAPI.DTO
{
    //DBOperation implmentation
    public partial class DBEntity : IEntity
    {
        PatientDemographicsEntities p;
        public DBEntity()
        {
            p = new PatientDemographicsEntities();
        }

        //Listing all the Persons
        public IQueryable<PersonData> GetList()
        {
            //return p.PersonDatas.ToList();
            return p.PersonDatas.AsQueryable<PersonData>();
        }

        //Adding the new Person to the DB
        public int Add(PersonData data)
        {
           PersonData pd = p.PersonDatas.Add(data);
            if (pd != null)
                return 1;
            return 0;
        }

        //T0 Update the state of the existing entity that going to be modified
        public void Update(PersonData data)
        {
            p.Entry(data).State = EntityState.Modified;
        }

        //Commiting the Modification to the DB
        public int SaveChanges()
        {
            return p.SaveChanges();
        }
    }
}