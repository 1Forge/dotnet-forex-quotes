/*
 * This library is provided without warranty under the MIT license
 * Created by Jacob Davis <jacob@1forge.com>
 */

using Newtonsoft.Json;

namespace ForexQuotes
{
    public class MarketStatus
    {
        [JsonProperty("market_is_open")]
        public bool marketIsOpen;
    }
}