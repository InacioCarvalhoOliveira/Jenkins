pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster') 
        string(name: 'Usuario', defaultValue: '', description: 'Usuário Hoster')
            choice(
                name: 'Escolha dos pacotes a serem gerados',
                description:'Descrição dos pacotes:\n- V15: APPConsorciado, AppVendas, WebConsorciado, PlenoWeb, VendasService, APIService, Pleno;\n- V16: APPConsorcio, APIVendas, APIService, APIConsorciado;\n- *V16: APPConsorciado, AppVendas, APIVendas, APIService, APIConsorciado;\nOu então gere os pacotes individualmente logo abaixo:',
                type: 'PT_SINGLE_SELECT',
                groovyScript: '''
                    def choices = ['a','b','c']
                    def textFileContents  = readFile('D:/GitHub/Jenkins/util/teste.html').trim()
                    textFileContents.eachLine{
                        line -> choices << line
                    }
                    return choices
                ''',
                defaultValue:'a')
                //choices:['V15','V16','*V16'])
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
