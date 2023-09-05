pipeline {
    agent any
    parameters {
        editableChoice(
        //name: 'Senha do Hoster admin da maquina',
        password(name: 'PasswdHoster', defaultValue: '', description: 'Enter your password')
        // password(name: 'PASSWORD', defaultValue: '', description: 'Enter your password')
        // password(name: 'PASSWORD', defaultValue: '', description: 'Enter your password')
        // password(name: 'PASSWORD', defaultValue: '', description: 'Enter your password')
        // password(name: 'PASSWORD', defaultValue: '', description: 'Enter your password')
    )
  }
   
    }
    stages {        
        stage("Build") {
            steps {
                echo "PasswdHoster=${params.PASSWORD}"
                // echo "PASSWORD=${params.PASSWORD}"
                // echo "PASSWORD=${params.PASSWORD}"
                // echo "PASSWORD=${params.PASSWORD}"
            }



            steps {
            echo "Building the app..."
                sh '''
                    echo "This block contains multi-line steps"
                    ls -lh
                '''
                sh '''
                    echo "Database url is: ${DB_URL}"
                    echo "DISABLE_AUTH is ${DISABLE_AUTH}"
                    env
                '''
                echo "Running a job with build #: ${env.BUILD_NUMBER} on ${env.JENKINS_URL}"
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