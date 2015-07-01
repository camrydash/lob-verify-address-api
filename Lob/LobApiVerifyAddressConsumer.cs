using LobApi.Lob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LobApi
{
    public class LobApiVerifyAddressConsumer
    {
        private readonly string _tokenKey = ConfigurationManager.AppSettings["LibApiKey"];
        private readonly string _baseUrl = "https://api.lob.com/v1/verify";

        private static Lazy<LobApiVerifyAddressConsumer> instance = new Lazy<LobApiVerifyAddressConsumer>(
            () => new LobApiVerifyAddressConsumer()
            );

        public static LobApiVerifyAddressConsumer Instance
        {
            get { return instance.Value; }
        }

        public LobApiVerifyAddressConsumer()
        {
            if (string.IsNullOrEmpty(_tokenKey))
                throw new ArgumentException("Lib Api Key Missing!");
        }

        public VerifyAddressResponse VerifyAddress(VerifyAddressRequest addressRequest)
        {
            var postData = JsonConvert.SerializeObject(addressRequest, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            DefaultWebRequest request = WebRequestFactory.PostRequest(_baseUrl, postData, _tokenKey);

            return request.GetResponse<VerifyAddressResponse>(); ;
        }

        public VerifyAddressResponse VerifyAddress(string streetAddress, string city, string state, string zipCode, string countryCode)
        {
            var verifyAddressRequestBuilder = VerifyAddressRequest.NewBuilder();
            VerifyAddressRequest addressRequest = verifyAddressRequestBuilder
                .WithAddress1(streetAddress)
                .WithAddress2(null)
                .WithCity(city)
                .WithState(state)
                .WithZip(zipCode)
                .WithCountry(countryCode)
                .Build();

            return VerifyAddress(addressRequest);
        }

    }
}
