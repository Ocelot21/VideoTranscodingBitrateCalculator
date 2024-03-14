using Newtonsoft.Json;
using VideoTranscodingBitrateCalculator;

string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

string jsonFilePath = Path.Combine(directory, "xvideo.json");

string jsonData = File.ReadAllText(jsonFilePath);

DeviceData deviceData = JsonConvert.DeserializeObject<DeviceData>(jsonData);

Console.WriteLine($"Device: {deviceData.Device}");
Console.WriteLine($"Model: {deviceData.Model}");

foreach (var nic in deviceData.NIC)
{
    Console.WriteLine($"NIC Description: {nic.Description}");
    Console.WriteLine($"MAC Address: {nic.MAC}");
    Console.WriteLine($"Timestamp: {nic.Timestamp}");
    Console.WriteLine($"Rx: {nic.Rx}");
    Console.WriteLine($"Tx: {nic.Tx}");
}

Console.WriteLine("Bitrate for each NIC (kbps):");
foreach (var nic in deviceData.NIC)
{
    double rxKbps = (nic.Rx * 8) / 1000.0;
    double txKbps = (nic.Tx * 8) / 1000.0;

    double time = 1f / Settings.PullingRate; // Time in seconds

    double rxBitrateKbps = rxKbps / time;
    double txBitrateKbps = txKbps / time;

    Console.WriteLine($"  Rx Bitrate: {rxBitrateKbps:N2} kbps");
    Console.WriteLine($"  Tx Bitrate: {txBitrateKbps:N2} kbps");
}