using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using processConfig;
using packageConfig;

namespace gitConfig
{
    class BuilderBranch
    {

        public void branchCloning()
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
            string aliasSolution = packageSettings.AliasSolution;

            if (Directory.Exists($"D:\\GitHub\\PublishedPack\\api\\{aliasSolution}"))
            {
                Console.WriteLine("Um repositorio de projeto ja existe");
                PackageSettings pkg = new PackageSettings();
                pkg.buildingPackage(out string packageArguments);
            }
            else
            {
                branchSettings.catchingGitParams();
            }
        }

    }
}