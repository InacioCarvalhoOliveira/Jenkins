pipeline {
    agent any
    stages {
        stage("Build") {
            steps { 
            echo "Building the app..."
                sh '''
                    echo "buildando projeto"
                    dotnet run
                '''
            }
        }
    }
post {
        always {
            echo "This will always run regardless of the completion status"
        }
        success {
            echo "This will run if the build succeeded"
        }
        failure {
            echo "This will run if the job failed"
        }
        unstable {
            echo "This will run if the completion status was 'unstable', usually by test failures"
        }
        changed {
            echo "This will run if the state of the pipeline has changed"
            echo "For example, if the previous run failed but is now successful"
        }
        fixed {
            echo "This will run if the previous run failed or unstable and now is successful"
        }
    }
}
