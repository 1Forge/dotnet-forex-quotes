/*
 * This library is provided without warranty under the MIT license
 * Created by Jacob Davis <jacob@1forge.com>
 */

using Newtonsoft.Json;

namespace ForexQuotes
{
    public class QuotaBase
    {
        [JsonProperty("quota_used")]
        public int quotaUsed;
        [JsonProperty("hours_until_reset")]
        public int hoursUntilReset;
        [JsonProperty("quota_limit")]
        public int quotaLimit;
        [JsonProperty("quota_remaining")]
        public int quotaRemaining;
            
        public override string ToString()
        {
            return  "Quota Used: " + this.quotaUsed + "\n" +
                    "Quota Limit: " + this.quotaLimit + "\n" +
                    "Quota Remaining: " + this.quotaRemaining + "\n" +
                    "Hours until Reset: " + this.hoursUntilReset;
      
        }
    }
}