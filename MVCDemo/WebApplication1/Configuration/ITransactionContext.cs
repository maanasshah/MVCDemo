using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MVCDemo.Model;

namespace MVCDemo.Configuration
{
    public interface ITransactionContext
    {
        DbSet<Transaction> Transaction { get; set; }
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}