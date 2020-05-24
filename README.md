# SearchFight

Making use of the KISS and DRY principles, and following SOLID principles
this application can scale and support multiple search engines.

Also following the KISS principle we make sure that we are not to create accidental
complexity at the time of implementation
this application will recieve arguments in the console and return how many results
are per implemmented search engine, for example:


    C:\> searchfight.exe .net java

    .net: Google: 4450000000 MSN Search: 12354420
    java: Google: 966000000 MSN Search: 94381485

    Google winner: .net
    MSN Search winner: java
    Total winner: .net  

Before starting the application you have to make sure you have the needed keys for 
the API's and place them in the App.config file.
