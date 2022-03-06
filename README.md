# SEO_WebApi

SEO_WebApi provides apis to perform google search based on the provided input. It can also find the rank of a given url in the text result.
There are 2 Apis.
1. GetAllLinks- This accepts a string input and perform a google search based on it. It then returns all the links (top 100) from the result
2. GetURLRanks- This also accepts a string input to perform google search. In addition  it accepts a url. It then finds the url in the and return its rank in the search result.

Running the Project
1. Download the repo
2. Open SEO_WebApi solution in Visual Studio 2022
3. Right click solution and click on Restore Nuget Packages to insatll all dependencies
4. Set SEO_WebApi project as the starting project if it is not already set.
5. Run the SEO_WebApi project (F5)
6. Api should be running on localhost port 44318 by default (https://localhost:44318/swagger/index.html) and can receive incomming requests
7. WPF client App (https://github.com/VSwami01/SEO_WPFClient.git), PostMan, or swagger can be used for testing
