using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Asynchronous_Programming.Module
{
    class Cancelling_Through_IAsyncEnumerable
    {
       private CancellationTokenSource cancellationTokenSource;
        public Cancelling_Through_IAsyncEnumerable(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
        }
        public async Task btnStart_Click()
        {
            var namesGenerator = GenerateNames();
            await ProcessNames(namesGenerator);
        }
        private async Task ProcessNames(IAsyncEnumerable<string> nameGenerators)
        {
          //  cancellationTokenSource = new CancellationTokenSource();
            try
            {
               await foreach (var name in nameGenerators.WithCancellation(cancellationTokenSource.Token))
                {
                    Console.WriteLine(name);
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("operation cancelled");
            }
            finally
            {
                cancellationTokenSource?.Dispose();
           //     cancellationTokenSource = null;
            }
        }

        private async IAsyncEnumerable<string> GenerateNames([EnumeratorCancellation] CancellationToken token =default)
        {
            yield return "rin";
            await Task.Delay(3000,token);
            yield return "tuan";
            await Task.Delay(3000,token);
            yield return "john";
        }
    }
}
