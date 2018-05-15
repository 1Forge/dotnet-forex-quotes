/*
 * This library is provided without warranty under the MIT license
 * Created by Jacob Davis <jacob@1forge.com>
 */

namespace ForexQuotes
{
    public class Quote
    {
        
        public double bid, ask, price;
        public string symbol;
        public int timestamp;

        public override string ToString()
        {
            return   "Symbol: " + this.symbol + "\n" +
                     "Bid: " + this.bid + "\n" +
                     "Ask: " + this.ask + "\n" +
                     "Price: " + this.price + "\n" +
                     "Timestamp: " + this.timestamp;
        }
    }
}