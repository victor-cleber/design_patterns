=> Clone the project

```git clone https://github.com/victor-cleber/design_patterns.git```

OR

=> Create your own project

```mkdir projects```

```cd projects```

```dotnet new webapi -o Company.Fleet.API```

=> Add new projects

create a new library project inside the projects folder

```dotnet new classlib -o Company.Fleet.Infra```

```dotnet new classlib -o Company.Fleet.Domain```

add project reference

```dotnet add Company.Fleet.API/Company.Fleet.API.csproj reference Company.Fleet.Infra/Company.Fleet.Infra.csproj```

```dotnet add Company.Fleet.API/Company.Fleet.API.csproj reference Company.Fleet.Domain/Company.Fleet.Domain.csproj```

```dotnet build```

=> Configurating Swagger

```dotnet add package Swashbuckle.AspNetCore```

Add the following lines in Startup.cs

ConfigureServices method
``` 
//Register the Swagger generator
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Company.Fleet.API",
        Description="API - Fleet of vehicles",
        Version = "v1" 
    });
});
```

Configure method

```
//Enable middleware to serve generated Swagger as a Json Endpoint
app.UseSwagger();

//Enable middleware to serve swagger-ui specifying the Swagger JSON endpoint
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fleet API v1"));
```

=> Execute the command


```dotnet watch run```


=> Open the following address in your browser

- https://localhost:5001/swagger/v1/swagger.json

- https://localhost:5001/swagger/index.html




###Repository Pattern
The repository defines what methods are expected from any repository that derives from this interface.

This ease is because of the uncoupling of code between the domain and the data provider using a contract. The contract (interface) defines the necessary methods for the manipulation of the data. 

Another advantage of using the repository pattern is that it makes it easy to work with unit tests. For running unit tests, we can include a fake repository and perform the tests.