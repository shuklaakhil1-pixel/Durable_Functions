using Microsoft.Azure.Functions.Worker;

public class HelloActivity
{
    [Function("HelloActivity")]
    public string Run([ActivityTrigger] string name)
    {
        return $"Hello {name} from Durable Function!";
    }
}
