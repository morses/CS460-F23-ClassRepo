using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simple.Areas.Identity.Data;

namespace Simple.Data;

public class ApplicationDbContext : IdentityDbContext<SimpleUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
