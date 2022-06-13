## Classes/Entities and Objects

1. Movie (Name, Code, Descripttion, ReleaseDate, Length)
1. Crew ()

## Database setup
1. Setup ORM tool (EF Core)
	* Database first
	* Code First Approach
1. Install EF Core
> dotnet add package Microsoft.EntityFrameworkCore
1. Install database provider 
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
1. Install EF Core design package for migrations
> dotnet add package Microsoft.EntityFrameworkCore.Design

1. Modify Program.cs to register dbcontext class
```
builder.Services.AddDbContext<MovieManagementDb>(options =>
{
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MovieDb;Trusted_Connection=True");    
});
```
1. 