pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster') 
        password(name: 'Senha2', defaultValue: '', description: 'Senha Hoster')      
    }
    stages {
        stage("Build") {
            steps {
                echo "Senha=${params.Senha}"
                echo "Senha2=${params.Senha2}"
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
