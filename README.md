
# Who Wants To Be a Millionaire API

The purpose of this project was to replace the dependency on the OpenTDB REST API and instead use this API solution. Please follow the steps below to setup the project.

## Assumptions
The user has a Windows machine with SQL Server and Visual Studio installed.

## Installation

Using whatever UI you're using to view and manage your database, SQL Server Management Studio for example, please open the ```Setup/CreateSchema.sql``` script and run it to create the database and tables.

Open Visual Studio and the open the .NET project (```who-wants-to-be-a-millionaire-api.csproj```), then start the solution without using debugging mode. Alternatively, the user can use the command prompt to access the .NET project directory and then run the command ```dotnet run```.

While the .NET solution is running, run the ```Setup/BatchDataImport.bat``` script which will download all the raw files from ```https://github.com/uberspot/OpenTriviaQA/tree/master/categories``` and then load the data into the database.

That should be it, open the ```home.html``` file from the ```https://github.com/kaneran/who-wants-to-be-a-millionaire-game``` project and you should be able to play the game.
    
