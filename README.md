# blazor-in-action
Playground for working through the Blazor In Action exercises
## Setting up the Database
Since the Entity Framework Core command line tools are project specific, we need to `cd` into the project folder:
```shell
cd BlazingTrails.Api
```
Check to see if you have the Entity Framework Core command line tools to set up the database by running:
```shell
dotnet ef
```
If you see an Entity Framework unicorn in ASCII art then you are good to go, however if you see an error then you may have to run:
```shell
dotnet restore
```
or explicitly run:
```shell
dotnet tool install --global dotnet-ef
```
to install the command line tools.  Then run the following command to set up the initial database:
```shell
dotnet ef database update InitialEntities
```
