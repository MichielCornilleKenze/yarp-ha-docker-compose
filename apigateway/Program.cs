string replicaId = System.Net.Dns.GetHostEntry(Environment.MachineName).HostName;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () =>{
    using HttpClient client = new HttpClient(); // not production code
    string responseBody = "";
    try
    {
        HttpResponseMessage response = await client.GetAsync("http://service1:8080/");
        response.EnsureSuccessStatusCode();
        responseBody = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Calling Service1 Failed: {0}", e.Message);
        throw new Exception("Service1 is not available", e);
    }

    await Task.Delay(1000);

    return $"Gateway {replicaId} {DateTime.UtcNow}: Service1: {responseBody}";
    });

app.Run();
