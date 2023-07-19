using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using processConfig;
using packageConfig;

namespace gitConfig
{
    class BuilderBranch
    {

        public void branchCloning (out string branchArguments)
        {
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";        
            string json = File.ReadAllText(jsonPath);
            var branchSettings = JsonConvert.DeserializeObject<BranchSettings>(json);
            var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);
        
            string branch = branchSettings.Branch;
            string branchName = branchSettings.BranchName;
            string tfsLink = branchSettings.TFSLink;
            string project = branchSettings.Project;
            string tagGit = branchSettings.TagGit;
            string repository = branchSettings.Repository;
            string packagePath = branchSettings.PackagePath;

            string packageType = packageSettings.PackageType;
            string solutionProject = packageSettings.SolutionProject;
            
            if(branch != null && branchName != null){}

            string[] param = new string[4];
            param[0] = "clone --single-branch --branch ";     
            param[1] = $" {branch}/{branchName} ";     
            param[2] = $" {tfsLink}/{project}/{tagGit}/{repository}/ "; 
            param[3] = $" {packagePath}/{packageType}/{branchName}_{solutionProject}";                 

            StringBuilder scriptBuilder = new StringBuilder();
            foreach (string item in param)
            {
                scriptBuilder.AppendLine(item);
            }
            //TODO: passar método que valida os dados no json com o userMachine chamada da classe ConsoleSettings
            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            // TODO: padronizar forma de coleta e ajuste dos dados pelo json 
            string rawArguments = scriptBuilder.ToString();
            string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
            branchArguments = correctedArguments; 
            
            
            
        }
    }
}