pipeline {
    agent any
    parameters {
        password(name: 'Senha', defaultValue: '', description: 'Senha Hoster'),
        string(name: 'Usuario', defaultValue: '', whitespace= False, description: 'Usuario Hoster')
        
        

       
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
