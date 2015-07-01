using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LobApi.Lob
{

    public class ErrorResponseItem
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "status_code")]            
        public int StatusCode { get; set; }
    }

    internal class ErrorResponse
    {
        [JsonProperty(PropertyName = "error")]
        public ErrorResponseItem Error { get; private set; }
    }
}
