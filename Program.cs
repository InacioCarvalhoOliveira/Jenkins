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
            ConsoleSettings consoleSettings = new ConsoleSettings();
            BranchSettings branchSettings = new BranchSettings();
            PackageSettings packageSettings = new PackageSettings();

            process.StartInfo.FileName = "powershell.exe";//scripts rodando pelo powershell
            process.StartInfo.UseShellExecute = false;//permite que seja feito o controle dos parametros com o MSBUILD
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;//desabilita a janela de saída do terminal

                         
            
            
            
            #region chamada dos métodos das subclasses 
                       
            string arguments;
            string packageArguments;
            consoleSettings.authUser(out arguments);
            process.StartInfo.Arguments = "-Command " + "" + arguments + "";
            branchSettings.catchingGitParams();
            packageSettings.buildingPackage(out packageArguments);
            process.StartInfo.Arguments = "-Command " + "" + packageArguments + "";


            #endregion
        
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    Console.WriteLine(e.Data);
            };
            process.ErrorDataReceived += (sender, e) =>
            {               
                 if (!string.IsNullOrEmpty(e.Data))
                     Console.WriteLine("Erro: " + e.Data);
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

