using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using gitConfig;

namespace Jenkins
{
    class Program : BranchSettings
    {
        static async Task Main(string[] args)
        {  

            
            // string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";

            // try
            // {
            //     string jsonString = File.ReadAllText(jsonPath);
            //     BranchSettings getBranch = JsonConvert.DeserializeObject<BranchSettings>(jsonString);
            //     Console.WriteLine($": {getBranch.BranchName}");
            // }
            // catch (FileNotFoundException)
            // {
            //     Console.WriteLine("O arquivo JSON não foi encontrado.");
            // }
            // catch (JsonException)
            // {
            //     Console.WriteLine("O arquivo JSON está em um formato inválido.");
            // } 
            
            // Create a new process instance
            Process process = new Process(); 

            //process.StartInfo.FileName = "x-terminal-emulator";//cinamon terminal option
            process.StartInfo.FileName = "cmd.exe";//cinamon terminal option
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            
            // set the privilleges of invoker as Admin and removing echoing of batch file
            string batchConfig = " @echo OFF set __COMPAT_LAYER=RunAsAdmin";
            
            //string command = "";
            BranchSettings config = new BranchSettings();
            process.StartInfo.Arguments = "/C " + batchConfig ;
            //config.settingProcessInfo();
            config.catchingJsonParams();

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
