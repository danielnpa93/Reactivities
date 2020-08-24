# Reactivities-Server

Example of a trivial ASP.NET Web API using both Repository Pattern and MediaR for controllers. Contains some good pratices of Domain, Persintence, Application and API layers.
This project feeds Reactivities-Client project.

Use for my consulting. Still WIP.

For replicate the sqlite repository use the commands: dotnet-ef migrations add --migrationName--, dotnet-ef database update, add configure the connectionStrings
("ConnectionStrings": {
"LiteServer": "Data Source=reactivities.db"
}) and use the sqlite extension to see the local.db file.
