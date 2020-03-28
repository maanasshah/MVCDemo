using System.Data.Entity;
using MVCDemo.Model;

namespace MVCDemo.Configuration
{
    public class CategoryDbContext : DbContext, ICategoryContext
    {
        public CategoryDbContext() : base("defaultconn")
        {
            Database.SetInitializer<CategoryDbContext>(null);
        }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            modelBuilder.Properties<string>().Configure(x => x.IsUnicode(false));
        }
    }
}