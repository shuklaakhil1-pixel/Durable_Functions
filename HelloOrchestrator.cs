using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;
using System.Threading.Tasks;

public class HelloOrchestrator
{
    [Function("HelloOrchestrator")]
    public async Task<string> Run(
        [OrchestrationTrigger] TaskOrchestrationContext context)
    {
        var name = context.GetInput<string>();

        string result = await context.CallActivityAsync<string>(
            "HelloActivity", name);

        return result;
    }
}
