using Spender.Logic.Models;
using System.Collections.Generic;

namespace Spender.Logic.Services
{
    public interface ICategoryService
    {
        ICollection<CategoryModel> GetList();

        long Create(CategoryModel newCategory);
    }
}
