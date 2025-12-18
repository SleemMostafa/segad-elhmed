# Copilot Instructions for segad-elhmd

## Project Overview
This is a .NET 8.0 Blazor Server application using **Clean Architecture with CQRS and MediatR** for a carpet stock management admin dashboard. The project uses interactive server-side rendering and follows strict separation of concerns with Command Query Responsibility Segregation.

## Clean Architecture with CQRS Structure

### Layer Organization (Separate Class Libraries)
```
segad-elhmd/
├── segad-elhmd.sln           # Solution file
├── Domain/                   # Class Library - No dependencies
│   ├── Entities/             # Business entities (Carpet)
│   └── Domain.csproj
├── Application/              # Class Library - References: Domain, MediatR
│   ├── Commands/             # Write operations (Create, Update, Delete)
│   ├── Queries/              # Read operations (GetAll, GetById)
│   ├── DTOs/                 # Data transfer objects
│   └── Application.csproj
├── Infrastructure/           # Class Library - References: Domain
│   ├── Data/                 # Data store implementation (CarpetDataStore)
│   └── Infrastructure.csproj
└── segad-elhmd/              # Blazor Web - References: Application, Infrastructure
    ├── Components/           # Blazor UI (Presentation layer)
    │   ├── Pages/            # Routable pages
    │   └── Layout/           # Layout components
    └── segad-elhmd.csproj
```

### CQRS Pattern with MediatR

#### Commands (Write Operations)
Commands modify state and are located in [Application/Commands](Application/Commands/):
- `CreateCarpetCommand` - Adds new carpet
- `UpdateCarpetCommand` - Updates existing carpet
- `DeleteCarpetCommand` - Removes carpet

Each command has a dedicated handler (e.g., `CreateCarpetCommandHandler`) that processes the business logic.

**Command Pattern:**
```csharp
public record CreateCarpetCommand(CreateCarpetDto CarpetDto) : IRequest<CarpetDto>;

public class CreateCarpetCommandHandler : IRequestHandler<CreateCarpetCommand, CarpetDto>
{
    private readonly CarpetDataStore _dataStore;
    
    public async Task<CarpetDto> Handle(CreateCarpetCommand request, CancellationToken cancellationToken)
    {
        // Business logic here
    }
}
```

#### Queries (Read Operations)
Queries retrieve data without side effects, located in [Application/Queries](Application/Queries/):
- `GetAllCarpetsQuery` - Returns all carpets
- `GetCarpetByIdQuery` - Returns single carpet by ID

**Query Pattern:**
```csharp
public record GetAllCarpetsQuery : IRequest<IEnumerable<CarpetDto>>;

public class GetAllCarpetsQueryHandler : IRequestHandler<GetAllCarpetsQuery, IEnumerable<CarpetDto>>
{
    private readonly CarpetDataStore _dataStore;
    
    public async Task<IEnumerable<CarpetDto>> Handle(GetAllCarpetsQuery request, CancellationToken cancellationToken)
    {
        // Query logic here
    }
}
```

### Dependency Rules
- **Domain**: No dependencies - contains only entities
- **Application**: Depends only on Domain and MediatR - contains commands, queries, handlers, and DTOs
- **Infrastructure**: Implements data storage - `CarpetDataStore` is a thread-safe in-memory store
- **Components (Web)**: Depends on Application (MediatR) - presentation logic only

## Domain Layer

### Entities
Entities contain business logic and calculated properties. See [Carpet.cs](Domain/Entities/Carpet.cs):
- `TotalPrice` and `Area` are calculated properties
- Use `Guid` for IDs
- Include `CreatedAt` and `UpdatedAt` timestamps

## Application Layer

### DTOs
Separate DTOs for different operations ([Application/DTOs](Application/DTOs/)):
- `CarpetDto` - for reads/queries
- `CreateCarpetDto` - for creation (no Id)
- `UpdateCarpetDto` - for updates (requires Id)

### MediatR Usage in Handlers
All handlers inject `CarpetDataStore` for data access:
- Handlers are automatically discovered and registered by MediatR
- Use `record` types for commands/queries for immutability
- Return DTOs, not domain entities, to presentation layer

## Infrastructure Layer

### CarpetDataStore
Thread-safe in-memory storage ([CarpetDataStore.cs](Infrastructure/Data/CarpetDataStore.cs)):
- Uses `SemaphoreSlim` for concurrency control
- Singleton lifetime in DI container
- Easily replaceable with EF Core DbContext

## Blazor Component Patterns

### Using MediatR in Pages
All pages inject `IMediator` instead of service interfaces:
```razor
@inject IMediator Mediator

@code {
    // Query example
    var carpets = await Mediator.Send(new GetAllCarpetsQuery());
    
    // Command example
    await Mediator.Send(new CreateCarpetCommand(createDto));
}
```

### Page Components
- [Carpets.razor](segad-elhmd/Components/Pages/Carpets.razor) - Uses `GetAllCarpetsQuery` and `DeleteCarpetCommand`
- [CreateCarpet.razor](segad-elhmd/Components/Pages/CreateCarpet.razor) - Uses `CreateCarpetCommand`
- [EditCarpet.razor](segad-elhmd/Components/Pages/EditCarpet.razor) - Uses `GetCarpetByIdQuery` and `UpdateCarpetCommand`

All use `@rendermode InteractiveServer` for state management.

## Dependency Injection Configuration

[Program.cs](segad-elhmd/Program.cs) registers MediatR and data store:
```csharp
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddSingleton<CarpetDataStore>();
```

MediatR automatically discovers all `IRequestHandler` implementations in the assembly.

## Development Workflow

### Running the Application
```powershell
dotnet run --project segad-elhmd/segad-elhmd.csproj
# Navigate to: https://localhost:7104/carpets
```

### Adding New Features (CQRS Pattern)

#### For Read Operations:
1. Create query record in `Application/Queries/` (e.g., `GetCarpetsByColorQuery`)
2. Create query handler implementing `IRequestHandler<TQuery, TResult>`
3. Use in Blazor pages: `await Mediator.Send(new GetCarpetsByColorQuery(color))`

#### For Write Operations:
1. Create command record in `Application/Commands/` (e.g., `UpdateStockCommand`)
2. Create command handler implementing `IRequestHandler<TCommand, TResult>`
3. Inject `CarpetDataStore` in handler for data access
4. Use in Blazor pages: `await Mediator.Send(new UpdateStockCommand(id, quantity))`

#### Adding Navigation:
Add NavLink in [NavMenu.razor](segad-elhmd/Components/Layout/NavMenu.razor)

## Key Benefits of CQRS with MediatR

- **Separation of Concerns**: Read and write operations are completely separate
- **Testability**: Each handler can be unit tested independently
- **Scalability**: Queries and commands can be optimized differently
- **Maintainability**: Single Responsibility - one handler per operation
- **No Repository Interfaces**: MediatR eliminates the need for repository pattern
- **Request/Response Pattern**: Clear contract for each operation

## Namespace Convention
Due to hyphenated project name (`segad-elhmd`), use `segad_elhmd` in C# namespaces and using statements.

## Key Technical Decisions
- **MediatR over Repository Pattern**: Simplifies architecture, eliminates service layer
- **CQRS**: Clear separation between reads and writes
- **In-memory storage**: `CarpetDataStore` as singleton for shared state
- **Record types**: Commands and queries use records for immutability
- **Bootstrap 5**: UI framework (via `wwwroot/lib/bootstrap/`)
- **.NET 8 features**: Compatible with .NET 8 SDK

## Migration from Repository Pattern
The project no longer uses:
- ❌ `ICarpetRepository` interface
- ❌ `InMemoryCarpetRepository` implementation
- ❌ `ICarpetService` interface
- ❌ `CarpetService` implementation

Instead, it uses:
- ✅ MediatR `IMediator` interface
- ✅ Command and Query handlers
- ✅ Direct data store access in handlers

## Important Notes
- Project targets .NET 8.0 (configurable via [global.json](global.json))
- No test projects currently - add xUnit projects for testing handlers
- Validation not yet implemented - add FluentValidation with MediatR pipeline
- Authentication/Authorization not configured
- For production: Replace `CarpetDataStore` with EF Core DbContext
