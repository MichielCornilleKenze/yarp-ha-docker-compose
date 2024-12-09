using HttpClient client = new HttpClient();

while (true)
{

    // Console.WriteLine("I am the client. It is {0}", DateTime.UtcNow);

    try
    {
        HttpResponseMessage response = await client.GetAsync("http://apigateway:8080/");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response from API Gateway: {0}", responseBody);
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Calling API Gateway Failed!: {0}", e.Message);
    }

    Thread.Sleep(1000);

}
