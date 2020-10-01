using System;
using System.Threading;

namespace TestAutomat.AutoTester
{
    public class AutoTester
    {
        public GetConfig GetConfig { get; set; }

        private readonly System.IO.DirectoryInfo _aktuellesProjekt;
        
        public AutoTester(System.IO.DirectoryInfo aktuellesProjekt)
        {
            _aktuellesProjekt = aktuellesProjekt;

            GetConfig = new GetConfig(_aktuellesProjekt);

            System.Threading.Tasks.Task.Run(TestRunnerTask);
        }

        private void TestRunnerTask()
        {
            while (true)
            {
                Thread.Sleep(10);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}