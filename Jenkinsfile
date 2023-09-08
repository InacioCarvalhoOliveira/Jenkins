pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster') 
        string(name: 'Usuario', defaultValue: '', description: 'Usuário Hoster')
            choice(
                name: 'Pacote',
                description:'Descrição dos pacotes:\n- V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb, VendasService, APIService, Pleno;\n- V16: APPConsorcio, APIVendas, APIService, APIConsorciado;\n- *V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;\nOu então gere os pacotes individualmente logo abaixo',
                choices:['V15','V16','*V16'])
            boolean(name:'01',defaultValue=false,description='teste')
            boolean(name:'02',defaultValue=false,description='teste')
            boolean(name:'03',defaultValue=false,description='teste')
            boolean(name:'04',defaultValue=false,description='teste')
            boolean(name:'05',defaultValue=false,description='teste')
            boolean(name:'06',defaultValue=false,description='teste')
            boolean(name:'07',defaultValue=false,description='teste')
            boolean(name:'08',defaultValue=false,description='teste')
            boolean(name:'09',defaultValue=false,description='teste')
                
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
