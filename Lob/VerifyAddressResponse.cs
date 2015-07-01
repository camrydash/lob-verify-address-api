using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobApi.Lob
{
    public class VerifyAddressResponse
    {
        [JsonProperty(PropertyName = "address")]
        private static BaseAddressResponse Address;

        public VerifyAddressResponse(BaseAddressResponse address)
        {
            Address = address;
        }

        public override string ToString()
        {
            return Address.ToStringWithoutLeadingComma();
        }
    }
}
