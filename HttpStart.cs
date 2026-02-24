using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;
using System.Net;
using System.Threading.Tasks;

public class HttpStart
{
    [Function("HttpStart")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
        [DurableClient] DurableTaskClient client)
    {
        var name = await req.ReadAsStringAsync();

        string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
            "HelloOrchestrator", name);

        var response = req.CreateResponse(HttpStatusCode.Accepted);
        await response.WriteStringAsync($"Started orchestration with ID = {instanceId}");

        return response;
    }
}
