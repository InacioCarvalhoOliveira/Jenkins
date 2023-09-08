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
            // steps {
            //     // Access the selected choice parameter
            //     echo "Senha=${params.Senha}"
            //     echo "Usuario=${params.Usuario}"
            //     echo "Pacote=${params.Pacote}"                
            //     echo "APIVendas=${params.APIVendas}"
            //     echo "APIVendas=${params.APIVendas}"
            //     echo "APPConsorcio=${params.APPConsorcio}"
            //     echo "APPConsorcio=${params.APPConsorcio}"
            //     echo "*APPVendas=${params.*APPVendas}"
            //     echo "*APPConsorciado=${params.*APPConsorciado}"
            //     echo "*WEBConsorciado=${params.*WEBConsorciado}"
            //     echo "*PlenoWeb=${params.*PlenoWeb}"
            //     echo "*PlenoService=${params.*PlenoService}"
            //     echo "*VendasService=${params.*VendasService}"
            // }

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

                    // Imprime o JSON (opcional)
                    echo "JSON de Parâmetros: ${jsonString}"
                }
        }
        stage("Test") {
            steps {
                echo "Testing the app..."
            }
        }
        stage("Deploy") {
            steps {
                echo "Deploying the app..."
            }
        }
    }
}
