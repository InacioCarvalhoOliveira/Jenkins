using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using gitConfig;
using Newtonsoft.Json;

namespace processConfig
{
    class ProcessSettings: BranchSettings
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
       
        public void authUser()
        { 
            // TODO: melhorarar a busca do arquivo json
            string jsonPath = "D:\\GitHub\\Jenkins\\util\\params.json";              
            try
            {               
                string json = File.ReadAllText(jsonPath);
                var obj = JsonConvert.DeserializeObject<ProcessSettings>(json);
                string senha = obj.Senha;
                string usuario = obj.Usuario;
                string urlTfs = obj.TFSLink;
                Process settingProcess = new Process();
                #region 
                // TODO: encriptografia da senha passada/recebida no json
                    // using (SHA256 sha256 = SHA256.Create())
                    // {
                    //     byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                    //     string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
                    //     Console.WriteLine(senha+"="+hashedPassword);
                    // }
                #endregion              

                tfsauth(usuario,senha);

                void tfsauth(string _usuario,string _senha)
                {

                    if(_usuario.Equals(usuario) &&  _senha.Equals(senha))
                    {              
                        string usrParam = $@" ""{_usuario}"" ";
                        string pswdParam = $@" ""{_senha}"" ";

                        string[] param = new string[4];
                        param[0] = $@"$usuario = ""{_usuario}"" ";     
                        param[1] = $@"$password = ConvertTo-SecureString -String ""{_senha}"" -AsPlainText -Force";     
                        param[2] = $"$cred = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList {usrParam}, {pswdParam}"; 
                        param[3] = $@"$response = Invoke-WebRequest -Uri ""{urlTfs}"" -Credential $cred";  
                        
                        foreach (string item in param)
                        {
                            Console.WriteLine(item);                
                                          
                        }                        
                    }                    
                }
            }
            catch (IOException ex)  
            { Console.WriteLine("Erro na leitura do arquivo: " + ex.Message);}
             catch (JsonException ex)
            { Console.WriteLine("Erro no formato de parametro JSON: " + ex.Message);}
             catch (Exception ex)
            { Console.WriteLine("Erro: " + ex.Message);}

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
