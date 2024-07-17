using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Client;
using Grpc.Net.Client;



class Program
{
    static async Task Main(string[] args)

    {
        
        var channel = GrpcChannel.ForAddress("http://localhost:5176", new GrpcChannelOptions
        {
            
            MaxSendMessageSize = 1024 * 1024 * 1050, // 1 ГБ
            MaxReceiveMessageSize = 1024 * 1024 * 1050 // 1 ГБ
        });
        var client = new DataTransfer.DataTransferClient(channel);

        byte[] data = new byte[1024*1024*1024]; // 1 ГБ данных
        new Random().NextBytes(data);

        var request = new DataRequest { Data = Google.Protobuf.ByteString.CopyFrom(data) };

        var stopwatch = Stopwatch.StartNew();
        var response = await client.SendDataAsync(request);
        stopwatch.Stop();

        Console.WriteLine($"Response: {response.Message}");
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }
} 