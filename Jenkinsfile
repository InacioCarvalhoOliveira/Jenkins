pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster'),
        string(name: 'Usuario', defaultValue: '', whitespace= False, description: 'Usuario Hoster')
        editableChoice(
            name: 'Escolha dos pacotes a serem gerados',
            defaultValue: '',
            choices:['V15','V16','*V16'],
            description: 'Descrição dos pacotes:
                        -  V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb,
                                VendasService, APIService, Pleno;
                        -  V16: APPConsorcio, APIVendas, APIService, APIConsorciado;
                        - *V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;                    
                        Ou então gere os pacotes individualmente logo abaixo'),
        restrict(name: 'APPConsorcio', description: 'versão'),
        restrict(name: 'APPConsorciado', description: 'versão'),
        restrict(name: 'APPVendas', description: 'versão'),
        restrict(name: 'APPService', description: 'versão'),
        restrict(name: 'WebConsorciado', description: 'versão'),
        restrict(name: 'PlenoWeb', description: 'versão'),
        restrict(name: 'APIVendas', description: 'versão'),
        restrict(name: 'APIService', description: 'versão'),
        restrict(name: 'APIConsorciado', description: 'versão'),
        restrict(name: 'VendasService', description: 'versão'),
        restrict(name: 'Pleno', description: 'versão'),

       
    }
    stages {
        stage("Build") {
            steps {
                echo "PasswdHoster=${params.PasswdHoster}"
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
