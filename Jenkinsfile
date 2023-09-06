pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster') 
        string(name: 'Usuario', defaultValue: '', description: 'Usuário Hoster')
        choice(
            name: 'Escolha dos pacotes a serem gerados',
            description: 'Descrição dos pacotes:
                        -  V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb,
                                VendasService, APIService, Pleno;
                        -  V16: APPConsorcio, APIVendas, APIService, APIConsorciado;
                        - *V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;                    
                        Ou então gere os pacotes individualmente logo abaixo',
            choices:['V15','V16','*V16'],
            defaultValue: 'Escolha...',
            restrict: true,
            filterConfig: filterConfig(prefix: true, caseInsensitive: true))
            
    }
    stages {
        stage("Build") {
            steps {
                echo "Senha=${params.Senha}"
                echo "Usuario=${params.Usuario}"
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
