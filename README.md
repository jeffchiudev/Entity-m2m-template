<div align="center">

# TODO PRoject Title

</div>

<div align="center">
<img src="https://github.com/jeffchiudev.png" width="200px" height="auto" style="border-radius: 15px 50px;">

</div>
<h3 align="center">Many-to-many relationship database, 08.Jan.2020</h3>
<h4 align="center"> By Jeff Chiu</h4>


## Description: 

## Preview:

#### User Stories:
| ID | User Story | Accepted |
| :-------- | :------ | :------- |
||||
||||

##### Software Requirements

1. Internet browser of choice, [Chrome](https://www.google.com/chrome/?brand=CHBD&brand=FHFK&gclid=CjwKCAiA_9r_BRBZEiwAHZ_v19Z0_XYzZ8NiG2AyZJ9A8ZVQjOBCYIuyRcS3Muc41TZCA_PL0n3s6hoCiaEQAvD_BwE&gclsrc=aw.ds) recommended.
2. A code editor such as [VSCode](https://code.visualstudio.com/) or [Atom](https://atom.io/).
3. Install .NET core: [MacOS](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) & [PC](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer).
4. Install MySQL: [MacOS](https://dev.mysql.com/downloads/file/?id=484914) & [PC](https://dev.mysql.com/downloads/file/?id=484919).
5. Install MySQL Workbench: Find appropriate version [here](https://dev.mysql.com/downloads/workbench/).

##### Open Locally

1. Click on the link to my repository on github [here](https://github.com/jeffchiudev/PROJECTNAME). 
2. Click on the green "Code" link near the top and above the README.md.
3. Alternatively open your terminal and use the command `git clone https://github.com/jeffchiudev/PROJECTNAME` into the directory you would like to clone the repository.
4. Open in text editor to view code.

##### Installing .NET

1. Download [.NET Core SDK (Software Development Kit)](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer). Clicking this link will prompt a file download for your particular OS from Microsoft.
2. Open the file. Follow the installation steps.
3. Confirm the installation is successful by opening your terminal and running the command `dotnet --version`. The response should be something similar to this:`2.2.105`. This means it was successfully installed.

#### Import Database & Entity Framework Core
1. Navigate to the PROJECTNAME.Solution/PROJECTNAME directory in terminal.
2. Run command `dotnet ef database update` to generate database.
3. Run command `dotnet ef migrations add [MIGRATIONNAME]` and `dotnet ef database update` if you're making changes to the database. 
4. To access your database that you've set up in MySQL workbench add the following code into a `appsettings.json` file in the `PROJECTNAME.Solutions/PROJECTDIRECTORY`:

```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=Jeff_Chiu_PROJECTNAME;uid=root;pwd=YourPassword;"
    }
}
```
5. Change server, port and UID as necessary.  

#### Import Database with MySQL Workbench
1. Open MySQL and enter password.
2. Go to nav bar and click on `Server` and then `Data Import`.
3. Use the option `Import from Self-Contained File`.
4. Set `Default Target Schema` or create a new.
5. Select all schema objects you wnat to import and the option `Dump Structure and Data` is selected.
6. Click `Start Import`.
7. Optionally, using your SQL management program, paste the following schema statement to reproduce the database:
```
INSERT DATABASE SCHEMA HERE
```

##### View In Browser

1. To view in browser, navigate to `PROJECTNAME.Solutions/PROJECTNAME` in the command line.
2. Use command `dotnet build` and `dotnet run` to start a local version of the page. 
3. Navigate to http://localhost:5000

## Known Bugs

## Support and Contact Details

If any errors or bugs occur please email me [here](jeffchiudev@gmail.com).

## Technologies Used

- .NET Core 2.2
- ASP.NET Core MVC
- Bootstrap
- C# 7.3
- CSS
- Entity
- Razor
- REPL
- VS Code

### License

This software is licensed under the [MIT License](https://choosealicense.com/licenses/mit/).

<img src="https://apprecs.org/gp/images/app-icons/300/7c/air.capoo.jpg" width="1%" height="auto" style="border-radius: 50%"> Copyright (c) 2020 Jeff Chiu 