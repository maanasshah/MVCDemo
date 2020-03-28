using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Configuration;
using MVCDemo.Model;

namespace MVCDemo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ICategoryContext _dbContext;

        public CategoryRepository(ICategoryContext context)
        {
            this._dbContext = context;
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return (from val in _dbContext.Category
                        select val).ToList();
        }
    }
}