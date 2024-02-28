using API_Azure_KeyValue.Repositories;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAzureClients(azureClientFactoryBuilder =>
{
    azureClientFactoryBuilder.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});
builder.Services.AddSingleton<IKeyVaultManager, KeyVaultManager>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/api/kv", async (IKeyVaultManager _secretManager, string secretName) => 
{
    try
    {
        if (string.IsNullOrEmpty(secretName))
        {
            return Results.BadRequest();
        }

        string secretValue = await

        _secretManager.GetSecret(secretName);

        if (!string.IsNullOrEmpty(secretValue))
        {
            return Results.Ok(secretValue);
        }
        else
        {
            return Results.NotFound("Secret key not found.");
        }
    }
    catch
    {
        return Results.BadRequest("Error: Unable to read secret");
    }
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
