using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidalRPC.Tidal.Models;
using System.Text.Json;
using System.Web;

namespace TidalRPC.Tidal
{
    internal class Api
    {
        private static HttpClient client = new HttpClient();

        public static SearchResponse? Search(string tidalToken, SearchParams sp)
        {
            string url = $"https://listen.tidal.com/v1/search/top-hits?query={HttpUtility.UrlEncode(sp.Query)}&limit={sp.Limit}&offset={sp.Offset}&types={String.Join(',', sp.Types)}&includeContributors={sp.IncludeContributors}&countryCode={sp.CountryCode}&locale={sp.Locale}&deviceType={sp.DeviceType}";
            HttpRequestMessage msg = new(HttpMethod.Get, url);
            msg.Headers.Add("Authorization", tidalToken);
            msg.Headers.Add("user-agent", "Tidal RPC");
            return JsonSerializer.Deserialize<SearchResponse>(client.Send(msg).Content.ReadAsStringAsync().Result, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
