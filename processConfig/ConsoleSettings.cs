using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using gitConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/*TODO tela que solicite a senha para que seja passada pelo terminal dos, e após autenticado enviar senha encriptografada
para json params*/

namespace processConfig
{
    class ConsoleSettings : BranchSettings
    {
        public string? Usuario { get; set; }
        public string? HashSenha { get; set; }
        public string? TfsResponse {get; set;} = "$response.Content";

        public void authUser(out string authArguments)
        {

            // TODO: melhorarar a busca do arquivo json
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\api_params.json";

            string json = File.ReadAllText(jsonPath);
            var consoleSettings = JsonConvert.DeserializeObject<ConsoleSettings>(json);
   
            //Console.WriteLine($"informe a senha:");           
            var senha1 = "Flocktro0per.UHK70";
            //string senha = Console.ReadLine();          

            string[] param = new string[5];
            param[0] = $"$user = '{consoleSettings?.Usuario}'; ";
            param[1] = $"$password = ConvertTo-SecureString -String '{senha1}' -AsPlainText -Force; ";
            param[2] = "$cred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $password; ";
            param[3] = $"$response = Invoke-WebRequest -Uri '{consoleSettings?.TFSLink}' -Credential $cred; ";
            param[4] = $"{TfsResponse}";

            StringBuilder scriptBuilder = new StringBuilder();
            foreach (string item in param)
            {
                scriptBuilder.AppendLine(item);
            }
            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            // TODO: forma de validar se no stringbuilder vem conteudo para depois jogar 'arguments'
            string rawArguments = scriptBuilder.ToString();
            string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
            authArguments = correctedArguments;
        }
       
    }
}
