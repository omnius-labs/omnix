using System.Threading;
using System.Threading.Tasks;

namespace Omnius.Core.Extensions
{
    public static class TaskCompletionSourceExtensions
    {
        public static async Task<TResult> WaitAsync<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, CancellationToken cancellationToken = default)
        {
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                return await taskCompletionSource.Task;
            }
        }

        public static TResult Wait<TResult>(this TaskCompletionSource<TResult> taskCompletionSource, CancellationToken cancellationToken = default)
        {
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                return taskCompletionSource.Task.Result;
            }
        }
    }
}
