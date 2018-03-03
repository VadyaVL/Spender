using System.Collections.Generic;
using Spender.Logic.Models;

namespace Spender.Logic.Services
{
    public class CategoryService : ICategoryService
    {
        public long Create(CategoryModel newCategory)
        {
            return 0;
        }

        public ICollection<CategoryModel> GetList()
        {
            return new List<CategoryModel> { new CategoryModel { Title = "Work" },
                                             new CategoryModel { Title = "Home Work" }};
        }
    }
}