## parâmetros Json de entrada
**onde: * = Obrigatório** <br>
**onde: ? = Opcional**


    1 -  bool ApiBuildPackage: - Gera pacotes e Kits API's V15 e V16
    2 -  bool AppBuildPackage: - Gera paoctes e Kits Web V15 e V16
    2 -  bool ServiceBuildPackage: - Gera pacotes e Kits Services V15  
  
    3 -  string? Branch: <null> branch 'Customizável' para cliente  
    4 -  string* BranchName: <develop> ou <master> padrão  
    5 -  string* TFSLink: <https://tfs.seniorsolution.com.br/Consorcio> padrão
    6 -  string* TagGit:  <_git> padrão
    7 -  string* Project: ver <PARÂMETROS REPOSITÓRIOS TFS>
    8 -  string* Repository: ver <PARÂMETROS REPOSITÓRIOS TFS>
    9 -  string* Usuario: usuário dev hoster 
    10 - string* Dominio: <@sinqia.com.br> padrão Sinqia
  
    11 - string* SkdVersion: <C:/Program Files/dotnet/sdk/5.0.408/dotnet> validar Path máquina
    12 - string* PackagePath: caminho de saída pacotes 'Customizável'
  
    13 - string* PackageType: ver <PARÂMETROS PACOTES DE SAÍDA>
    14 - string* Pubmode: <Release> ou <Debug> padrão 
  
    15 - string* SolutionPlatform: <win-x64> padrão
 
    16 - string* PathProject: caminho de saída pacotes 'Customizável'
    17 - string* NameProj:
  
    18 - string* SolutionProject: <API> somente 
  
    19 - string* AliasSolution: <empresa> nome para pasta centralizada dos pacotes
    20 - string* AliasPublication: <nome_pacote> para identifica-lo
    21 - string* SendTo: caminho dos pacotes publicados 
##
## Exemplo funcional
    {
        "AppBuildPackage":"false",
        "ApiBuildPackage":"true",
        "ServiceBuildPackage":"false",
        
        "Branch":"",
        "BranchName":"develop",
        "TFSLink":"https://tfs.seniorsolution.com.br/Consorcio",
        "TagGit":"_git",
        "Project":"SQCONS-PLENOWEB",
        "Repository":"V15",
        
        "Usuario":"inacio.oliveira",
        "Dominio":"@sinqia.com.br",
        
        "SkdVersion":"C:/Program Files/dotnet/sdk/5.0.408/dotnet",
        "PackagePath":"D:/GitHub/PublishedPack",
        "PackageType":"services",
        "Pubmode":"release",
        "SolutionPlatform":"win-x64",
        "PathProject":"D:/GitHub/PublishedPack",
        "NameProj":"WebConsorciado",
        "SolutionProject":"API",
        "AliasSolution":"xpto",
        "AliasPublication":"webconsorciado",
        "SendTo":"D:/GitHub/PublishedPack/pub"
    }

## Parâmetros recebidos do Jenkins
    {
        "Usuario":"inacio.oliveira",
        "Senha":"xpto",

        "AppBuildPackage":"false",
        "ApiBuildPackage":"true",
        "ServiceBuildPackage":"false",
        
        "Branch":"",
        "BranchName":"develop",
        "Project":"SQCONS-PLENOWEB",
        "Repository":"V15",
        
        
        "PackagePath":"D:/GitHub/PublishedPack",
        "PackageType":"services",
        "Pubmode":"release",
        "SolutionPlatform":"win-x64",
        "PathProject":"D:/GitHub/PublishedPack",

        "NameProj":"WebConsorciado",
        "SolutionProject":"API",
        "AliasSolution":"xpto",
        "AliasPublication":"webconsorciado",

        "SendTo":"D:/GitHub/PublishedPack/pub"
    }

**PARÂMETROS REPOSITÓRIOS TFS**                                                                  
| Project         | Repository                                          | SolutionProject|
|-----------------|---------------------------------------------------  |----------------|
| SQCONS-APP      | SQCONS-APP                                          | **pubspeck.yaml**  |
| SQCONS-PLENO    | v14, v15, SQCONS-PLENO                              | **null**           |
| SQCONS-WebApi   | SQConsorcio.API, SQConsorcio.Pix, SQConsorcio.REINF | **SQConsorcio.API.sln**, **SQConsorcio.API.sln**, **SQConsorcio.API.sln**, **SQConsorcio.API.sln**                        |
| SQCONS-PLENOWEB | V14, V15, SQCONS-PLENOWEB                           | PlenoWeb.sln, WebConsorciado(**v15**, **SOCONS-PLENOWEB**)|
|                                                                                                                                   |

**PARÂMETROS PACOTES DE SAÍDA**                                                                  
| Project | Repository                                          
|---------|---------------------------------------------------      |
| **app**     | APPConsorcio,                                       |
| **web**     | APPConsorciado, AppVendas, WebConsorciado, PlenoWeb |
| **api**     | APIVendas, APIService, APIConsorciado               |
| **service** | VendasService, Pleno, APIService                    |
|                                                                   |
