namespace BusinessModels
{
    //This model is used to retrive the data from teh DB / In Memory source to UI
    public class CompletePerson
    {
        public int PID { get; set; }
        public Person PersomXML { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
    }
}
