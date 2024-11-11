using Microsoft.EntityFrameworkCore;
using NoteProject.Domain.Entity;
namespace NoteProject.Dal;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
   
        Database.EnsureCreated();
    }

    public DbSet<NoteEntity> Notes { get; set; }


}