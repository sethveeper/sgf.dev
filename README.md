# sgf.dev
Backend and CMS for the sgf.dev website

This project is built using [Abp](https://abp.io/). To learn more about how an Abp application is structured check out the [Abp Docs](https://docs.abp.io/)

Note; this project is specifically using [Abp Commercial](https://commercial.abp.io/) which has [additional documentation](https://docs.abp.io/en/commercial)

## Required tools

- [.NET Core 3.1](https://dotnet.microsoft.com/download) 
- [postgres 12 or 13](https://www.postgresql.org/) 
- [node.js 12](https://nodejs.org/en/)
- npm 6 


## Setup

- Copy `src/SgfDevs.DbMigrator/appsettings.json.example` to `src/SgfDevs.DbMigrator/appsettings.Development.example`.
- Copy `src/SgfDevs.Web/appsettings.json.example` to `src/SgfDevs.Web/appsettings.Development.example`.
- Copy `test/SgfDevs.HttpAp.Client.ConsoleTestApp/appsettings.json.example` to `test/SgfDevs.HttpAp.Client.ConsoleTestApp/appsettings.Development.example`.
- Copy `test/SgfDevs.TestBase/appsettings.json.example` to `test/SgfDevs.TestBase/appsettings.Development.example` .
- Add the abp license code to each `apssetings.Development.json` file you created in the `AbpLicenseCode` property.
    - If you don't have this code reach out the one of the project maintainers.
- In `src/SgfDevs.Web/appsettings.Development.json` and `src/SgfDevs.DbMigrator/appsettings.Development.json` fill out your database details in the default connection string.
    - Make sure to create a database if you haven't already.
    - If your local database doesn't have a password, leave the password as blank and remove the `;` after the `=`.
- Set the `ASPNETCORE_ENVIRONMENT` environment variable to `Development`.
    - If you're using Visual Studio right click on the project to add the variable to (`SgfDevs.Web` and `SgfDevs.DbMigrator`), click Properties, navigate to Debug, and add the variable in the Environment Variables section 
    - If you're using Rider you can edit each project configuration add add the environment variable there.
    - If you're using the dotnet cli on Windows run `set ASPNETCORE_ENVIRONMENT=Development`
        - Note; if you ever close or reset you're terminal you'll have to set the environment variable again.
    - If you're using the dotnet cli on Mac OS/Linux `export ASPNETCORE_ENVIRONMENT=Development`
        - Note; if you ever close or reset you're terminal you'll have to set the environment variable again.
- Set the `ASPNETCORE_URLS` environment variable to `https://localhost:44359`
    - If you're using the Visual Studio or Rider this only needs set for the `SgfDevs.Web` project.
- Run migrations (see Running Migration section for instructions).
- Run `npm i` in `src/SgfDevs.Web/Admin`.


## Running

- Run `npm start` in `src/SgfDevs.Web/Admin`.
- Run the `SgfDevs.Web` project.
    - If you're using Visual Studio or Rider you should automatically have an option to run this project.
    - If you're using the dotnet cli run `dotnet run` or `dotnet watch` in the `src/SgfDevs.Web` folder.


### Creating Migrations

- In the `src/SgfDevs,Web` folder run `dotnet ef migrations add MigrationName --project ../SgfDevs.EntityFrameworkCore.DbMigrations/SgfDevs.EntityFrameworkCore.DbMigrations.csproj`.

### Running Migrations
- To run the database migrations by run the `SgfDevs.DbMigrator` project. 
    - If you're using Visual Studio or Rider you should automatically have an option to run this project
    - If you're using the dotnet cli run `dotnet run` in the `src/SgfDevs.DbMigrator` folder.
