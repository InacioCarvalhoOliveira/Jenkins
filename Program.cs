using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using gitConfig;
using packageConfig;
using processConfig;
using System.Text;
using Jenkins.Services;

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
            BuilderBranch builderBranch = new BuilderBranch();

            process.StartInfo.FileName = "powershell.exe";//scripts rodando pelo powershell
            process.StartInfo.UseShellExecute = false;//permite que seja feito o controle dos parametros com o MSBUILD
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;//desabilita a janela de saída do terminal

            #region chamada da api jenkins
            string jenkinsUrl = "http://localhost:8080/job/ParameterJson";
            string localFilePath = "J:\\Jenkins\\util\\parametros.json";
            //TODO senha aqui hoster
            string? user = "win_adm_inacio:Flocktro0per.UHK70";

            JenkinsApiService jenkinsApiService = new JenkinsApiService(jenkinsUrl, user);

            try
            {
                string jsonData = await jenkinsApiService.GetJsonDataAsync();
                File.WriteAllText(localFilePath, jsonData);

                Console.WriteLine($"Arquivo JSON salvo em: {localFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            #endregion


            #region chamada dos métodos das subclasses 
            string authArguments;
            string apiPackageArguments;
            consoleSettings.authUser(out authArguments);
            process.StartInfo.Arguments = "-Command " + "" + authArguments + "";

            //json mapeado com parâmetros de build e clone do TFS e SKD dedicada (obrigatório)
            branchSettings.catchingGitParams();
            //clone dos pacotes referenciados pelo json (opcional)
            //builderBranch.branchCloning();

            packageSettings.buildingApiPackage(out apiPackageArguments);
            process.StartInfo.Arguments = "-Command " + "" + apiPackageArguments + "";
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

