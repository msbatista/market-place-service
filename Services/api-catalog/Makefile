BASE_DIR := ./
APP_NAME := catalog-api
TAG := v1
# ACR_REGISTRY := arclabtest

add_migration:
	@dotnet ef migrations add $(name) --project ./src/Infrastructure/ --startup-project ./src/WebApi/

update_db:
	@dotnet ef database update --project ./src/Infrastructure/ --startup-project ./src/WebApi/

rm_migration:
	@dotnet ef migrations remove --project ./src/Infrastructure/ --startup-project ./src/WebApi/

build:
	@echo "Building project"
	@dotnet restore src/WebApi/WebApi.csproj
	@dotnet build --configuration $(BUILD_CONFIGURATION)

publish:
	@echo "Publishing artificat"
	@dotnet publish src/WebApi/WebApi.csproj \
		--configuration $(BUILD_CONFIGURATION) \
		--output $(BUILD_STAGE_DIR) \
	    --no-restore
	@zip -r output.zip $(BUILD_STAGE_DIR)

docker_build:
	@echo "Building docker image"
	@docker build -t "$(APP_NAME):$(TAG)" .

docker_run:
	@echo "Starting up  docker container"
	@docker run -i -t --rm -p 5000:80 --env-file ./.env --name="$(APP_NAME)" "$(APP_NAME):$(TAG)"

acr_build_and_push:
	@az acr build --image "$(APP_NAME):$(TAG)" --registry $(ACR_REGISTRY) --file Dockerfile .

install_aks_cli:
	@az aks install-cli

aks_get_credentials:
	@az aks get-credentials --resource-group $(RESOURCE_GROUP) --name $(AKS_CLUSTER)

aks_get_nodes:
	@kubectl get nodes

run_backend:
	@docker-compose -f ./docker-compose/docker-compose.backend.yml up --force-recreate --build -d

unit_tests:
	@echo "Running unit tests..."
	@dotnet test ./test/UnitTest/UnitTest.csproj \
	/p:CollectCoverage=true \
	/p:CoverletOutputFormat=opencover \
	--no-restore

component_tests:
	@echo "Running component tests..."
	@dotnet test ./test/ComponentTest/ComponentTest.csproj \
	/p:CollectCoverage=true \
	/p:CoverletOutputFormat=opencover \
	--no-restore

integration_tests:
	@echo "Running integration tests..."
	@dotnet test ./test/UnitTest/UnitTest.csproj \
	/p:CollectCoverage=true \
	/p:CoverletOutputFormat=opencover \
	--no-restore

e2e:
	@echo "Running e2e tests..."
	@dotnet test ./test/EndToEndTests/EndToEndTests.csproj \
	/p:CollectCoverage=true \
	/p:CoverletOutputFormat=opencover \
	--no-restore	