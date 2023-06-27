using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace processConfig
{
    class ProcessSettings
    {

        public string Usuario { get; set; }
        public string Senha { get; set; }
       
        void  _ProcessSettings()
        {
            string senha = Senha;    
        }
        
        public void grantingPermission()
        {         
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json"; 
            string usuario = "inacio.oliveira";//obj.Usuario;
            string senha = "Flocktro0per.UHK66";//bj.Senha;      
        
            try
            {               
                Console.WriteLine("Usuário logado:" + usuario);                
                string senhaGerada = gerarSenha(senha);
                string json = File.ReadAllText(jsonPath);
                var obj = JsonConvert.SerializeObject(value: _ProcessSettings);
            }
            catch (IOException ex)  
            { Console.WriteLine("Error reading the file: " + ex.Message);}
             catch (JsonException ex)
            { Console.WriteLine("Error parsing the JSON: " + ex.Message);}
             catch (Exception ex)
            { Console.WriteLine("Error: " + ex.Message);}
        }

        public static String gerarSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
                return hashedPassword = senha;
            }
        }      
        /*TODO tela que solicite a senha para que seja passada pelo terminal dos, e após autenticado enviar senha encriptografada
        para json params*/  
        #region 
        //permissao para acesso ao TFS por meio do usuario, necessário ter permissão no sistema
        //  $username = "inacio.oliveira"
        //  $password = ConvertTo-SecureString -String "Flocktro0per.UHK66" -AsPlainText -Force
        //  $cred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $username, $passwor
        //  # Fazer a solicitação ao site usando as credenciais
        //  $response = Invoke-WebRequest -Uri "https://tfs.seniorsolution.com.br/Consorcio" -Credential $cred
        #endregion

    }
}
