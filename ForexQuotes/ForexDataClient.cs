/*
 * This library is provided without warranty under the MIT license
 * Created by Jacob Davis <jacob@1forge.com>
 */

using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace ForexQuotes
{
    public class ForexDataClient
    {
        private string apiKey;
        private const string baseUri = "https://forex.1forge.com/1.0.3/";

        public ForexDataClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        private string Get(string apiCall)
        {
            var json = "";
            
            using (var wc = new WebClient())
            {
                json = wc.DownloadString(this.BuildUrl(apiCall));
            }

            return json;
        }

        private string BuildUrl(string apiCall)
        {
            return ForexDataClient.baseUri + apiCall + "&api_key=" + this.apiKey;
        }

        public Quote[] GetQuotes(string[] symbols)
        {
            var pairs = string.Join(",", symbols);

            var result = this.Get("quotes?cache=false&pairs=" + pairs);

            try
            {
                return JsonConvert.DeserializeObject<Quote[]>(result);
            }
            catch (Exception e)
            {
                UnableToUnmarshal(result);
            }

            return null;
        }

        public string[] GetSymbols()
        {
            var result = this.Get("symbols?cache=false");

            try
            {
                return JsonConvert.DeserializeObject<string[]>(result);
            }
            catch (Exception e)
            {
                UnableToUnmarshal(result);
            }

            return null;
        }

        public ConversionResult Convert(string from, string to, double quantity)
        {
            var result = this.Get("convert?cache=false&from=" + from + "&to=" + to + "&quantity=" + quantity);

            try
            {
                return JsonConvert.DeserializeObject<ConversionResult>(result);
            }
            catch (Exception e)
            {
                UnableToUnmarshal(result);
            }

            return null;
        }

        public MarketStatus GetMarketStatus()
        {
            var result = this.Get("market_status?cache=false");
            
            try
            {
                return JsonConvert.DeserializeObject<MarketStatus>(result);
            }
            catch (Exception e)
            {
                UnableToUnmarshal(result);
            }

            return null;
        }

        public Quota GetQuota()
        {
            var result = this.Get("quota?cache=false");

            try
            {
                return JsonConvert.DeserializeObject<Quota>(result);
            }
            catch (Exception e)
            {
                try
                {
                    var unlimitedQuota = JsonConvert.DeserializeObject<UnlimitedQuota>(result);
                    return UnlimitedQuota.ToQuota(unlimitedQuota);
                }
                catch (Exception ex)
                {
                    UnableToUnmarshal(result);
                }
            }

            return null;
        }

        private static void UnableToUnmarshal(string result)
        {
            var error = JsonConvert.DeserializeObject<ApiError>(result);

            throw new Exception(error.message);
        }
    }
}