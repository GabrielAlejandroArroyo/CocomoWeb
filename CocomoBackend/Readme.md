## Comandos Entity Framework

Crea archivo de migracion en carpeta de Migrations

dotnet ef migrations add InicialDb

## Hace la migracion en base a la carpeta Migrations

dotnet ef database update





## GRAFICO
```
CocomoBackend/
│
├── Controllers/
│ ├── CocomoStateController.cs
│ ├── EmployeeController.cs (ejemplo previo)
│
├── DTOs/
│ ├── CocomoStateDTOs.cs
│ ├── EmployeeDTOs.cs (ejemplo previo)
│
├── Models/
│ ├── CocomoState.cs
│ ├── Employee.cs (ejemplo previo)
│
├── Services/
│ ├── ICocomoStateService.cs
│ ├── CocomoStateService.cs
│ ├── IEmployeeService.cs (ejemplo previo)
│ ├── EmployeeService.cs (ejemplo previo)
│
├── Mappings/
│ ├── MappingProfile.cs
│
├── Data/
│ ├── ApplicationDbContext.cs
│
├── Startup.cs (para ASP.NET Core 5 y versiones anteriores)
│
├── Program.cs (para ASP.NET Core 6 y versiones posteriores)
│
├── appsettings.json
│
├── appsettings.Development.json
│
├── appsettings.Production.json
│
├── Prospection.Seed.csproj
│
└── ... otros archivos y carpetas necesarios





## Descripción de la Estructura Proyecto

### Controllers

Contiene los controladores de la API, que gestionan las solicitudes HTTP y devuelven las respuestas.
- `CocomoStateController.cs`: Controlador para gestionar los estados Cocomo.
- `EmployeeController.cs`: Controlador para gestionar los empleados (ejemplo previo).

### DTOs

Contiene los Data Transfer Objects (DTOs), que son objetos simples usados para transferir datos entre el cliente y el servidor.
- `CocomoStateDTOs.cs`: DTOs para el modelo `CocomoState`.
- `EmployeeDTOs.cs`: DTOs para el modelo `Employee` (ejemplo previo).

### Models

Contiene las clases de modelo que representan la estructura de los datos.
- `CocomoState.cs`: Modelo para `CocomoState`.
- `Employee.cs`: Modelo para `Employee` (ejemplo previo).

### Services

Contiene las interfaces y las implementaciones de los servicios, que encapsulan la lógica de negocio y las operaciones CRUD.
- `ICocomoStateService.cs`: Interfaz para el servicio `CocomoState`.
- `CocomoStateService.cs`: Implementación del servicio `CocomoState`.
- `IEmployeeService.cs`: Interfaz para el servicio `Employee` (ejemplo previo).
- `EmployeeService.cs`: Implementación del servicio `Employee` (ejemplo previo).

### Mappings

Contiene las configuraciones de AutoMapper.
- `MappingProfile.cs`: Configuración de AutoMapper para mapear entre los modelos y los DTOs.

### Data

Contiene la clase del contexto de la base de datos.
- `ApplicationDbContext.cs`: Contexto de Entity Framework Core que maneja la conexión a la base de datos y las entidades.

### Startup.cs

Archivo de configuración para ASP.NET Core 5 y versiones anteriores, donde se registran los servicios y se configuran los middleware.

### Program.cs

Archivo de configuración para ASP.NET Core 6 y versiones posteriores, donde se configuran los servicios y se define la tubería de solicitud.

### appsettings.json

Archivo de configuración para las opciones de la aplicación.

### appsettings.Development.json

Archivo de configuración específico para el entorno de desarrollo.

### appsettings.Production.json

Archivo de configuración específico para el entorno de producción.

### Prospection.Seed.csproj

Archivo de proyecto de .NET que define las dependencias y configuraciones del proyecto.

Esta estructura sigue las prácticas recomendadas para la organización de un proyecto ASP.NET Core, facilitando la separación de preocupaciones y el mantenimiento del código.



## Hacer imagen de Backend Docker

Ir al directorio  C:\sources\Cocomo\COCOMO_WEB_BACK\CocomoBackend


docker build -t cocomobackend .


docker run -d -p 8080:80 --name cocomobackend cocomobackend


docker run -d --name cocomobackend cocomobackend






docker run -dt -v "C:\Users\gabriel.arroyo\vsdbg\vs2017u5:/remote_debugger:rw" -v "C:\Users\gabriel.arroyo\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro" -v "C:\Users\gabriel.arroyo\AppData\Roaming\Microsoft\UserSecrets:/home/app/.microsoft/usersecrets:ro" -v "C:\Users\gabriel.arroyo\AppData\Roaming\ASP.NET\Https:/root/.aspnet/https:ro" -v "C:\Users\gabriel.arroyo\AppData\Roaming\ASP.NET\Https:/home/app/.aspnet/https:ro" -v "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Sdks\Microsoft.Docker.Sdk\tools\linux-x64\net8.0:/VSTools:ro" -v "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\HotReload:/HotReloadAgent:ro" -v "C:\sources\Cocomo\COCOMO_WEB_BACK\CocomoBackend:/app:rw" -v "C:\sources\Cocomo\COCOMO_WEB_BACK:/src/:rw" -v "C:\Users\gabriel.arroyo\.nuget\packages:/.nuget/fallbackpackages:rw" -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true" -e "ASPNETCORE_ENVIRONMENT=Development" -e "DOTNET_USE_POLLING_FILE_WATCHER=1" -e "NUGET_PACKAGES=/.nuget/fallbackpackages" -e "NUGET_FALLBACK_PACKAGES=/.nuget/fallbackpackages" -P --name CocomoBackend --entrypoint dotnet cocomobackend:dev --roll-forward Major /VSTools/DistrolessHelper/DistrolessHelper.dll --wait 
89cc8fd98cc2ff40df8fd100ce30ef343c5ff9cb987f38fc18684f483d7873ee







url docker https://localhost:32769/index.html


docker run -d -p 8080:80 --name CocomoBackend cocomobackend:dev

docker run -d -p 8080:80 --name CocomoBackend cocomobackend:dev




docker run -d -p 9080:8080 -p 9081:8081 --name CocomoBackend cocomobackend:dev

docker run -d -p 32772:8080 -p 32773:8081 --name CocomoBackend cocomobackend:dev



## Como hacer relaciones en Entity Framework

ejemplo:

me ubico en la clase de la tabla que va a tener mis foreign keys

CocomoHead.cs

cuando quiera generar una foreign key de un id : 

public int IdTypeRequirement { get; set; }

debo declarar lo siguiente:

public TypeRequirement TypeRequirement { get; set; }

finalmente en la clase TypeRequirement.cs debo crear la relacion con la tabla :

public ICollection<CocomoHead> CocomoHeads { get; set; }

solo quedaria modificar el appDbContext:

modelBuilder.Entity<CocomoHead>()
                .HasOne(tr => tr.TypeRequirement)  // CocomoHead tiene un TypeRequirement
                .WithMany(tr => tr.CocomoHeads)  // TypeRequirement tiene muchas CocomoHeads
                .HasForeignKey(tr => tr.IdTypeRequirement)  // La clave foránea es IdTypeRequirement
                .OnDelete(DeleteBehavior.Restrict);  // Configura el comportamiento en cascada (opcional)


