using System.Threading;

namespace TestAutomat.AutoTester
{
    public class AutoTester
    {
        public GetConfig GetConfig { get; set; }

        public AutoTester(System.IO.DirectoryInfo aktuellesProjekt)
        {
            GetConfig = new GetConfig(aktuellesProjekt);

            System.Threading.Tasks.Task.Run(TestRunnerTask);
        }

        private static void TestRunnerTask()
        {
            while (true)
            {
                Thread.Sleep(10);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}