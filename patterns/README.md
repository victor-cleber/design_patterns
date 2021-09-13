###SINGLETON

![Singleton UML diagram](https://github.com/victor-cleber/design_patterns/blob/main/patterns/assets/singleton_uml.png)


GET
​/api​/v1​/Singleton​/GetWithoutSingleton

OR 


GET
​/api​/v1​/Singleton​/GetWithSingleton


Also, we can use the framework to manage our singleton classes:

create a class SingletonContainer in Company.Fleet.Infra.Singleton
and use the AddSingleton injection in Startup.cs

ConfigureServices

services.AddSingleton<SingletonContainer>();

and inject in the SingletonController's constructor the reference for singletonContainer

![Singleton Methods](https://github.com/victor-cleber/design_patterns/blob/main/patterns/assets/singleton.png)

###REPOSITORY - IN MEMORY
![Repository UML diagram](https://github.com/victor-cleber/design_patterns/blob/main/patterns/assets/repository_uml.png)


![Repository Methods](https://github.com/victor-cleber/design_patterns/blob/main/patterns/assets/repository.png)


###REPOSITORY - EF IN MEMORY


Add the Entity Framwork In Memory package to the Infra project:

```dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 5.0.9```

Create two classes: Infra/EF/FleetRepository and Infra/EF/FleetContext to be used with Entity Framework.

Update the Dependency Injection in Startup/ConfigureServices to use the context in memory:

```services.AddDbContext<FleetContext>(opt => opt.UseInMemoryDatabase("Fleet"));```

Update the repositoryImplementation from

```services.AddSingleton<IVehicleRepository, InMemoryRepository>();```

to 

```services.AddTransient<IVehicleRepository, FleetRepository>();```

![Repository EF Methods](https://github.com/victor-cleber/design_patterns/blob/main/patterns/assets/repository_ef.png)


###FACADE

Insert a contract in Domain project:
-> IVehicleDetran

Create a folder Facade inside Infra Project

-> DetranOptions and VehicleDetranFacade

add configurations in AppSettings:

```
"DetranOptions":{
    "BaseUrl": "https://xpto12345678.mockapi.io/",
    "ScheduleUrl": "api/v1/detran/schedule",
    "NumberOfDaysForScheduling": 1    
 ```

 Add DetranOptions in Startup.cs
```
    services.Configure<DetranOptions>(configurations.GetSection("DetranOptions"));
```

Add reference in Infra

```
dotnet add package Microsoft.Extensions.Http
```

Add httpClient at Startup

```services.AddHttpclient();```

Add a package

```dotnet add package Microsoft.Extensions.Http```

Add a model class to represents the data from api


Add a package in Company.Fleet.Domain

```dotnet add package Microsoft.AspNet.WebApi.Client --version 5.2.7```

Inject de dependencies in Startup.cs

```services.AddTransient<IVehicleDetran, VehicleDetranFacade>();```