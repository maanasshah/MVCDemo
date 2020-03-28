using System.Data.Entity.ModelConfiguration;
using MVCDemo.Model;

namespace MVCDemo.Configuration
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            ToTable("Transaction");
            HasKey(x => x.Id);
        }
    }
}