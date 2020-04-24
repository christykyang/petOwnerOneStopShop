using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using petOwnerOneStopShop.Contracts;
using petOwnerOneStopShop.Data;
using petOwnerOneStopShop.Models;

namespace petOwnerOneStopShop.Services
{
    public class GeocodeApi : IGetCoordinatesRequest
    {
        private ApplicationDbContext _context;

        public GeocodeApi(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<double> GetLat(string url, Address address)
        {
            double lat;

            HttpClient client = new HttpClient();
            using (client)
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string data = await response.Content.ReadAsStringAsync();
                JObject dataAsJObject = JsonConvert.DeserializeObject<JObject>(data);
                lat = Double.Parse(dataAsJObject["results"][0]["geometry"]["location"]["lat"].ToString());

            }
            return lat;
        }
        public async Task<double> GetLng(string url, Address address)
        {
            double lng;

            HttpClient client = new HttpClient();
            using (client)
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string data = await response.Content.ReadAsStringAsync();
                JObject dataAsJObject = JsonConvert.DeserializeObject<JObject>(data);
                lng = Double.Parse(dataAsJObject["results"][0]["geometry"]["location"]["lng"].ToString());

            }
            return lng;
        }
        public string GetAddressAsURL(Address address)
        {
            string api = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string streetAddress;
            string city;
            string state;
            string zipcode;
            streetAddress = address.StreetAddress.Replace(' ', '+');
            city = address.City.Replace(' ', '+');
            state = address.State.Replace(' ', '+');
            zipcode = address.ZipCode.Replace(' ', '+');

            string url = api + streetAddress + ",+" + city + ",+" + state + "," + zipcode + $"&key={API_Keys.GeocodeAndGoogleMapsKey}";
            return url;
        }
    }
}
