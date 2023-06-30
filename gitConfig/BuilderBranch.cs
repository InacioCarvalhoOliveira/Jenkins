using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using processConfig;

namespace gitConfig
{
    class BuilderBranch : BranchSettings
    {

        public void branchCloning (out string branchArguments)
        {
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";              
                          
            string json = File.ReadAllText(jsonPath);
            var obj = JsonConvert.DeserializeObject<BranchSettings>(json);
        
            string branch = obj.Branch;
            string branchName = obj.BranchName;
            string tfsLink = obj.TFSLink;
            string project = obj.Project;
            string tagGit = obj.TagGit;
            string repository = obj.Repository;
            string packagePath = obj.PackagePath;
            
            string[] param = new string[4];
            param[0] = "clone --single-branch --branch ";     
            param[1] = $@" ""{branch}/{branchName}"" ";     
            param[2] = $@" ""{tfsLink}/{project}/{tagGit}/{repository}/"" "; 
            param[3] = $@" "" {packagePath}"" ";                    
        
            Console.WriteLine("Branch Repository: " + branch);
            Console.WriteLine("Branch to be Cloned: " + branchName);

            StringBuilder scriptBuilder = new StringBuilder();
            foreach (string item in param)
            {
                scriptBuilder.AppendLine(item);
            }
            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            branchArguments = scriptBuilder.ToString().Replace("\\", "");
            
        }
    }
}