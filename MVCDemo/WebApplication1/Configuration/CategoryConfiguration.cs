using System.Data.Entity.ModelConfiguration;
using MVCDemo.Model;

namespace MVCDemo.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");
            HasKey(x => x.CategoryId);
        }
    }
}