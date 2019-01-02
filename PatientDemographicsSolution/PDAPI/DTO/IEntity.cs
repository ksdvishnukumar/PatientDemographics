using System.Collections.Generic;
using System.Linq;

namespace PDAPI.DTO
{
    //This Interface is inherited by Both InMemoryEntity and DBEntity to remove the dependancy from the DBAccess layer.
    public interface IEntity
    {
        IQueryable<PersonData> GetList();
        int Add(PersonData p);        
        void Update(PersonData p);
        int SaveChanges();
    }
}
