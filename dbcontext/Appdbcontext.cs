using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.dbcontext
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
    }
}
