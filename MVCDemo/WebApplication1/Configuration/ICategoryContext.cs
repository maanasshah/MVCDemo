using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MVCDemo.Model;

namespace MVCDemo.Configuration
{
    public interface ICategoryContext
    {
        DbSet<Category> Category { get; set; }
        DbEntityEntry Entry(object entity);
    }
}