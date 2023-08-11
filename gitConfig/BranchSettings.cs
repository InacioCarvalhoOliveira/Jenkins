using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using packageConfig;

namespace gitConfig
{
    class BranchSettings : BuilderBranch
    {
        public string? Branch { get; set; }
        public string? BranchName { get; set; }
        public string? TFSLink { get; set; }
        public string? TagGit { get; set; }
        public string? Project { get; set; }
        public string? Repository { get; set; }
        public string? PackagePath { get; set; }
        string? branchArguments { get; set; }
        private ProcessStartInfo? gitStartInfo;
        public void catchingGitParams()
        {
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\api_params.json";
            try
            {
                Process gitProcess = new Process();

                // Lê o conteúdo do arquivo JSON
                string json = File.ReadAllText(jsonPath);

                // Faz o parsing do JSON para um objeto
                var branchSettings = JsonConvert.DeserializeObject<BranchSettings>(json);
                var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);

                gitStartInfo = new ProcessStartInfo
                {
                    FileName = "git",/// <c>text</c>
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                branchBuilder(out string branchArguments);

                string branchBuilder(out string branchArguments)
                {

                    string[] param = new string[4];
                    param[0] = "clone --single-branch --branch ";
                    param[1] = $" {branchSettings?.Branch}{branchSettings?.BranchName} ";
                    param[2] = $" {branchSettings?.TFSLink}/{branchSettings?.Project}/{branchSettings?.TagGit}/{branchSettings?.Repository}/ ";
                    param[3] = $" {branchSettings?.PackagePath}/{packageSettings?.PackageType}/{packageSettings?.AliasSolution}";

                    StringBuilder scriptBuilder = new StringBuilder();
                    foreach (string item in param)
                    {
                        scriptBuilder.AppendLine(item);
                    }

                    // //TODO: passar método que valida os dados no json com o userMachine chamada da classe ConsoleSettings.
                    // //coleta os itens do foreach e armazena tipo dado de retorno do método.
                    // // TODO: padronizar forma de coleta e ajuste dos dados pelo json. 
                    string rawArguments = scriptBuilder.ToString();
                    branchArguments = rawArguments;
                    return branchArguments;
                }


                string rawArguments = branchArguments.ToString();
                string correctedArguments = rawArguments.Replace("\"", "").Replace("\\\"", "").Replace("\r\n", "");
                branchArguments = correctedArguments;

                gitStartInfo.Arguments = branchArguments;
                gitProcess.StartInfo = gitStartInfo;
                gitProcess.Start();
                gitProcess.WaitForExit();

            }
            catch (IOException ex)
            { Console.WriteLine("Error reading the file: " + ex.Message); }

            catch (JsonException ex)
            { Console.WriteLine("Error parsing the JSON: " + ex.Message); }

            catch (Exception ex)
            { Console.WriteLine("Error: " + ex.Message); }

        }
    }
}

