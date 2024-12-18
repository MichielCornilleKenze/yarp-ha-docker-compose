
while (true)
{
    try
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync("http://apigateway:8080/api/endpoint");
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
