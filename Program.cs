using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using gitConfig;
using packageConfig;

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

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            //Privilegiando Invoker como Admin e removendo echo dos .bat 
            string batchSet = " @echo OFF set __COMPAT_LAYER=RunAsAdmin";
            process.StartInfo.Arguments = "/C " + batchSet;

            #region passagem dos métodos da subclasse 
            branchSettings.catchingGitParams();
            packageSettings.buildingPakcage();
            #endregion

            //Privilegiando Invoker como Admin e removendo echo dos .bat
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };

            Stopwatch stopwatch = Stopwatch.StartNew();
            process.Start();
            process.BeginOutputReadLine();
            await process.WaitForExitAsync();
            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine("Command executed in: " + elapsedTime.TotalMilliseconds + " ms");
        }
    }
}
