# eCommerce

## This solution has not been completed, and not to the standard at which I had hoped.

My idea was to add a generic product bundles specials calculator that would use a rule defined in the database to determine how to calculate 
specials for products.

However I underestimated how much I had to recap in C# and ended up wasting so much time with the repos and EF Core and did not implement
a solution that I am proud of.

## Running Migrations
I have added a bunch of migrations for the database, which should be automatically run on Startup for testing purposes.
I also added a simple DB initializer class that will add some mock data on Startup for testing. 

I did discover this cool way of manually adding migrations without having to set the connection string for testing in the ECommerce Context.
This command forces the migrations tool to retrieve the connection string from the config file instead:

`dotnet ef migrations add NameOfMigration --startup-project .\eCommerceApi\ --project .\eCommerceDatabase\`

## Running the App
I unfortunately did not get time to setup a proper Docker compose project, hence please follow the following steps:
1. Set the eCommerce.AppHost as the Startup project before running.
2. Set a connection string for a database in the ./eCommerceApi/secrets.json file with the keys as follows:
```json
{
  "ECommerce": {
    "ConnectionString": "SERVER=localhost\\;DATABASE=ECommerce;UID=user;PWD=pwd;TrustServerCertificate=True"
  }
}
```

## Room for improvement all over
As I mentioned earlier, I really did not do a good job with creating much in the solution. The best part of the WebApi solution is the use of the Repository patter to allow for easily maintaing the application at the repository layer, without having to make much changes at the Service and Controller levels once the initial structure has been set. The calculator class was another good idea that was poorly implemented. I overthinked too much with the calculator and also ended up spending too much time trying thrashing about the solution instead of planning it out as I normally would.

Please have a look at some of my other repos for a better representation of some of my other designs:
https://github.com/prajeshJugga/PhonebookApp/tree/master/PhoneBook-Web-API
https://github.com/prajeshJugga/LeagueResultsProcessor
https://github.com/prajeshJugga/MatchResultsProcessor