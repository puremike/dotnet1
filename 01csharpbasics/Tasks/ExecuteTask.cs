
namespace Tasks
{

    internal class Execute
    {
        internal static async Task ExecuteAsync(int taskNumber, int delay)
        {
            await Task.Delay(delay);
            Console.WriteLine("Task number: " + taskNumber);
        }
    }

}

