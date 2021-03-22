# Dr. Sillystringz's Factory

#### MVC Web App to track a Factory's engineer(s) and machine(s) with there being a many to many relationship.

#### By Tien Nguyen

## Technologies Used

* _C# 9.0_
* _.NET 5.0_
* _MSTEST_
* _MySQL 8_
* _MySQL Workbench 8_
* _Razor_
* _Entity Framework_
* _Bootstrap 4.5.2_
* _HTML 5_
* _CSS 3_

## Description
_A MVC web application for "Dr. Sillystringz's Factory" is used as an operations tracking platform. The platform stores both Engineers and Machines. It works as a Many-To-Many relationship in order to have multiple Engineers being able to work on the same Machine and other machines as well. With the utilization of the Entity Framework and MySQL, the app cna store the create the database and tables via the Models and store them collectively._

## Setup / Installation Requirements

<details>
<summary> Install C# and .NET </summary>

1. _WINDOWS: Download the [64-bit .NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer). Clicking these links will prompt a **.exe** file download from Microsoft._
2. _MAC: Download this [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.100-macos-x64-installer). Clicking this link will prompt a **.pkg** file download from Microsoft._
3. _Open the file and follow the steps provided by the installer for your OS._
4. _Confirm the installation is successful by opening a new Windows PowerShell OR Max Terminal window and running the command dotnet --version._

</details>

<details>
<summary>  MySQL Installation </summary>

#### Windows Install ####
1. _WINDOWS: Download the [MySQL](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi). Use the **No thanks**, just start my download link._
2. _Click **"Yes"** if prompted to update and accept license terms._
3. _Choose Custom setup type._
4. _When prompted to Select Products and Features, choose the following:_
- _Check the box that says **"Enable the Select Features page to customize product features"**._
- _MySQL Server 8.0.19 (This will be under "MySQL Servers > MySQL Server > MySQL Server 8.0")._
- _MySQL Workbench 8.0.19 (This will be under "Applications > MySQL Workbench > MySQL Workbench 8.0")_

5. _Select **"Next"**, then **"Execute"**. Wait for download and installation. (This can take a few minutes.)_
6. _Advance through Configuration as follows:_
- _High Availability set to **"Standalone"**._
- _The **"Defaults are OK"** under Type and Networking._
- _Authentication Method set to **Use Legacy Authentication** Method._
- _Set password **AND REMEMBER IT**._
- _Defaults are OK under Windows Service. Make sure that checkboxes are checked for the options **"Configure MySQL Server as a Windows Service"** and **"Start the MySQL Server at System Startup"**._
- _Under Run Windows Service as..., the **"Standard System Account"** should be selected._

7. _Complete Installation Process._
8. _Open the Control Panel and visit System and **"Security > System"**._
9. _Select **"Change Settings"** and a pop-up window will display._ 
10. _Select the tab **"Advanced"** and select the **"Environment Variables"** button._
11. _Within the System Variables navigator window, select PATH..., click Edit..., and then New._
12. _Add the exact location of your MySQL installation, and click OK. (For Example, C:\Program Files\MySQL\MySQL Server 8.0\bin)._
13. _verify installation by opening Windows PowerShell and entering the command mysql -uroot **-p[PASSWORD]**_

#### MacOS Install ####
1. _MAC: Download the [MySQL](https://dev.mysql.com/downloads/file/?id=484914). Clicking this link will prompt a **.dmg** file download from Microsoft._
2. _Follow along with the **Installer** until you reach the **Configuration** page._
3. _In the Configuation page, first **Use Legacy Password Encryption**._
4. _Set password to what you desire - **NOTE: Please remember your password**!_
5. _Click Finish._
6. _Open your terminal and enter the follow command: **echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile**_
7. _Type **source ~/.bash_profile** (or restart the terminal) in order to actually verify that MySQL was installed._
8. _Verify MySQL is installed by opening the terminal and enter in the command, replacing the placeholder with your password: **mysql -uroot -p[PASSWORD]**_
9. _Download and Install [MySQL WorkBench](https://dev.mysql.com/downloads/file/?id=484391) to Applications folder._

</details>

<details>
<summary> Local Environment Setup </summary>

1. _Clone the repo or download the ZIP file of the repo._
2. _Create a new file in the **/HairSalon** directory and named **appsettings.json**_
3. _Copy and paste the follow but **ENTER YOUR OWN PASSWORD**:_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=[PORT OF SERVER];database=tien_nguyen;uid=root;pwd=[PASSWORD OF SERVER];"
  }
}
```
4. _Navigate to the main directory of the repo._
5. _Open the repo's main directory in the Code Editor of your choice._
6. _Run the **FIRST** command in your terminal within the repo's main directory (Example: /VendorOrderTracker/): __"dotnet restore"__._
7. _Run the **SECOND** command in your terminal within the repo's main directory (Example: /VendorOrderTracker/): __"dotnet build"__._
8. _Run the **THIRD** command in your terminal within the repo's main directory (Example: /VendorOrderTracker/): __"dotnet ef database update"__._
9. _Run the **FOURTH** command in your terminal within the same main directory (Example: /VendorOrderTracker/): __"dotnet run"__._
10. _The App should now be running Localhost:5000._
11. _Open any web browser app and go to **http://localhost:5000/** to open your app._
12. _To stop the app during any moment, press the following combination of keys in your terminal: _**CTRL**_ + _**C**_._

</details>

## Known Bugs

* _None at the moment (3/19/2021)_

## Project Goals / Further Exploration
- Add properties to specify if a machine is operational, malfunctioning, or in the process of being repaired.
- Add properties to specify if an engineer is idle, or actively working on repairs.
- Add inspection dates to the machines, or dates of license renewal to the engineers.
- Add a table for incidents, showing which engineer repaired which machine.
- Add a table for locations, and specify which engineers or machines are located at which factory.
- Add styling to give life to the project.

## License
_This software is licensed under the MIT license_\
Copyright (c) 2021 __Tien Nguyen__

## Contact Information
_<Tien96ng@gmail.com>_