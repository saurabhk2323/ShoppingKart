# InventoryManagement

A Web API for managing products in an inventory, including CRUD operations and stock management.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (local or remote)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)

## Getting Started

### 1. Clone the Repository

```cmd
git clone https://github.com/saurabhk2323/ShoppingKart.git
cd ShoppingKart
```

### 2. Configure the Database

Update the connection string in `appsettings.json`:

```json
"SqlServer": {
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=InventoryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
  }
```

### 3. Install required packages
#### For InventoryManagement
```cmd
dotnet add package AutoMapper --version 12.0.0
dotnet add package Microsoft.ApplicationInsights.AspNetCore --version 2.23.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.20
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.20
dotnet add package Newtonsoft.Json --version 13.0.4-beta1
dotnet add package Swashbuckle.AspNetCore --version 6.6.2
```
#### For InventoryManagementTest
```cmd
dotnet add package xunit --version 2.5.3
dotnet add package Moq --version 4.20.72
dotnet add package Newtonsoft.Json --version 13.0.4-beta1
dotnet add package xunit.runner.visualstudio --version 2.5.3
```

### 4. Apply Migrations

#### Navigate to your project
```cmd
cd InventoryManagement
```

#### Verify installation
```cmd
dotnet ef --version
```

#### Install Entity Framework Core tools globally
```cmd
dotnet tool install --global dotnet-ef
```

#### If already installed, update it
```cmd
dotnet tool update --global dotnet-ef
```



#### EF commands

##### Drop the existing database
```cmd
dotnet ef database drop
```

##### Apply fresh migration
```cmd
dotnet ef migrations add "Initial Setup"
dotnet ef database update
```

#### If successful, you should see:
##### - Migration files created in Migrations folder
##### - Database created with tables



### 4. Build the Solution

#### Switch to InventoryManagement folder and run below command
```cmd
dotnet restore
dotnet build
```

### 5. Run the API

#### Switch to InventoryManagement folder and run below command
```cmd
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`.

### 6. API Documentation

Swagger UI is enabled in development mode. Visit:

```
https://localhost:5000/swagger/index.html
```

### 7. Running Tests

To run unit tests:
```cmd
cd ShoppingKart
```

```cmd
dotnet test InventoryManagementTest
```

## Project Structure

- `InventoryManagement/` - Main Web API project
- `InventoryManagementTest/` - Unit tests for service layer

## Main Endpoints

- `POST /api/products` - Create a product
- `GET /api/products` - List all products
- `GET /api/products/{id}` - Get product by ID
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product
- `PUT /api/products/decrement-stock/{id}/{quantity}` - Decrement stock
- `PUT /api/products/add-to-stock/{id}/{quantity}` - Add to stock

## Notes

- Exception handling and response wrapping are enabled via middleware.
- Initial product data is seeded in the database.
- Logging is configured for console and debug output.
