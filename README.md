## Integração contínua com Jenkins

Recursos utilizados:
- Versão SDK DotNet : V6.0.118 [**Baixe aqui**](https://github.com/dotnet/core/blob/main/release-notes/6.0/6.0.18/6.0.118.md) .Disponível também na estrutura do projeto **/Jenkins/SDK6.0**;
- Plugin MSBuild Jenkins;
- IDE Visual Studio Code e extensões:

        1 - ms-dotnettools.vscode-dotnet-runtime; 
        2 - ms-dotnettools.csharp;


#
## Diagrama de Implantação Jenkins
![diagramaIpl](./images/cd-pleno.png)
#


# gap de erros: 

o clone ocorre apenas 1 vez ao autenticar o usuário, contudo se for fazer um processo para gerar 3 pacotes( vendas,service,consoriciado) por exemplo dá o erro 

erro: MSBuild version 17.3.2+561848881 for .NET
MSBUILD : error MSB1009: Arquivo de projeto não existe.
Opção: D:/GitHub/PublishedPack/api/develop_APIVendas/SQConsorcio.APIVendas.sln
Command executed in: 662,226 ms

obs: isto o ocrre devido a falta de condição, se o pacote clonado já existe, está gerando um novo pacote e quebrando a 
condição de branch que é feita nos arquivos de montagem de branch. verificar este ponto.

## Notas sobre Pipeline
uma pipeline é desenvolvida em comandos Groovy(segue a raia de CD - Continous Developing)

- job : a declaração de um processo a ser realizado;
- pipeline : uma sequencia de estagios no seu processo;
- estagio(stages) : é constituido de diversas etapas para realizar tarefas específicas;

declaração de comandos:
- stages : contem um conjunto de estágios
- stage : está contido em um conjunto de estágios

#  Gap de erros: 

        o clone ocorre apenas 1 vez ao autenticar o usuário, contudo se for fazer um processo para gerar 3 pacotes( vendas,service,consoriciado) por exemplo dá o erro. 
#
1 - err: MSBuild version 17.3.2+561848881 for .NET
MSBUILD : error MSB1009: Arquivo de projeto não existe.
Opção: D:/GitHub/PublishedPack/api/develop_APIVendas/SQConsorcio.APIVendas.sln
Command executed in: 662,226 ms

* isto o ocrre devido a falta de condição, se o pacote clonado já existe, está gerando um novo pacote e quebrando abcondição de branch que é feita nos arquivos de montagem de branch. verificar este ponto.
#
2 - err: Erro: Erro na solicitação: Nenhuma conexão pôde ser feita porque a máquina de destino as recusou ativamente. (localhost:8080)
Unhandled exception. System.IO.DirectoryNotFoundException: Could not find a part of the path 'D:\GitHub\Jenkins\util\api_params.json'.

* isto ocorre pois o Jenkins não foi inicializado, é necessário verificar se o endpoint que esta sendo passado a ele para capturar o arquivo json está correto também, para cada build uma nova requisição é lançada, verificar o incrememento, se bate com o da requisição dentro do laço de loop.
#   