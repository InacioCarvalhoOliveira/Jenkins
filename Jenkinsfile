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
}