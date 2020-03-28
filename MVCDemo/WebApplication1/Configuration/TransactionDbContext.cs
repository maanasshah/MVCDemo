using System.Data.Entity;
using MVCDemo.Model;

namespace MVCDemo.Configuration
{
    public class TransactionDbContext : DbContext, ITransactionContext
    {
        public TransactionDbContext() : base("defaultconn") 
        {
            Database.SetInitializer<TransactionDbContext>(null);
        }
        public DbSet<Transaction> Transaction { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            modelBuilder.Properties<string>().Configure(x => x.IsUnicode(false));
        }
    }
}