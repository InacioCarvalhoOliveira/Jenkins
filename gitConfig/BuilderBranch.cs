using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using processConfig;
using packageConfig;

namespace gitConfig
{
    class BuilderBranch
    {
         public bool AppBuildPackage { get; set; }
         public bool ApiBuildPackage { get; set; }
        
        public void branchCloning()
        {
                       
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\api_params.json";
            string json = File.ReadAllText(jsonPath);
            var branchSettings = JsonConvert.DeserializeObject<BranchSettings>(json);
            var packageSettings = JsonConvert.DeserializeObject<PackageSettings>(json);
            var builderBranch = JsonConvert.DeserializeObject<BuilderBranch>(json);

            if (Directory.Exists($"D:\\GitHub\\PublishedPack\\api\\{packageSettings?.AliasSolution}"))
            {
                Console.WriteLine("Um repositorio de projeto ja existe, o mesmo será utilizado para construir os pacotes");
                PackageSettings pkg = new PackageSettings();
                pkg.buildingApiPackage(out string packageArguments);
            }
            else
            {
                branchSettings?.catchingGitParams();
            }
            
            if(builderBranch?.ApiBuildPackage == false && builderBranch?.AppBuildPackage == false)
            {
                Console.WriteLine("Nenhum pacote selecionado para clonagem");                         
            }
        }
    }

}