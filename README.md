# YFinder API Dotnet 2.0 Style!

**Summary**: Dotnet 2.0 version of the YFinder API for my Backend Capstone. This will be accessible to the YFinder Xamarin mobile app for interacting with the database's Users, Favorites, Ratings, Hotspots, Hosts, and Descriptors. It is one of three APIs that the YFinder mobile app will eventually implement. Check my github for the mobile app counterpart to this API, which will be developed the week of 9/18 and presented at Cohort 19's Demo Day on Friday 9/22 between 11-2:30pm. If you're reading this before then, consider yourself invited to come demo this API and the finished YFinder mobile app.

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
 - If you would like to interact with the database locally via the command line, run `npm install json`.
 - Visit http://www.stevebrownlee.com/beautiful-api-json-results-in-bash/ for useful functions to query on the command line.
 - `ngrok` is a wonderful tool to access this API deployed to the world wide web. It is the easiest way for the corresponding YFinder Xamarin app to access the API for development and demonstration. Visit https://ngrok.com/ to download and run.

## System configuration needed
 - Install your OS's version of Postman to interact with the API from a standalone application view.
 - Install your OS's version of DB Browser for SQLite from http://sqlitebrowser.org/

### Example Get Returns:

![Splashpage](https://raw.githubusercontent.com/mitchellblom/YFinderAPIdotnet2/master/Images/rating_get_ex.png)
![Splashpage](https://raw.githubusercontent.com/mitchellblom/YFinderAPIdotnet2/master/Images/user_get_ex.png)