using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobApi.Lob
{
    public class VerifyAddressRequest
    {
        [JsonProperty(PropertyName = "address_line1")]
        public string Address1 { get; set; }

        [JsonProperty(PropertyName = "address_line2")]
        public string Address2 { get; set; }

        [JsonProperty(PropertyName = "address_city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "address_state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "address_zip")]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "address_country")]
        public string CountryCode { get; set; }

        public VerifyAddressRequest(string address1, string address2, string city, string state, string zipCode, string countryCode)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            City = city;
            Zip = zipCode;
            CountryCode = countryCode;
        }

        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public sealed class Builder
        {
            private string Address1 { get; set; }
            private string Address2 { get; set; }
            private string City { get; set; }
            private string State { get; set; }
            private string Zip { get; set; }
            private string CountryCode { get; set; }

            public Builder WithAddress1(string address1)
            {
                Address1 = address1;
                return this;
            }

            public Builder WithAddress2(string address2)
            {
                Address2 = address2;
                return this;
            }

            public Builder WithCity(string city)
            {
                City = city;
                return this;
            }

            public Builder WithState(string state)
            {
                State = state;
                return this;
            }

            public Builder WithZip(string zip)
            {
                Zip = zip;
                return this;
            }

            public Builder WithCountry(string country)
            {
                CountryCode = country;
                return this;
            }

            public VerifyAddressRequest Build()
            {
                return new VerifyAddressRequest(Address1, Address2, City, State, Zip, CountryCode);
            }
        }
    }
}
