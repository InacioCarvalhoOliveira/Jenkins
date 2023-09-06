pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster'),
        string(name: 'Usuario', defaultValue: '', whitespace= False, description: 'Usuario Hoster')
        choice(
            name: 'Escolha dos pacotes a serem gerados',
            defaultValue: '',
            choices:['V15','V16','*V16'],
            description: 'Descrição dos pacotes:
                        -  V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb,
                                VendasService, APIService, Pleno;
                        -  V16: APPConsorcio, APIVendas, APIService, APIConsorciado;
                        - *V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;                    
                        Ou então gere os pacotes individualmente logo abaixo'),
            restrict: true,
            filterConfig:[prefix:false,caseInsensitive:false]
        

       
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
