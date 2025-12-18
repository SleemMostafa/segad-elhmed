# Database Setup Instructions

This project uses **SQL Server** with **Entity Framework Core** for data persistence.

## Prerequisites

- SQL Server LocalDB (comes with Visual Studio) or SQL Server Express/Full
- .NET 8.0 SDK

## Connection String Configuration

The application uses different databases for Development and Production:

### Development Environment
- Database: `SegadElhmdDb_Dev`
- Connection configured in `appsettings.Development.json`
- Uses LocalDB: `(localdb)\mssqllocaldb`

### Production Environment
- Database: `SegadElhmdDb`
- Connection configured in `appsettings.json`
- Update connection string for your production SQL Server

## Database Migrations

### Automatic Migrations (Development)
The application automatically applies migrations when running in Development mode. Just run the application:

```powershell
cd segad-elhmd
dotnet run
```

### Manual Migrations (Production)

If you need to create or apply migrations manually:

1. **Create Initial Migration** (already done if migrations folder exists):
```powershell
cd segad-elhmd
dotnet ef migrations add InitialCreate --project ..\Infrastructure\Infrastructure.csproj --startup-project .\segad-elhmd.csproj
```

2. **Apply Migrations**:
```powershell
dotnet ef database update --project ..\Infrastructure\Infrastructure.csproj --startup-project .\segad-elhmd.csproj
```

3. **View Migration SQL** (optional):
```powershell
dotnet ef migrations script --project ..\Infrastructure\Infrastructure.csproj --startup-project .\segad-elhmd.csproj
```

### Installing EF Core Tools

If `dotnet ef` command is not recognized:

```powershell
dotnet tool install --global dotnet-ef
```

## Database Schema

### Carpets Table

| Column | Type | Constraints |
|--------|------|-------------|
| Id | uniqueidentifier | PRIMARY KEY |
| Name | nvarchar(200) | NOT NULL |
| Type | nvarchar(100) | NOT NULL |
| Description | nvarchar(max) | NULL |
| Color | nvarchar(50) | NOT NULL |
| Material | nvarchar(max) | NULL |
| Width | decimal(18,2) | NOT NULL |
| Length | decimal(18,2) | NOT NULL |
| PricePerSquareMeter | decimal(18,2) | NOT NULL |
| StockQuantity | int | NOT NULL |
| CreatedAt | datetime2 | NOT NULL |
| UpdatedAt | datetime2 | NULL |

**Note**: `Area` and `TotalPrice` are computed properties in the application and not stored in the database.

## Changing Database Provider

To use a different database provider:

1. Replace the package in `Infrastructure.csproj`:
   - SQL Server: `Microsoft.EntityFrameworkCore.SqlServer`
   - PostgreSQL: `Npgsql.EntityFrameworkCore.PostgreSQL`
   - MySQL: `Pomelo.EntityFrameworkCore.MySql`
   - SQLite: `Microsoft.EntityFrameworkCore.Sqlite`

2. Update `Program.cs` to use the appropriate provider:
```csharp
// SQL Server
options.UseSqlServer(connectionString)

// PostgreSQL
options.UseNpgsql(connectionString)

// MySQL
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))

// SQLite
options.UseSqlite(connectionString)
```

## Troubleshooting

### LocalDB Not Found
If LocalDB is not installed:
- Install SQL Server Express with LocalDB
- Or update connection string to use SQL Server Express/Full

### Migration Errors
If you encounter migration errors:
```powershell
# Remove all migrations
dotnet ef migrations remove --project ..\Infrastructure\Infrastructure.csproj --startup-project .\segad-elhmd.csproj

# Recreate initial migration
dotnet ef migrations add InitialCreate --project ..\Infrastructure\Infrastructure.csproj --startup-project .\segad-elhmd.csproj

# Update database
dotnet ef database update --project ..\Infrastructure\Infrastructure.csproj --startup-project .\segad-elhmd.csproj
```

### Connection Issues
Check:
1. SQL Server service is running
2. Connection string is correct
3. Database user has proper permissions
4. Firewall allows SQL Server connections (if remote)

## Production Deployment

For production:

1. Update connection string in `appsettings.json`
2. **Remove automatic migration** from `Program.cs` (security best practice)
3. Apply migrations manually or through deployment pipeline:
```powershell
dotnet ef database update --connection "Your Production Connection String"
```

## Seeding Data (Optional)

To add initial/seed data, create a class in Infrastructure:

```csharp
public static class DataSeeder
{
    public static void SeedData(AppDbContext context)
    {
        if (!context.Carpets.Any())
        {
            context.Carpets.AddRange(
                new Carpet { /* properties */ },
                new Carpet { /* properties */ }
            );
            context.SaveChanges();
        }
    }
}
```

Call in `Program.cs`:
```csharp
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
DataSeeder.SeedData(dbContext);
```
