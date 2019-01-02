namespace BusinessModels
{
    public enum ResponseStatus
    {
        Success=1,
        Fail =0,
        Error=-1
    }
    //This model is used to return the result from the Web API 
    public class ResponseResult
    {
        public object ReturnResult { get; set; }
        public string Message { get; set; }
        public ResponseStatus status { get; set; }
    }
}
