using System.Diagnostics;
using Newtonsoft.Json;

namespace gitConfig
{
    class BranchSettings
    {
        public string Repository { get; set; }
        public string Branch { get; set; }          
        public string BranchName { get; set; }
        public string TFSLink { get; set; }
        
                  
        private ProcessStartInfo gitStartInfo;

        public void catchingJsonParams()
        {
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";

            try
            {
                // Lê o conteúdo do arquivo JSON
                string json = File.ReadAllText(jsonPath);
                // Faz o parsing do JSON para um objeto
                BranchSettings obj = JsonConvert.DeserializeObject<BranchSettings>(json);
                // Obtém o valor da propriedade BranchName
                string branchName = obj.BranchName;
                string branch = obj.Branch;
                string tfsLink = obj.TFSLink;
                string repository = obj.Repository;
                 gitStartInfo = new ProcessStartInfo
                {
                    FileName = "git",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                //modified Argument
                //feature/SQPLGR-19470_MelhoriaLog_Inacio" "https://tfs.seniorsolution.com.br/Consorcio/SQCONS-WebApi/_git/SQConsorcio.API"
                gitStartInfo.Arguments = $"clone --single-branch --branch {branch}{branchName}{tfsLink}{repository}";
                // Start the process
                Process gitProcess = new Process();
                gitProcess.StartInfo = gitStartInfo;
                gitProcess.Start();
                // Read the output
                //branchName = gitProcess.StandardOutput.ReadToEnd().Trim();

                // Wait for the process to exit
                gitProcess.WaitForExit();   
                // Display the branch name
                Console.WriteLine("Branch Repository: " + branch);
                Console.WriteLine("Branch to be Cloned: " + branchName);

            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error parsing the JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }       
            
        }

        public void settingProcessInfo()
        {
        
        }
    }

}

