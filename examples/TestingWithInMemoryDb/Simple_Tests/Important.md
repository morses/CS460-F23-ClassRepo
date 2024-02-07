You'll need these packages:

- Microsoft.Data.Sqlite.Core
- Microsoft.EntityFrameworkCore.Sqlite

And make sure your db context OnConfiguring method does not automatically use SQL Server.  EF cannot simultaneously use
2 different providers, i.e. SQLite and SQL Server.  Here's mine

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer("Name=AppConnection");
    }
    optionsBuilder.UseLazyLoadingProxies();
}
```
