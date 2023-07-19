using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using gitConfig;
using Newtonsoft.Json;

/*TODO tela que solicite a senha para que seja passada pelo terminal dos, e após autenticado enviar senha encriptografada
para json params*/  

namespace processConfig
{
    class ConsoleSettings: BranchSettings
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Dominio { get; set; }
        
        public const string TFSCONTENT = "$response.Content";

        public void authUser(out string arguments)
        { 
            
            // TODO: melhorarar a busca do arquivo json
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";              
                          
            string json = File.ReadAllText(jsonPath);
            var obj = JsonConvert.DeserializeObject<ConsoleSettings>(json);
            string senha = obj.Senha;
            string usuario = obj.Usuario;
            string dominio = obj.Dominio;
            string tfsLink = obj.TFSLink;
             
            #region 
            // TODO: permissão de adm do powershel por comando
            //$@"runas /user:""{usuario}""+""{dominio}"" ""powershell""");   
            // TODO: encriptografia da senha passada/recebida no json
            // using (SHA256 sha256 = SHA256.Create())
            // {
            //     byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            //     string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            //     Console.WriteLine(senha+"="+hashedPassword);
            // }
            #endregion              
            
            string[] param = new string[4];
            param[0] = $"$user = '{usuario}'; ";  
            param[1] = $"$password = ConvertTo-SecureString -String '{senha}' -AsPlainText -Force; ";   
            param[2] = "$cred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $password; ";
            param[3] = $"$response = Invoke-WebRequest -Uri '{tfsLink}' -Credential $cred; ";
             

            StringBuilder scriptBuilder = new StringBuilder();
            foreach (string item in param)
            {
                scriptBuilder.AppendLine(item);
            }           
            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            // TODO: forma de validar se no stringbuilder vem conteudo para depois jogar 'arguments'
            string rawArguments = scriptBuilder.ToString();
            string correctedArguments = rawArguments.Replace("\"", "").Replace("\r\n", "");
            arguments = correctedArguments;//+TFSCONTENT;
        }
    }
}
