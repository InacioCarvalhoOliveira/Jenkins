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
                // Access the selected choice parameter
                echo "Senha=${params.Senha}"
                echo "Usuario=${params.Usuario}"
                echo "Pacote=${params.Pacote}"
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
