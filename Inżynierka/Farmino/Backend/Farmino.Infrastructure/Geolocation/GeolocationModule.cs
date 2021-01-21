using Farmino.Infrastructure.Geolocation.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Geolocation
{
    public class GeolocationModule : IGeolocation
    {
        private readonly IConfiguration _configuration;
        public GeolocationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GeolocationModel> GetNode(string postalCode, string city, string street, string houseNumber)
        {
            try
            {
                var key = _configuration.GetSection("GeolocationApi:key").Value;

                HttpClient client = new HttpClient();
                client.BaseAddress= new Uri("https://us1.locationiq.com/v1/search.php");

                HttpResponseMessage response = await client.GetAsync($"?key={key}&q={postalCode}&" +
                    $"&{city}&{street}&{houseNumber}&accept-language=pl&format=json");

                var geolocation  = JsonConvert
                    .DeserializeObject<IEnumerable<GeolocationModel>>(await response.Content.ReadAsStringAsync());

                return geolocation.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
