using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LobApi.Lob
{
    /// <summary>
    /// Builder Pattern
    /// </summary>
    internal class QueryBuilder
    {
        private readonly string _apiUrl;
        private readonly NameValueCollection _nameValueCollection = new NameValueCollection();

        public QueryBuilder(string baseUrl = null)
        {
            _apiUrl = baseUrl;
        }

        public QueryBuilder(NameValueCollection nameValueCollection)
            : this()
        {
            _nameValueCollection = nameValueCollection;
        }

        public QueryBuilder AddQuery(string key, string value)
        {
            if(!string.IsNullOrEmpty(key))
                _nameValueCollection.Add(key, value);
            return this;
        }

        /// <summary>
        /// Serialize a request object to a query string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        public static string Serialize<T>(T requestObject)
        {
            QueryBuilder queryBuilder = new QueryBuilder();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                var attr = (JsonPropertyAttribute[])prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attr.Length > 0)
                {   
                    var value = (string)requestObject.GetType().GetProperty(prop.Name).GetValue(requestObject, null);
                    if(!string.IsNullOrEmpty(value))
                        queryBuilder.AddQuery(attr[0].PropertyName, value);
                }
            }

            return queryBuilder.Build();
        }

        public string Build()
        {
            var result = string.Join("&",
                    _nameValueCollection.AllKeys.Select(key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(_nameValueCollection[key]))));
            if (!string.IsNullOrEmpty(_apiUrl))
                result = string.Concat(_apiUrl, "?", result);
            return result;
            //return string.Concat(_apiUrl, "?",
            //    string.Join("&",
            //        _nameValueCollection.AllKeys.Select(key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(_nameValueCollection[key]))))
            //        );
        }
    }
}
