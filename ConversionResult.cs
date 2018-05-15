/*
 * This library is provided without warranty under the MIT license
 * Created by Jacob Davis <jacob@1forge.com>
 */

using Newtonsoft.Json;

namespace ForexQuotes
{
    public class ConversionResult
    {
        public double value;
        public string text;
        public int timestamp;
        
        public override string ToString()
        {
            return  "Value: " + this.value + "\n" +
                    "Text: " + this.text + "\n" +
                    "Timestamp: " + this.timestamp;
        }
    }
}