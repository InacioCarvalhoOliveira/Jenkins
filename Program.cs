using System;
using System.Diagnostics;
using System.Threading.Tasks;
using gitConfig;

namespace Jenkins
{
    class Program : BranchSettings
    {
        static async Task Main(string[] args)
        {     
            
            // Create a new process instance
            Process process = new Process(); 
            BranchSettings config = new BranchSettings();

            process.StartInfo.FileName = "x-terminal-emulator";//cinamon terminal option
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            // set the privilleges of invoker as Admin and removing echoing of batch file
            string batchConfig = " @echo OFF set __COMPAT_LAYER=RunAsAdmin";
            //string command = "";
            process.StartInfo.Arguments = "/C " + batchConfig ;
            config.settingProcessInfo();

            // Set up event handler for reading the output asynchronously
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };
            // start the timewatch
            Stopwatch stopwatch = Stopwatch.StartNew();
            // Start the process
            process.Start();
            process.BeginOutputReadLine();

            // Wait asynchronously for the process to exit
            await process.WaitForExitAsync();

            // Stop the stopwatch and get the elapsed time
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Console.WriteLine("Command executed in: " + elapsedTime.TotalMilliseconds + " ms");
                
          
        }
    }
}
