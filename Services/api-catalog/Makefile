BASE_DIR := ./
APP_NAME := catalog-api
TAG := latest


add-migration:
	@dotnet ef migrations add $(name) --project ./src/Infrastructure/ --startup-project ./src/WebApi/

update-db:
	@dotnet ef database update --project ./src/Infrastructure/ --startup-project ./src/WebApi/

rm-migration:
	@dotnet ef migrations remove --project ./src/Infrastructure/ --startup-project ./src/WebApi/