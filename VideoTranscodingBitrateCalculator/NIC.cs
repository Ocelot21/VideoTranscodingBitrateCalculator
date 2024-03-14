using Newtonsoft.Json;

namespace VideoTranscodingBitrateCalculator
{
    public class NIC
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("MAC")]
        public string MAC { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Rx")]
        public long Rx { get; set; }

        [JsonProperty("Tx")]
        public long Tx { get; set; }
    }
}
