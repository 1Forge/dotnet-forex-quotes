/*
 * This library is provided without warranty under the MIT license
 * Created by Jacob Davis <jacob@1forge.com>
 */

using Newtonsoft.Json;

namespace ForexQuotes
{
    public class UnlimitedQuota : QuotaBase
    {
        [JsonProperty("quota_limit")]
        public string quotaLimit;
        [JsonProperty("quota_remaining")]
        public string quotaRemaining;

        public static Quota ToQuota(UnlimitedQuota q)
        {
            var quota = new Quota
            {
                quotaUsed = q.quotaUsed,
                quotaLimit = 0,
                quotaRemaining = 0,
                hoursUntilReset = q.hoursUntilReset
            };

            return quota;
        }
            
    }
}