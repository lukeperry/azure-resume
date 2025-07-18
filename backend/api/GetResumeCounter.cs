using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Azure.Cosmos;

namespace Company.Function;

public class GetResumeCounter
{
    private readonly ILogger<GetResumeCounter> _logger;

    public GetResumeCounter(ILogger<GetResumeCounter> logger)
    {
        _logger = logger;
    }

    [Function("GetResumeCounter")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        
        try
        {
            // Get connection string from environment
            var connectionString = Environment.GetEnvironmentVariable("AzureResumeConnectionString");
            
            // Create Cosmos client
            using var cosmosClient = new CosmosClient(connectionString);
            var database = cosmosClient.GetDatabase("AzureResume");
            var container = database.GetContainer("Counter");
            
            // Read current counter
            var response = await container.ReadItemAsync<Counter>("1", new PartitionKey("1"));
            var counter = response.Resource;
            
            // Increment counter
            counter.Count += 1;
            
            // Update counter
            await container.ReplaceItemAsync(counter, "1", new PartitionKey("1"));
            
            var result = new OkObjectResult(counter);
            result.ContentTypes.Add("application/json");
            
            return result;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            // Create new counter if not found
            try
            {
                var connectionString = Environment.GetEnvironmentVariable("AzureResumeConnectionString");
                using var cosmosClient = new CosmosClient(connectionString);
                var database = cosmosClient.GetDatabase("AzureResume");
                var container = database.GetContainer("Counter");
                
                var newCounter = new Counter { Id = "1", Count = 1 };
                await container.CreateItemAsync(newCounter, new PartitionKey("1"));
                
                var result = new OkObjectResult(newCounter);
                result.ContentTypes.Add("application/json");
                
                return result;
            }
            catch (Exception createEx)
            {
                _logger.LogError($"Error creating counter: {createEx.Message}");
                return new OkObjectResult("Error creating counter");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error: {ex.Message}");
            return new OkObjectResult("Error updating counter");
        }
    }
}