
=> Singleton



![Singleton UML diagram](assets/image.png)


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