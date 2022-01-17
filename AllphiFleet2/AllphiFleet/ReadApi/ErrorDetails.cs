using Newtonsoft.Json;

namespace ReadApi
{
    //global error handling class, for details of the errormessage
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
