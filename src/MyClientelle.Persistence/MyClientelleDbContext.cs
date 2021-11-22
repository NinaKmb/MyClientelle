namespace Kampa.MyClientelle.Persistence;
#nullable disable

using Kampa.MyClientelle.Persistence.Model;

using Microsoft.EntityFrameworkCore;

public class MyClientelleDbContext : DbContext
{
  public MyClientelleDbContext(DbContextOptions<MyClientelleDbContext> options)
    : base(options)
  {
  }

  public DbSet<Patient> Patients { get; init; }
}