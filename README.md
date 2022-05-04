# whatscookin

# Dependencies

1. Powershell-core
2. Dotnet Core v 6
3. MongoDb and Mongo Compass
4. Nodejs(lts) and Yarn

# Build Instructions
   
   1. Open MongoCompass and connect using the connect string in dir => 
        RealMongoRecipeStore/RealMongoRecipeStore/RealMongoRecipeStore/appsettings.json
   2. At the root run `pwsh Import-CollectionToMongo.ps1`
   3. Navigate to  => RealMongoRecipeStore/RealMongoRecipeStore/RealMongoRecipeStore and run `dotnet run` 
   4. Open another terminal and navigate to => whatscookin/whatscookin
   5. Here run `npm install` or `yarn install`
   6. Now run `yarn start`
