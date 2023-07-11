using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using uniPlanner.Areas.Identity.Data;
using uniPlanner.Models;

namespace uniPlanner.Areas.Identity.Data;

public class uniPlannerContext : IdentityDbContext<uniPlannerUser>
{
    public uniPlannerContext(DbContextOptions<uniPlannerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<uniPlanner.Models.Programmes> Programmes { get; set; } = default!;

    public DbSet<uniPlanner.Models.UniversityInfo> UniversityInfo { get; set; } = default!;

    public DbSet<uniPlanner.Models.UniProgrammes> UniProgrammes { get; set; } = default!;
}
