using System;
using System.Diagnostics;

namespace gitConfig
{
    class BranchSettings
    {
        private string BranchName { get; set; }          
        private ProcessStartInfo gitStartInfo;
        public void settingProcessInfo()
        {
            gitStartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "branch --show-current",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            //modify branch 
            gitStartInfo.Arguments = "branch --show-current";
            // Start the process
            Process gitProcess = new Process();
            gitProcess.StartInfo = gitStartInfo;
            gitProcess.Start();

            // Read the output
            BranchName = gitProcess.StandardOutput.ReadToEnd().Trim();

            // Wait for the process to exit
            gitProcess.WaitForExit();

            // Display the branch name
            Console.WriteLine("Current branch: " + BranchName);
        
        }
    }

}