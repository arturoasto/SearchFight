# SearchFight

Compare search engines result outputs with SearchFight.

Before starting the application you have to make sure you have the keys for 
the API's and place them in the AppConfig.json file.

The current implementation supports Google and Bing API, however you can add new
search engines just make sure you implement ICustomSearchEngine and you're done!

The application has unit tests so feel free to modify and refactor. Right now the current metrics are:

![image](https://user-images.githubusercontent.com/31879123/119278246-a1b99400-bbe9-11eb-8e60-35d023f1fd9f.png)

this application will recieve arguments in the console and return how many results
are per implemmented search engine, for example:

    C:\> searchfight.exe .net java

    .net: Google: 4450000000 MSN Search: 12354420
    java: Google: 966000000 MSN Search: 94381485

    Google winner: .net
    MSN Search winner: java
    Total winner: .net  
