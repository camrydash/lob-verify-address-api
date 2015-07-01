using LobApi.Lob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LobApi
{
    internal class DefaultWebRequest : IWebRequest
    {
        private HttpWebRequest _request;

        public DefaultWebRequest(string url, string queryString, HttpVerb verb)
        {
            Url = url;
            QueryString = queryString;
            Method = verb;         
        }

        public DefaultWebRequest(string url, string queryString, HttpVerb verb, string tokenKey) 
            : this(url, queryString, verb)
        {
            TokenKey = tokenKey;
        }

        private void InitializeParameters()
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            if (Method == HttpVerb.Get)
                Url = string.Concat(Url, "?", QueryString);

            _request = (HttpWebRequest)WebRequest.Create(Url);
            _request.Method = Method.ToString();
            _request.ContentType = "application/json; charset=utf-8";
            _request.Credentials = new NetworkCredential(TokenKey, "");

            if(Headers != null)
            {
                foreach (var kevValuePair in Headers)
                {
                    _request.Headers.Add(kevValuePair.Key, kevValuePair.Value);
                }
            }

            if (Method == HttpVerb.Post)
            {
                using (var stream = _request.GetRequestStream())
                {
                    var bytes = Encoding.ASCII.GetBytes(QueryString);
                    stream.Write(bytes, 0, bytes.Length);
                }
            } 
        }


        public void GetResponse()
        {
            InitializeParameters();

            WebResponse response = null;
            try
            {
                response = (HttpWebResponse)_request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    Response = streamReader.ReadToEnd();
                }
 
            }
            catch(WebException ex)
            {
                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse == null || errorResponse.StatusCode != (HttpStatusCode)422)
                {
                    throw ex;
                }

                using (var sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var data = sr.ReadToEnd();
                    ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(data);
                    throw new ApplicationException(string.Format("Error Code: {0}, Description: {1}", error.Error.StatusCode, error.Error.Message));
                }
            }
        }

        public T GetResponse<T>()
        {
            GetResponse();
            return JsonConvert.DeserializeObject<T>(Response);
        }

        public string TokenKey { get; private set; }
        public string Response { get; private set; }
        public string Url { get; private set; }
        public string QueryString { get; private set; }
        public HttpVerb Method { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }
    }
}
