using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobApi
{
    internal class WebRequestFactory
    {
        internal static DefaultWebRequest PostRequest(string url, string queryString, string tokenKey)
        {
            return new DefaultWebRequest(url, queryString, HttpVerb.Post, tokenKey);
        }
    }
}
