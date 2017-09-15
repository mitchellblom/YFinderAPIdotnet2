# YFinder API Dotnet 2.0 Style!

**Summary**: Dotnet 2.0 version of the YFinder API for my Backend Capstone. This will be accessible to the YFinder Xamarin mobile app for interacting with the database's Users, Ratings, Hotspots, Hosts, and Descriptors. It is one of three APIs that the YFinder mobile app will eventually implement. Check my github for the mobile app counterpart to this API, which will be developed the week of 9/18.

<hr>

## Steps to install the code
 - Create environment variable in your .zschrc or .bashrc file. EXAMPLE: `export YFINDER_DB="/Users/loaner1/Projects/YFinderAPI/YfinderAPIdotnet2/YFinder2.db"`
 - Clone from github using `git clone https://github.com/mitchellblom/YFinderAPIdotnet2.git`
 - cd into the created directory
 - In terminal execute `dotnet ef migrations add Initial`
 - Execute `dotnet ef database update`
 - Execute `dotnet run`
 - Calls can now be made on `localhost:5000` unless your default host settings have been edited.

## How to install any dependencies
 - If you would like to interact with the database via the command line, run `npm install json`.
 - Visit http://www.stevebrownlee.com/beautiful-api-json-results-in-bash/ for useful functions to query on the command line.

## System configuration needed
 - Install your OS's version of Postman to interact with the API from a standalone application view.
 - Install your OS's version of DB Browser for SQLite from http://sqlitebrowser.org/

### Example Get Return

![Splashpage](https://raw.githubusercontent.com/mitchellblom/TripEZ/readme/images/screenshots/landing.png)