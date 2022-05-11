namespace Kampa.MyClientelle.Persistence;
#nullable disable
using Kampa.MyClientelle.Persistence.Model;

using Microsoft.EntityFrameworkCore;

public class MyClientelleDbContext : DbContext
{
  public MyClientelleDbContext()
  {
  }

  public MyClientelleDbContext(DbContextOptions<MyClientelleDbContext> options)
    : base(options)
  {
  }

  public DbSet<Patient> Patients { get; init; }

  public DbSet<Appointment> Appointments { get; init; }

  public DbSet<Examination> Examination { get; init; }

  /// <inheritdoc />
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ArgumentNullException.ThrowIfNull(optionsBuilder);

    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Database=MyClientelle;Integrated Security=true");
    }

    base.OnConfiguring(optionsBuilder);
  }
}
