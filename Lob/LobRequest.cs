using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobApi.Lob
{
    public abstract class LobRequest
    {
        private static NameValueCollection NameValueCollection;

        public LobRequest(NameValueCollection nameValueCollection)
        {
            NameValueCollection = nameValueCollection;
        }
    }
}
