using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using gitConfig;
using Newtonsoft.Json;

/*TODO tela que solicite a senha para que seja passada pelo terminal dos, e após autenticado enviar senha encriptografada
para json params*/  

namespace processConfig
{
    class ProcessSettings: BranchSettings
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        
        public void authUser(out string arguments)
        { 
            // TODO: melhorarar a busca do arquivo json
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";              
                          
            string json = File.ReadAllText(jsonPath);
            var obj = JsonConvert.DeserializeObject<ProcessSettings>(json);
            string senha = obj.Senha;
            string usuario = obj.Usuario;
            string tfsLink = obj.TFSLink;
            #region 
            // TODO: encriptografia da senha passada/recebida no json
            // using (SHA256 sha256 = SHA256.Create())
            // {
            //     byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            //     string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            //     Console.WriteLine(senha+"="+hashedPassword);
            // }
            #endregion              
            
            string[] param = new string[4];
            param[0] = $@"$user = ""{usuario}""; ";     
            param[1] = $@"$password = ConvertTo-SecureString -String ""{senha}"" -AsPlainText -Force;";     
            param[2] = "$cred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $user, $password;"; 
            param[3] = $@"$response = Invoke-WebRequest -Uri ""{tfsLink}"" -Credential $cred;";

            StringBuilder scriptBuilder = new StringBuilder();

            foreach (string item in param)
            {
                scriptBuilder.AppendLine(item);
            }
            //coleta os itens do foreach e armazena tipo dado de retorno do método. 
            arguments = scriptBuilder.ToString();                                                                                                                 
        }
    }
}
