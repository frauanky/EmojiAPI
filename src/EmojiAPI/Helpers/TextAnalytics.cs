using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;

namespace EmojiAPI.Helpers
{
    public class TextAnalytics
    {
        public async Task<double> MakeRequestAsync(string text)
        {
            var client = new HttpClient();

            var parametersToAdd = new Dictionary<string, string> { { "text", text } };

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "47d009366e0b41c18beef738008b7b24");

            var uri = QueryHelpers.AddQueryString("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment", parametersToAdd);
            //var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
            HttpResponseMessage response;

            JObject json = new JObject(new JProperty("documents",
                new JArray(new JObject(
                    new JProperty("language", "en"),
                    new JProperty("id", "id"),
                    new JProperty("text", text)))));

            string jsonstring = json.ToString();

            // Request body
            //byte[] byteData = Encoding.UTF8.GetBytes(jsonstring);

            using (var content = new StringContent(jsonstring))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                var responseJson = await response.Content.ReadAsStringAsync();
                JObject test = JObject.Parse(responseJson);
                JArray doc = (JArray)test["documents"];
                var firstDoc = (JObject)doc.First;
                var score = firstDoc["score"].ToString();
                return Double.Parse(score);
            }

        }
    }
}

