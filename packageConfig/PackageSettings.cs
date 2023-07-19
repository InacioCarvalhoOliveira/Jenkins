using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using gitConfig;
using Newtonsoft.Json;

namespace packageConfig
{
    class PackageSettings : BranchSettings
    {
        public string SkdVersion { get; set; }// dir to send
        public string SendTo { get; set; }// dir to send
        public string SolutionProject { get; set; }// namePorject.sln
        public string PathProject { get; set; }
        public string Pubmode { get; set; } // Release, Debug
        public string? SolutionPlatform { get; set; } // 64x,86x,32x
        public string PackageType { get; set; } // 64x,86x,32x
        public string NameProj { get; set; } // 64x,86x,32x
        public void buildingPackage (out string packageArguments)
        { 
             // TODO: melhorarar a busca do arquivo json
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";              
                          
            string json = File.ReadAllText(jsonPath);
            var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);
            var branchSettings = JsonConvert.DeserializeObject<BranchSettings>(json);
            string skdVersion = packageSettings.SkdVersion;
            string pubMode = packageSettings.Pubmode;
            string solutionPlatform = packageSettings.SolutionPlatform; 
            string sendTo = packageSettings.SendTo; 
            string solutionProject = packageSettings.SolutionProject; 
            string pathProject = packageSettings.PathProject;
            string packageType = packageSettings.PackageType;
            string nameProj = packageSettings.NameProj;

            string branch = branchSettings.Branch; 
            string branchName = branchSettings.BranchName; 



            
            string[] param = new string[7];
            param[0] = $"dotnet ";  
            param[1] = $"'{skdVersion}' publish -c ";  
            param[2] = $"{pubMode} -r ";   
            param[3] = $"{solutionPlatform} ";
            param[4] = $"--output '{sendTo}/{branch}_{branchName}_{solutionProject}' ";
            param[5] = $"{pathProject}/{packageType}/";
            param[6] = $"{branchName}_{solutionProject}/{nameProj}.{solutionProject}.sln";
             
            StringBuilder scriptBuilder = new StringBuilder();
            foreach (string item in param)
            {
                scriptBuilder.AppendLine(item);
            }           
            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            // TODO: forma de validar se no stringbuilder vem conteudo para depois jogar 'arguments'
            string rawArguments = scriptBuilder.ToString();
            string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
            packageArguments = correctedArguments;//+TFSCONTENT;
          
            
        }
    }

}