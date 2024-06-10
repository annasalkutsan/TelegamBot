using Quartz;

namespace Infrastructure.Jobs;

public class TestJob:IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"Job executed at {DateTime.Now}");
        return Task.CompletedTask;
    }
}