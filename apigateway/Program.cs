string replicaId = System.Net.Dns.GetHostEntry(Environment.MachineName).HostName;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Reply From API Gateway {replicaId} {DateTime.UtcNow}");

app.Run();
