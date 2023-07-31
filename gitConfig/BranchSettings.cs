using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using packageConfig;

namespace gitConfig
{
    class BranchSettings : BuilderBranch
    {
        public string? Branch { get; set; }
        public string BranchName { get; set; }
        public string TFSLink { get; set; }
        public string TagGit { get; set; }
        public string Project { get; set; }
        public string Repository { get; set; }
        public string PackagePath { get; set; }
        string branchArguments;
        private ProcessStartInfo gitStartInfo;
        public void catchingGitParams()
        {
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";
            try
            {
                Process gitProcess = new Process();

                // Lê o conteúdo do arquivo JSON
                string json = File.ReadAllText(jsonPath);

                // Faz o parsing do JSON para um objeto
                var obj = JsonConvert.DeserializeObject<BranchSettings>(json);
                var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);

                // Obtém o valor da propriedade BranchName
                //TODO melhorar atibuição das variáveis aos objetos
                string branchName = obj.BranchName;
                string branch = obj.Branch;
                string tfsLink = obj.TFSLink;
                string tagGit = obj.TagGit;
                string project = obj.Project;
                string repository = obj.Repository;
                //TODO para ser feita a clonagem é preciso um novo diretório ou um vazio, mehorar isso       
                string packagePath = obj.PackagePath;

                string packageType = packageSettings.PackageType;
                string aliasSolution = packageSettings.AliasSolution;

                gitStartInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                branchBuilder(out string branchArguments);

                string branchBuilder(out string branchArguments)
                {

                    string[] param = new string[4];
                    param[0] = "clone --single-branch --branch ";
                    param[1] = $" {branch}{branchName} ";
                    param[2] = $" {tfsLink}/{project}/{tagGit}/{repository}/ ";
                    param[3] = $" {packagePath}/{packageType}/{aliasSolution}";

                    StringBuilder scriptBuilder = new StringBuilder();
                    foreach (string item in param)
                    {
                        scriptBuilder.AppendLine(item);
                    }

                    // //TODO: passar método que valida os dados no json com o userMachine chamada da classe ConsoleSettings.
                    // //coleta os itens do foreach e armazena tipo dado de retorno do método.
                    // // TODO: padronizar forma de coleta e ajuste dos dados pelo json. 
                    string rawArguments = scriptBuilder.ToString();
                    // string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
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

