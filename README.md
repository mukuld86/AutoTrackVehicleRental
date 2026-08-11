# AutoTrack Vehicle Rental Service

A web-based ASP.NET Core MVC application for managing the vehicle fleet of AutoTrack Vehicle Rental Service.

The application replaces a spreadsheet-based vehicle management process with a structured system that allows staff to view, add, update, delete, and search vehicle records.

## 🚀 Features

- View all vehicles
- Add new vehicles
- Update vehicle details
- Delete retired or damaged vehicles
- Search vehicles by type
- Track vehicle availability
- Track vehicle registration date
- Server-side model validation using Data Annotations
- Structured exception handling
- Entity Framework Core database operations
- SQL Server database
- Repository Pattern
- Multi-layer architecture

## 🛠️ Technologies Used

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- LINQ
- Data Annotations
- Repository Pattern
- Dependency Injection
- Razor Views
- Bootstrap

## 🏗️ Architecture

The application follows a three-layer architecture:

```text
┌─────────────────────────────────────┐
│        Presentation Layer           │
│                                     │
│ ASP.NET Core MVC                    │
│ Controllers                         │
│ Views                               │
│ VehicleViewModel                    │
└──────────────────┬──────────────────┘
                   │
                   ▼
┌─────────────────────────────────────┐
│           Service Layer             │
│                                     │
│ IVehicleService                     │
│ VehicleService                      │
└──────────────────┬──────────────────┘
                   │
                   ▼
┌─────────────────────────────────────┐
│        Data Access Layer            │
│                                     │
│ Vehicle                             │
│ VehicleDbContext                    │
│ IRepository                         │
│ Repository                          │
└──────────────────┬──────────────────┘
                   │
                   ▼
              SQL Server
```

### Request Flow

```text
Browser
   ↓
VehicleController
   ↓
VehicleService
   ↓
Repository
   ↓
VehicleDbContext
   ↓
Entity Framework Core
   ↓
SQL Server
```

## 📁 Project Structure

```text
AutoTrackVehicleRental
│
├── AutoTrackVehicleRental.Web
│   │
│   ├── Controllers
│   │   └── VehicleController.cs
│   │
│   ├── Models
│   │   └── VehicleViewModel.cs
│   │
│   ├── Views
│   │   ├── Shared
│   │   │   └── _Layout.cshtml
│   │   │
│   │   └── Vehicle
│   │       ├── ViewAllVehicles.cshtml
│   │       ├── AddVehicle.cshtml
│   │       ├── UpdateVehicle.cshtml
│   │       └── RemoveVehicle.cshtml
│   │
│   └── Program.cs
│
├── AutoTrackVehicleRental.Services
│   │
│   ├── Interfaces
│   │   └── IVehicleService.cs
│   │
│   └── Services
│       └── VehicleService.cs
│
└── AutoTrackVehicleRental.DataAccess
    │
    ├── Models
    │   └── Vehicle.cs
    │
    ├── Interfaces
    │   └── IRepository.cs
    │
    ├── Repositories
    │   └── Repository.cs
    │
    ├── Migrations
    │   └── InitialCreate
    │
    └── VehicleDbContext.cs
```

## 🗄️ Database

The application uses SQL Server with Entity Framework Core.

Database:

```text
AutoTrackVehicleRentalDb
```

### Vehicles Table

| Column | Type | Description |
|---|---|---|
| VehicleId | int | Primary key and Identity column |
| VehicleName | string | Vehicle name/model |
| Type | string | Vehicle type such as SUV, Sedan, or Truck |
| AvailabilityStatus | bool | Indicates whether the vehicle is available |
| DateOfRegistration | DateTime | Vehicle registration date |

`VehicleId` is generated automatically by SQL Server.

## 📋 Vehicle Model

The Data Access entity contains:

```csharp
public class Vehicle
{
    public int VehicleId { get; set; }

    public string VehicleName { get; set; }

    public string Type { get; set; }

    public bool AvailabilityStatus { get; set; }

    public DateTime DateOfRegistration { get; set; }
}
```

The MVC application uses a separate `VehicleViewModel` for presentation-layer validation.

## ✅ Validation

Data Annotations are used on the MVC model.

Validation includes:

- Vehicle name is required
- Vehicle type is required
- Date of registration is required
- Vehicle name must be less than 50 characters
- Vehicle type must be less than 30 characters
- Date of registration uses a valid date input

Example:

```csharp
[Required]
[StringLength(49)]
public string VehicleName { get; set; }

[Required]
[StringLength(29)]
public string Type { get; set; }

[Required]
[DataType(DataType.Date)]
public DateTime DateOfRegistration { get; set; }
```

## 📡 Application Operations

### View All Vehicles

The home page displays all vehicles in the fleet.

Displayed information includes:

- Vehicle ID
- Vehicle Name
- Type
- Availability Status
- Date of Registration
- Actions

### Add Vehicle

The Add Vehicle page allows staff to enter:

```text
Vehicle Name
Type
Availability Status
Date of Registration
```

The Vehicle ID is generated automatically by SQL Server.

### Update Vehicle

Existing vehicle details can be modified.

The following fields can be updated:

- Vehicle Name
- Type
- Availability Status
- Date of Registration

### Delete Vehicle

Vehicles that are retired or damaged can be removed from the fleet.

A confirmation page is displayed before the deletion is performed.

### Search Vehicle

Vehicles can be searched by type.

Example:

```text
SUV
```

The application displays only vehicles matching the specified type.

The search results are displayed on the same vehicle listing page.

## 🔎 LINQ Search

The repository uses LINQ to search vehicles by type:

```csharp
public List<Vehicle> SearchVehicleByType(string type)
{
    return _context.Vehicles
        .Where(v => v.Type == type)
        .ToList();
}
```

## 🧩 Repository Pattern

The application uses an `IRepository` interface to define database operations:

```csharp
public interface IRepository
{
    void AddVehicle(Vehicle vehicle);

    List<Vehicle> ViewAllVehicles();

    Vehicle GetVehicle(int vehicleId);

    void UpdateVehicle(Vehicle vehicle);

    void RemoveVehicle(int vehicleId);

    List<Vehicle> SearchVehicleByType(string type);
}
```

The `Repository` class implements these operations using Entity Framework Core.

This keeps database-related code separate from the service and presentation layers.

## 🔄 CRUD Operations

```text
Create
  ↓
Add Vehicle

Read
  ↓
View All Vehicles
Get Vehicle
Search Vehicle

Update
  ↓
Update Vehicle

Delete
  ↓
Remove Vehicle
```

## ⚙️ Entity Framework Core

Entity Framework Core is used as the ORM for database operations.

The application uses:

- `DbContext`
- `DbSet<Vehicle>`
- EF Core migrations
- SQL Server provider
- LINQ queries

The database was created using an EF Core migration:

```powershell
Add-Migration InitialCreate
Update-Database
```

## 🔌 Dependency Injection

The application uses ASP.NET Core Dependency Injection to connect the layers.

```text
IVehicleService
      ↓
VehicleService

IRepository
      ↓
Repository

VehicleDbContext
      ↓
SQL Server
```

Services are registered in `Program.cs`:

```csharp
builder.Services.AddDbContext<VehicleDbContext>();

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddScoped<IVehicleService, VehicleService>();
```

## 🛡️ Exception Handling

Controller operations use structured exception handling with `try-catch` blocks.

Example:

```csharp
try
{
    var vehicles = _vehicleService.ViewAllVehicles();

    // Process vehicles
}
catch (Exception)
{
    return View("Error");
}
```

This prevents unhandled application exceptions from directly reaching the user.

## ▶️ Running the Project

### 1. Clone the repository

```bash
git clone YOUR_REPOSITORY_URL
```

### 2. Open the solution

Open:

```text
AutoTrackVehicleRental.sln
```

in Visual Studio.

### 3. Configure SQL Server

Update the SQL Server connection string in `VehicleDbContext.cs` to match your local SQL Server instance.

Example:

```csharp
optionsBuilder.UseSqlServer(
    "Server=YOUR_SERVER;Database=AutoTrackVehicleRentalDb;Trusted_Connection=True;TrustServerCertificate=True;"
);
```

### 4. Set the startup project

Set:

```text
AutoTrackVehicleRental.Web
```

as the startup project.

### 5. Apply the migration

Using the Package Manager Console:

```powershell
Update-Database
```

If the migration has not been created yet:

```powershell
Add-Migration InitialCreate
Update-Database
```

### 6. Run the application

Run the project from Visual Studio.

The application opens on the vehicle listing page.

## 🧪 Example Data

| Vehicle Name | Type | Availability | Registration Date |
|---|---|---|---|
| Toyota Fortuner | SUV | Available | 11-08-2026 |
| Hyundai Creta | SUV | Available | 10-08-2026 |
| Honda City | Sedan | Not Available | 05-08-2026 |
| Maruti Swift | Hatchback | Available | 01-08-2026 |
| Ford Ranger | Truck | Available | 28-07-2026 |

## 📚 Learning Outcomes

This project provided practical experience with:

- ASP.NET Core MVC
- MVC Controllers and Views
- Razor syntax
- Data Annotations
- Model validation
- Multi-layer architecture
- Repository Pattern
- Service Layer
- Entity Framework Core
- SQL Server
- EF Core migrations
- LINQ
- Dependency Injection
- CRUD operations
- Exception handling
- Mapping between ViewModels and database entities
- Bootstrap
- MVC application development

## 🎯 Project Objective

The project demonstrates how a manual spreadsheet-based vehicle management process can be replaced with a structured web application.

The application provides a centralized way for AutoTrack Vehicle Rental Service staff to:

- Maintain vehicle records
- Check vehicle availability
- Update vehicle information
- Remove retired or damaged vehicles
- Search vehicles by type

## 👨‍💻 Author

**Mukul Deshwal**

Computer Science & Engineering
