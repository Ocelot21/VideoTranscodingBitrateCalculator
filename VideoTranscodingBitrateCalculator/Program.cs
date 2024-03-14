using Newtonsoft.Json;
using VideoTranscodingBitrateCalculator;

string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

string jsonFilePath = Path.Combine(directory, "xvideo.json");

if (File.Exists(jsonFilePath))
{

    string jsonData = File.ReadAllText(jsonFilePath);

    DeviceData deviceData = JsonConvert.DeserializeObject<DeviceData>(jsonData);

    Console.WriteLine($"Device: {deviceData.Device}");
    Console.WriteLine($"Model: {deviceData.Model}");
    Console.WriteLine();
    Console.WriteLine($"Network interfaces list:");
    Console.WriteLine();
    foreach (var nic in deviceData.NIC)
    {
        Console.WriteLine($"NIC Description: {nic.Description}");
        Console.WriteLine($"MAC Address: {nic.MAC}");
        Console.WriteLine($"Timestamp: {nic.Timestamp}");
        Console.WriteLine($"Rx: {nic.Rx}");
        Console.WriteLine($"Tx: {nic.Tx}");
        Console.WriteLine("_____________________________________");
    }


    Console.WriteLine();
    Console.WriteLine("Bitrate for each NIC (kbps):");
    foreach (var nic in deviceData.NIC)
    {
        Console.WriteLine();
        double rxKb = (nic.Rx * 8) / 1000.0;
        double txKb = (nic.Tx * 8) / 1000.0;

        double time = 1f / Settings.PullingRate; // Time in seconds - One second is divded by pulling rate (Hz) 

        double rxBitrate = rxKb / time;
        double txBitrate = txKb / time;

        Console.WriteLine($"  Rx Bitrate: {rxBitrate:N2} kbps");
        Console.WriteLine($"  Tx Bitrate: {txBitrate:N2} kbps");
        Console.WriteLine("_____________________________________");
    }
}

else
{
    Console.WriteLine("ERROR: File not found");
}
