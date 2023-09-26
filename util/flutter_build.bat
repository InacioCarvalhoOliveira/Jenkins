@echo OFF 

SET buildPath=build
echo aaasaassaWWWWWW
:FlutterClean
echo [101;93m^+-------------------------------------------------^+[0m
echo [101;93m^|[0m Limpando build anterior...                     [101;93m^|[0m
echo [101;93m^+-------------------------------------------------^+[0m
call flutter clean

:FlutterBuildWeb
echo [101;93m^+-------------------------------------------------^+[0m
echo [101;93m^|[0m Gerando app browser...                     [101;93m^|[0m
echo [101;93m^+-------------------------------------------------^+[0m
call flutter build web

:Remove arquivos desnecessarios
echo [101;93m^+-------------------------------------------------^+[0m
echo [101;93m^|[0m Finalizando geracao...                     [101;93m^|[0m
echo [101;93m^+-------------------------------------------------^+[0m
rmdir /s /q %buildPath%\web\assets\assets
rmdir /s /q %buildPath%\web\assets\images
del %buildPath%\web\assets\dotenv
cd %buildPath%
rename web AppConsorcio

echo [102;93m^+-------------------------------------------------^+[0m
echo [102;93m^|[0m Geracao do app browser finalizada...               [102;93m^|[0m
echo [102;93m^+-------------------------------------------------^+[0m