using System.Collections.Generic;
using System.Diagnostics;
using gitConfig;

namespace packageConfig
{
    class PackageSettings : BranchSettings
    {
        public string? PackageType { get; set; }// zip,default
        public string PublishType { get; set; }// api,web,app(android/ios)
        public string BranchSelected { get; set; }// Master,Develop,CustomBranch
        public List<SolutionSettings>? SolutionConfigs { get; set; }// 
        public string? DirToDrop { get; set; }
        public void buildingPakcage()
        {           
          
            
        }
    }

}