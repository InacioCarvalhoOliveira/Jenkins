using System.Diagnostics;
using Newtonsoft.Json;

namespace gitConfig
{
    class BranchSettings
    {
        public string Branch { get; set; }
        public string BranchName { get; set; }
        public string TFSLink { get; set; }
        public string TagGit { get; set; }
        public string Project { get; set; }
        public string Repository { get; set; }
        public string PackagePath { get; set; }

        private ProcessStartInfo gitStartInfo;
        public void catchingGitParams()
        {
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";
            try
            {
                // Lê o conteúdo do arquivo JSON
                string json = File.ReadAllText(jsonPath);

                // Faz o parsing do JSON para um objeto
                var obj = JsonConvert.DeserializeObject<BranchSettings>(json);

                // Obtém o valor da propriedade BranchName
                //TODO melhorar atibuição das variáveis aos objetos
                string branchName = obj.BranchName;
                string branch = obj.Branch;
                string tfsLink = obj.TFSLink;
                string tagGit = obj.TagGit;
                string project = obj.Project;
                string repository = obj.Repository;

                //TODO para ser feita a clonagem é preciso um novo diretório ou um vazio                
                string packagePath = obj.PackagePath;
                gitStartInfo = new ProcessStartInfo
                {
                    FileName = "git",RedirectStandardOutput = true,
                    UseShellExecute = false,CreateNoWindow = true
                };
                gitStartInfo.Arguments = $"clone --single-branch --branch {branch}/{branchName}{tfsLink}/{project}/{tagGit}/{repository}/ {packagePath}";
                
                Process gitProcess = new Process();
                gitProcess.StartInfo = gitStartInfo;
                gitProcess.Start();
                gitProcess.WaitForExit();

                Console.WriteLine("Branch Repository: " + branch);
                Console.WriteLine("Branch to be Cloned: " + branchName);
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

