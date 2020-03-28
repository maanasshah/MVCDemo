using System.Collections.Generic;
using MVCDemo.Model;

namespace MVCDemo.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}