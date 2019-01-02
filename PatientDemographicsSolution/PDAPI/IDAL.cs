using BusinessModels;

namespace PDAPI
{
    public interface IDAL
    {
        ResponseResult PostPerson(Person person);
        ResponseResult PersonListDetail(int PID = 0);
        ResponseResult UpdatePerson(Person person, int id);
    }
}
