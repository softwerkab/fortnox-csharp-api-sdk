using System.Threading.Tasks;

namespace FortnoxAPILibrary
{
    internal static class TaskExtensions
    {
        public static T GetResult<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static void GetResult(this Task task)
        {
            task.ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
