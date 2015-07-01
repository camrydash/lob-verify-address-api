using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobApi.Lob
{
    public class BaseAddressResponse
    {
        [JsonProperty("address_line1")]
        public string Address1 { get; set; }

        [JsonProperty("address_line2")]
        public string Address2 { get; set; }

        [JsonProperty("address_city")]
        public string City { get; set; }

        [JsonProperty("address_state")]
        public string State { get; set; }

        [JsonProperty("address_zip")]
        public string Zip { get; set; }

        [JsonProperty("address_country")]
        public string Country { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        public string ToStringWithoutLeadingComma()
        {
            return "line1='" + Address1 + "'" +
                ", line2='" + Address2 + "'" +
                ", city='" + City + "'" +
                ", state='" + State + "'" +
                ", zip='" + Zip + "'" +
                ", country='" + Country + "'" +
                ", object='" + Object + "'";
        }
    }
}
