using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoTranscodingBitrateCalculator
{
    public class DeviceData
    {
        [JsonProperty("Device")]
        public string Device { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("NIC")]
        public NIC[] NIC { get; set; }
    }
}
