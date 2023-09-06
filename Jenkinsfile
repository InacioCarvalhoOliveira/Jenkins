pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster'),
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster')
        //string(name: 'Usuario', defaultValue: '', whitespace= false, description: 'Usuario Hoster'),
        
       
    }
    stages {
        stage("Build") {
            steps {
                echo "Senha=${params.Senha}"
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
