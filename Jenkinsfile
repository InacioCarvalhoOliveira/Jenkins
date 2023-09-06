pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster') 
        string(name: 'Usuario', defaultValue: '', description: 'Usuário Hoster')
            choice(
                name: 'Escolha dos pacotes a serem gerados',
                description:'<ul>
                                 <li>V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb, VendasService, APIService, Pleno;</li>
                                 <li>V16: APPConsorcio, APIVendas, APIService, APIConsorciado;</li>
                                 <li>*V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;</li>
                                 Ou então gere os pacotes individualmente logo abaixo:
                             </ul>',
                choices:['V15','V16','*V16'])
                
    }
    stages {
        stage("Build") {
            steps {
                // Access the selected choice parameter
                    def selectedChoice = params.MyDynamicChoiceParameter
                    echo "Selected choice: ${selectedChoice}"
                //echo "Senha=${params.Senha}"
                //echo "Usuario=${params.Usuario}"
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
