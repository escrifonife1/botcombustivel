using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BotCombustivel
{
    class ConsumerMapsApi
    {
        //private string PLACES_API_BASE = "https://maps.googleapis.com/maps/api/place/autocomplete";
        private string PLACES_API_BASE = "https://maps.googleapis.com/maps/api/geocode/json";
        private string OUT_JSON = "json";
        private string API_KEY = "AIzaSyDWp1buYj0PrAIjvPERqYykNHxatBCcreo";
        private HttpClient _httpClient;
        public WebClient Client { get; private set; }

        public ConsumerMapsApi()
        {
            Client = new WebClient();
            Client.Headers.Add("Content-Type", "application/json");
            Client.Encoding = System.Text.Encoding.UTF8;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(PLACES_API_BASE);
        }

        public GoobleBest.RootObject GetBestAddress(string formatedAdress)
        {
            var origin = formatedAdress;
            var destinations = formatedAdress;

            var resultJson =
                Client.DownloadString(
                    $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={origin}&destinations={destinations}&key=AIzaSyAo1mmOJRwCVIbOZnAOtuck91sl6TFoUtE");
            try
            {
                var rootObject = JsonConvert.DeserializeObject<GoobleBest.RootObject>(resultJson);

                return rootObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Google.RootObject> GetAddress(string address)
        {
            var resultJson = Client.DownloadString($"{PLACES_API_BASE}?key={API_KEY}&address={address}");
            string responseContent = "";
            try
            {
                var response = await _httpClient.GetAsync($"?key={API_KEY}&address={address}");

                responseContent = await response.Content.ReadAsStringAsync() ?? string.Empty;
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.BadRequest)
                {
                    response.EnsureSuccessStatusCode();
                }

                var rootObject = JsonConvert.DeserializeObject<Google.RootObject>(resultJson);

                return rootObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> autocomplete(string input)
        {
            List<string> resultList = null;

            HttpClient conn = null;
            StringBuilder jsonResults = new StringBuilder();
            try
            {
                StringBuilder sb = new StringBuilder(PLACES_API_BASE);
                sb.Append($"?key={API_KEY}");
                sb.Append($"&address={input}");
                //sb.Append("&components=country:uk");
                //sb.Append("&input=" + URLEncoder.encode(input, "utf8"));

                /*var url = new Uri(sb.ToString());
                conn = url.OpenConnection() as HttpURLConnection;
                InputStreamReader inputStream = new InputStreamReader(conn.InputStream);

                // Load the results into a StringBuilder
                int read;
                char[] buff = new char[1024];
                while ((read = inputStream.Read(buff)) != -1)
                {
                    jsonResults.Append(buff, 0, read);
                }*/
            }
            catch (HttpRequestException e)
            {
                //Log.E(LOG_TAG, "Error processing Places API URL", e);
                return resultList;
            }
            catch (IOException e)
            {
                //Log.E(LOG_TAG, "Error connecting to Places API", e);
                return resultList;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }

            try
            {
                // Create a JSON object hierarchy from the results
                JObject jsonObj = new JObject(jsonResults.ToString());
                JArray predsJsonArray = new JArray(jsonObj["predictions"]);

                // Extract the Place descriptions from the results
                resultList = new List<string>(predsJsonArray.Count());
                for (int i = 0; i < predsJsonArray.Count(); i++)
                {
                    resultList.Add(predsJsonArray[i]["description"].ToString());
                }
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
            }

            return resultList;
        }
    }

    public class GoobleBest
    {
        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Element
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string status { get; set; }
        }

        public class Row
        {
            public IList<Element> elements { get; set; }
        }

        public class RootObject
        {
            public IList<string> destination_addresses { get; set; }
            public IList<string> origin_addresses { get; set; }
            public IList<Row> rows { get; set; }
            public string status { get; set; }
        }

    }

    public class Google
    {
        public class RootObject
        {
            public Result[] results { get; set; }
            public string status { get; set; }
        }

        public class Result
        {
            public Address_Components[] address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public string[] types { get; set; }
            public bool partial_match { get; set; }
        }

        public class Geometry
        {
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Northeast
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Southwest
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Location
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Viewport
        {
            public Northeast1 northeast { get; set; }
            public Southwest1 southwest { get; set; }
        }

        public class Northeast1
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Southwest1
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Address_Components
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
    }

}
