using Newtonsoft.Json;

namespace ReadApi
{
    //klasse voor global error handling, voor details van de errormessage
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
