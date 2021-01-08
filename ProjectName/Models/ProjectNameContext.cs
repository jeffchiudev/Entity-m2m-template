using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
  public class ProjectNameContext : DbContext
  {
    public virtual DbSet<Parent> Parents { get; set; }
    public DbSet<Child> Childs { get; set; }
    public DbSet<ParentChild> ParentChild { get; set; }

    public ProjectNameContext(DbContextOptions options) : base(options) { }
  }
}