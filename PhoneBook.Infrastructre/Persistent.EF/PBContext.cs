using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PhoneBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructre.Persistent.EF;
public class PBContext : DbContext
{
    public PBContext(DbContextOptions<PBContext> options) : base(options)
    {
    
    }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

//class GameShopDbContextFactory : IDesignTimeDbContextFactory<PBContext>
//{
//    public GameShopDbContextFactory CreateDbContext(string[] args)
//    {
//        var builder = new DbContextOptionsBuilder<PBContext>();
//        var connStr = "";
//       dbContextBuilder.UseSqlServer(connStr);
//        return new PBContext(options: builder.Options);
//    }

//}