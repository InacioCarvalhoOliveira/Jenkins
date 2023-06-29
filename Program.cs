using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using gitConfig;
using packageConfig;
using processConfig;
using System.Text;

namespace Jenkins
{
    class Program : BranchSettings
    {
        static async Task Main(string[] args)
        {
            //Create a new process instance
            Process process = new Process();
            PackageSettings packageSettings = new PackageSettings();
            BranchSettings branchSettings = new BranchSettings();
            ProcessSettings processSettings = new ProcessSettings();

            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            #region chamada dos métodos das subclasses 
            string arguments;
            processSettings.authUser(out arguments);
            process.StartInfo.Arguments = "-Command " + "\"" + arguments + "\"";
            #endregion
            
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };
            process.ErrorDataReceived += (sender, e) =>
            {
               
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine("Error: " + e.Data);
            };

            Stopwatch stopwatch = Stopwatch.StartNew();
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync();
            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("Command executed in: " + elapsedTime.TotalMilliseconds + " ms");           
            
        }
    }
}