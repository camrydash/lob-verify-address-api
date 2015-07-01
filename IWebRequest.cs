using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobApi
{
    internal enum HttpVerb
    {
        Get,
        Post
    }

    internal interface IWebRequest
    {
        HttpVerb Method { get; }
        string Url { get; }
        IDictionary<string, string> Headers { get; }
        string Response { get; }
    }
}
