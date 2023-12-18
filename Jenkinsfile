pipeline {
    agent any
    
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster') 
        string(name: 'Usuario', defaultValue: '', description: 'Usuário Hoster')
        choice(
            name: 'Pacote',
            description:'Descrição dos pacotes:\n- V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb, VendasService, APIService, Pleno;\n- V16: APPConsorcio, APIVendas, APIService, APIConsorciado;\n- *V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;\nOu então gere os pacotes individualmente logo abaixo',
            choices:['V15','V16','*V16'])
        choice(
            name: 'Pacotes individuais',
            description:'Versão desejada para pacotes individuais\nobs:\nV15 - Release Legada;\nV16 - Release Atual;\n*V16 - Release atual com front legado',
            choices:['V15','V16','*V16'])

        booleanParam(name:'APIVendas', defaultValue:false)
        booleanParam(name:'APIService', defaultValue:false)
        booleanParam(name:'APIConsorciado', defaultValue:false)
        booleanParam(name:'APPConsorcio', defaultValue:false)
        booleanParam(name:'*APPVendas', defaultValue:false, description:'obs: legado')
        booleanParam(name:'*APPConsorciado', defaultValue:false, description:'obs: legado')
        booleanParam(name:'*WEBConsorciado', defaultValue:false, description:'obs: legado')
        booleanParam(name:'*PlenoWeb', defaultValue:false, description:'obs: legado')
        booleanParam(name:'*PlenoService', defaultValue:false, description:'obs: legado')
        booleanParam(name:'*VendasService', defaultValue:false, description:'obs: legado')            
    }
    stages {
        stage("Build") {
             steps {
                script {
                    def parametrosJson = [
                        Senha: params.Senha,
                        Usuario: params.Usuario,
                        Pacote: params.Pacote,
                        'Pacotes individuais': params['Pacotes individuais'],
                        APIVendas: params.APIVendas,
                        APIService: params.APIService,
                        APIConsorciado: params.APIConsorciado,
                        APPConsorcio: params.APPConsorcio,
                        '*APPVendas': params['*APPVendas'],
                        '*APPConsorciado': params['*APPConsorciado'],
                        '*WEBConsorciado': params['*WEBConsorciado'],
                        '*PlenoWeb': params['*PlenoWeb'],
                        '*PlenoService': params['*PlenoService'],
                        '*VendasService': params['*VendasService']
                    ]

                    def jsonString = groovy.json.JsonOutput.toJson(parametrosJson)
                    writeFile file: 'parametros.json', text: jsonString
                    
                    // Lê o conteúdo do arquivo parametros.json
                    def parametrosContent = readFile('parametros.json').trim()
                    
                    // Converte o conteúdo para um objeto JSON
                    def parametrosObject = readJSON text: parametrosContent
                    
                    // Acessa a propriedade APIVendas do objeto JSON
                    def jenkinsURL = "${parametrosObject.APIVendas}/build"  // Substitua com o caminho correto na API

                    // Imprime a URL construída (opcional)
                    echo "URL da API do Jenkins: ${jenkinsURL}"
                }
            }
        }
        
        stage("Serializing params to Json") {
            steps {
                archiveArtifacts artifacts: 'parametros.json', allowEmptyArchive: false
            }
        }
        stage("Deploy") {
            steps {
                echo "Deploying the app..."
            }
        }
    }
}

stage("Build") {
    steps {
        script {
            // Lê o conteúdo do arquivo parametros.json

            // Converte o conteúdo para um objeto JSON
            def parametrosJson = readJSON text: parametrosContent

            // Constrói a URL da API do Jenkins com base nos parâmetros lidos

            // Utilize 'jenkinsURL' para acessar dinamicamente a API do Jenkins
            // Realize as operações necessárias com essa URL
        }
    }
}

