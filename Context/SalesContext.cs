
using SalesRecord.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace SalesRecord.Context;

public class SalesContext(DbContextOptions<SalesContext> options) : IdentityDbContext(options);


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<State> States { get; set; }
    public DbSet<SalesDetail> SalesDetails { get; set; }
    public DbSet<Member> Members { get; set; }
