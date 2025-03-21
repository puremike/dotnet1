
namespace Tasks
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Execute.ExecuteAsync(1, 100);
            await Execute.ExecuteAsync(2, 90);
            await Execute.ExecuteAsync(3, 800);
            await Execute.ExecuteAsync(4, 60);
            await Execute.ExecuteAsync(5, 45);
            Console.WriteLine("After tasks has been completed");
        }

    }
}