using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BotCombustivel
{
    class ConsumerMapsApi
    {
        private List<string> autocomplete(string input)
        {

            List<string> resultList = null;

            HttpClient conn = null;
            StringBuilder jsonResults = new StringBuilder();
            try
            {
                StringBuilder sb = new StringBuilder(PLACES_API_BASE + TYPE_AUTOCOMPLETE + OUT_JSON);
                sb.Append("?key=" + API_KEY);
                sb.Append("&components=country:uk");
                sb.Append("&input=" + URLEncoder.encode(input, "utf8"));

                URL url = new URL(sb.ToString());
                conn = url.OpenConnection() as HttpURLConnection;
                InputStreamReader inputStream = new InputStreamReader(conn.InputStream);

                // Load the results into a StringBuilder
                int read;
                char[] buff = new char[1024];
                while ((read = inputStream.Read(buff)) != -1)
                {
                    jsonResults.Append(buff, 0, read);
                }
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

}
