using System.Text;

namespace Jenkins.Services
{
    class JenkinsApiService
    {
        private readonly string _jenkinsUrl;
        private readonly string _user;
        //private readonly string _password;

        public JenkinsApiService(string jenkinsUrl, string? user)
        {
            _jenkinsUrl = jenkinsUrl;
            _user = user;
            // _password = password;
        }

        public async Task<string> GetJsonDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Adicionar autenticação básica, se necessário
                if (!string.IsNullOrEmpty(_user))
                {
                    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_user}"));
                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");
                }

                try
                {
                    // Fazer uma solicitação GET à URL do Jenkins
                    HttpResponseMessage response = await client.GetAsync(_jenkinsUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Ler e retornar o JSON retornado
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new Exception($"Erro na solicitação: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro na solicitação: {ex.Message}");
                }
            }
        }
    }
}
