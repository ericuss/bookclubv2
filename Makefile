
run: #make run
	@echo "$(CYAN_COLOR)==> Run ...$(NO_COLOR)"
	@docker-compose up --build

add-migration-to-library: #make add-migration-to-library name=Initial
	@echo "$(CYAN_COLOR)==> Adding migration to library...$(NO_COLOR)"
	@dotnet ef migrations add  $(name) -c "Lanre.Module.Library.Infrastructure.Database.LibraryContext" -o "Infrastructure/Database/Migrations" -p "./src/Lanre.Module.Library" -s "./src/Lanre.Web"

add-migration-to-poll: #make add-migration-to-poll name=Initial
	@echo "$(CYAN_COLOR)==> Adding migration to poll...$(NO_COLOR)"
	@dotnet ef migrations add  $(name) -c "Lanre.Module.Poll.Infrastructure.Database.PollContext" -o "Infrastructure/Database/Migrations" -p "./src/Lanre.Module.Poll" -s "./src/Lanre.Web"

unit-tests-library: #make unit-tests-library
	@echo "$(CYAN_COLOR)==> Testing unit tests of library...$(NO_COLOR)"
	@docker-compose -f docker-compose.unit-tests.yml build library.unittests && docker-compose -f docker-compose.unit-tests.yml run library.unittests
	
unit-tests-poll: #make unit-tests-poll
	@echo "$(CYAN_COLOR)==> Testing unit tests of poll...$(NO_COLOR)"
	@docker-compose -f docker-compose.unit-tests.yml build poll.unittests && docker-compose -f docker-compose.unit-tests.yml run poll.unittests