# Farmino

Farmino is small platform to contact farmers and clients for business purposes. Farmers after registration have access to create offers and manage them. Clients can browse offers by factors like city, price etc. Then clients can send reqests for orders they are intrested in and contact Farmer. Farmers can decide if they wil release order or not. Application alows to browse history of orders and change status appropriated to negotiated decision. To realease orders easier, application include map with optimal road to client.

# Used Packages/Libraries
### Frontend
* Axios
* Mapbox-vue
* Vue Router
* Vuex

### Backend
* Entity Framework Core
* Autofac
* xUnit (Unit testing)
* Moq (Unit testing)

### Important!: don't recomend to update any of libraries, current version of Sdk is .NET 6 and most of libraries won't be compatible with .NET Core 3.1

# External Services
* MapBox
* LocationIQ (service that returns longitude and latitude based by address)

# Requirements
* .NET Core 3.1
*  Vue CLI
*  MS SQL Server 2017
*  Node.js

# How to run Project
## 1. Install tools and prepare environment
* Install MS SQL Server and create server, 
* Install Visual Studio with .NET Core 3.1 SDK (it can be even runed via .Net cli but with VS is much easier)
* Install Node.js (LTS version would be best)
* Install Vue CLI via Node Package Manager:
```
#install vue cli globaly
npm install -g @vue/cli
```
## 2. Prepare Database
* Open Api project and change ConnectionString in appsettings.json
```
 "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER; User Id=YOUR_USER_ID; Password=YOUR_USER_PASSWORD; Database=FarminoDb"
  },
```
* Run prepared Database Migration using Package Manager Console (important: Default assembly to run migrations are Infrastructure. Before migration please select DefaultProject in PMC : Infrastructure):
```
#aplaying prepared migration
update-database
```

## 3. Run Application
* Open Backend project in VS using Kestrel : choose in running options selector Farmino.API or in Project directory use .NET CLI run command:
```
#at first build project
dotnet build

#then run
dotnet run
```
* Open frontend directory, you have to be on directory with same scope with: 
```
npm install
```
* Then in same directory run:
```
npm run serve
```
* Frontend is ready and is running under port 8080!
