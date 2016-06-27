using baseRuntime;
using System.IO;
using System.Threading;

namespace testDll
{
    public class worker : taskBase
    {
        public worker(string preferences) : base(preferences) {}

        public override void doWork()
        {
            log_?.Invoke("hello world");
            Thread.Sleep(1000);
            res_?.Invoke(true);
        }
    }
}
