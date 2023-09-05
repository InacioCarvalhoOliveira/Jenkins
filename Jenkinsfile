pipeline {
    agent any
    parameters {
        password(name: 'PasswdHoster', defaultValue: '', description: 'Enter your password')
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
