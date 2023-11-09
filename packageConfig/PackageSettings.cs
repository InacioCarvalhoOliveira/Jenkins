using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using gitConfig;
using Newtonsoft.Json;

namespace packageConfig
{
    class PackageSettings : BranchSettings
    {
        public string? SkdVersion { get; set; }// dir to send
        public string? SendTo { get; set; }// dir to send
        public string? SolutionProject { get; set; }// namePorject.sln
        public string? PathProject { get; set; }
        public string? Pubmode { get; set; } // Release, Debug
        public string? SolutionPlatform { get; set; } // 64x,86x,32x
        public string? PackageType { get; set; } // api, app...
        public string? NameProj { get; set; } // 64x,86x,32x
        public string? AliasSolution { get; set; }
        public string? AliasPublication { get; set; }
        string jsonPath = "J:\\Jenkins\\util\\api_params.json";
        public void buildingApiPackage(out string apiPackageArguments)
        {
            // TODO: melhorarar a busca do arquivo json
            string json = File.ReadAllText(jsonPath);
            var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);
            var branchSettings = JsonConvert.DeserializeObject<BranchSettings>(json);
            var builderBranch = JsonConvert.DeserializeObject<BuilderBranch>(json);
         
            // --debug or --release
            
            StringBuilder scriptBuilder = new StringBuilder();
            // TODO : SE for 
            if(packageSettings?.PackageType == "apis" && builderBranch?.ApiBuildPackage == true)
            {
                string[] param = new string[7];
                param[0] = $"dotnet ";
                param[1] = $"'{packageSettings?.SkdVersion}' publish -c ";
                param[2] = $"{packageSettings?.Pubmode} -r ";
                param[3] = $"{packageSettings?.SolutionPlatform} ";
                param[4] = $"--output '{packageSettings?.SendTo}/{packageSettings?.AliasPublication}' ";
                param[5] = $"'{packageSettings?.PathProject}/{packageSettings?.PackageType}/";
                param[6] = $"{packageSettings?.AliasSolution}/{packageSettings?.NameProj}.{packageSettings?.SolutionProject}.sln'";

                foreach (string item in param)
                {
                scriptBuilder.AppendLine(item);
                }
            }
            else if(packageSettings?.PackageType == "services" && builderBranch?.ServiceBuildPackage == true)
            {
                string demaisClientes = "WebConsorciado(Demais Clientes)";
                string[] param = new string[7];
                param[0] = $"dotnet ";
                param[1] = $"'{packageSettings?.SkdVersion}' publish -c --framework netcoreapp2.2 ";
                param[2] = $"{packageSettings?.Pubmode} -r ";
                param[3] = $"{packageSettings?.SolutionPlatform} ";
                param[4] = $"--output '{packageSettings?.SendTo}/{packageSettings?.AliasPublication}' ";
                param[5] = $"'{packageSettings?.PathProject}/{packageSettings?.PackageType}/";
                param[6] = $"{packageSettings?.AliasSolution}/{demaisClientes}/{packageSettings?.NameProj}.sln'";

                foreach (string item in param)
                {
                scriptBuilder.AppendLine(item);
                }
            }
            else
            {
                          
                string a = @"D:\GitHub\PublishedPack\app\fancar\front\flutter_build.bat";              
                //string b = @"D:\GitHub\PublishedPack\app\fancar\front";
                //string a = @"D:\GitHub\Jenkins\util\flutter_build.bat";

               string b = @"'D:\GitHub\Jenkins\util\flutter_build.bat' 'D:\GitHub\PublishedPack\app\fancar\front'";
                // flutter build web --release --output=meu/caminho/
                string[] param = new string[1];
                
                //param[0] = $@"XCOPY /Y '{b}';";
                param[0] = $@"Start-Process -Wait -FilePath '{a}'";
        

                foreach (string item in param)
                {
                scriptBuilder.AppendLine(item);
                }
            }

            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            // TODO: forma de validar se no stringbuilder vem conteudo para depois jogar 'arguments'
            string rawArguments = scriptBuilder.ToString();
            string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
            apiPackageArguments = correctedArguments;
        }
        // public void buildingAppPackage(out string appPackageArguments)
        // {          
        //     string json = File.ReadAllText(jsonPath);
        //     var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);
        //     // --debug or --release
        //     string[] param = new string[2];
        //     param[0] = $"flutter build web --{packageSettings?.Pubmode} ";
        //     param[1] = $"--output='{packageSettings?.SendTo}'";
           

        //     StringBuilder scriptBuilder = new StringBuilder();
        //     foreach (string item in param)
        //     {
        //         scriptBuilder.AppendLine(item);
        //     }

        //     //coleta os itens do foreach e armazena tipo dado de retorno do método. 
        //     // TODO: forma de validar se no stringbuilder vem conteudo para depois jogar 'arguments'
        //     string rawArguments = scriptBuilder.ToString();
        //     string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
        //     appPackageArguments = correctedArguments;
        // XCOPY /S /I /Y 'D:\GitHub\PublishedPack\app\fancar\front' 'D:\GitHub\PublishedPack\app\fancar'


        // }
       
    }

}