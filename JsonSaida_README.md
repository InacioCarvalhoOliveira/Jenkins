**Parâmetros de saída Json **

A partir do Json de entrada estes dados são setados no Json que é consumido pela aplicação para
construir os pacotes

    1. "AppBuildPackage": "true" or "false" **--Required**
    2. "ApiBuildPackage": "true" or "false" **--Required**
    3. "ServiceBuildPackage":"true" or "false" **--Required**
    4. "Branch":"" **--Optional**
    5. "BranchName":"develop" / "master" it depends **--Required**
    6. "TFSLink":"https://tfs.seniorsolution.com.br/Consorcio" **--Non Modified**
    7. "TagGit":"_git" **--Non Modified**
    8. "Project":"SQCONS-WebApi" **--Required**
    9. "Repository":"SQConsorcio.API" **--Required**
    10. "Usuario":"inacio.oliveira" **--Required**
    11. "Dominio":"@sinqia.com.br" **--Non Modified**
    12. "SkdVersion":"C:/Program Files/dotnet/sdk/5.0.408/dotnet" **--Required**
    13. "PackagePath":"J:/sqmsbuild/PublishedPack" **--Required**
    14. "PackageType":"apis" **--Required**
    15. "Pubmode":"Release" **--Required**
    16. "SolutionPlatform":"win-x64" **--Required**
    17. "PathProject":"J:/sqmsbuild/PublishedPack" **--Required**
    18. "NameProj":"SQConsorcio" **--Non Modified**
    19. "SolutionProject":"API" **--Required**
    20. "AliasSolution":"zema" **--Required**
    21. "AliasPublication":"vendas" **--Required**
    22. "SendTo":"J:/pub/apis" **--Required**

---

| ITEM 8          | ITEM 9                                                          | ITEM 19                                                   |
| --------------- | --------------------------------------------------------------- | --------------------------------------------------------- |
| SQCONS-WebApi   | SQCONSOCIO.API / SQCONSOCIO.Pix / SQCONSOCIO.REINF / SQPix | API / APIVENDAS / APICONSORCIADO / SERVICE / CONFIGURADOR |
| SQCONS-APP      | SQCONS-APP                                                      | **Non Required**                                    |
| SQCONS-PLENOWEB | SQCONS-PLENOWEB / V14 / V15                                     | Consulte na tabela de soluções dispoíveis abaixo       |
| SQCONS-PLENO    | SQCONS-PLENP / V14 / V15                                        |                                                           |

---

| Soluções SQCONS-PLENOWEB                    |
| ---------------------------------------------- |
| PlenoWeb                                       |
| Webconsorciado(Demais Clientes)/WebConsorciado |
| Silveright/Torresan                            |
| Pleno/Pleno                                    |
