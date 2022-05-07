#!/bin/bash

while getopts d:s:p: flag
do
    case "${flag}" in
        d) directory=${OPTARG};;
        s) solution_name=${OPTARG};;
        p) project=${OPTARG};;
    esac
done

project_path=${directory}/${project}

mkdir -p ${project_path}
mkdir ${project_path}/src
mkdir ${project_path}/test
mkdir ${project_path}/docker-compose
touch ${project_path}/README.md 
touch ${project_path}/.gitignore
touch ${project_path}/.dockerignore
touch ${project_path}/azure-pipelines.yml
touch ${project_path}/azure-pipelines-test.yml
touch ${project_path}/azure-pipelines-container.yml
touch ${project_path}/docker-compose/docker-compose.yml
touch ${project_path}/docker-compose/docker-compose.sql-server.yml
touch ${project_path}/Dockerfile
touch ${project_path}/.env-sample
touch ${project_path}/Makefile

dotnet new sln --name ${solution_name} --output ${project_path}
func init ${project_path}/src/Function --worker-runtime dotnet-isolated --template "Service Bus Queue trigger" # "Azure Event Hub trigger"

dotnet new classlib --name Domain --output ${project_path}/src/Domain
dotnet new classlib --name Infrastructure --output ${project_path}/src/Infrastructure
dotnet new classlib --name Application --output ${project_path}/src/Application

dotnet new xunit --name ComponentTest --output ${project_path}/test/ComponentTest
dotnet new xunit --name IntegrationTest --output ${project_path}/test/IntegrationTest
dotnet new xunit --name UnitTest --output ${project_path}/test/UnitTest
dotnet new xunit --name EndToEndTests --output ${project_path}/test/EndToEndTests
 
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/src/Function/Function.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/src/Domain/Domain.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/src/Infrastructure/Infrastructure.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/src/Application/Application.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/test/ComponentTest/ComponentTest.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/test/IntegrationTest/IntegrationTest.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/test/UnitTest/UnitTest.csproj
dotnet sln "${project_path}/${solution_name}.sln" add ${project_path}/test/EndToEndTests/EndToEndTests.csproj
dotnet restore ${project_path}