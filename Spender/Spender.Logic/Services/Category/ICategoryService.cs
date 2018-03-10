using Spender.Logic.Models;
using Spender.Models;
using System.Collections.Generic;

namespace Spender.Logic.Services
{
    public interface ICategoryService
    {
        ICollection<CategoryModel> GetList();

        int Create(CategoryModel newCategory);

        int Edit(CategoryModel newCategory);

        Category Get(int id);

        int Delete(int id);

        void InitDefault();
    }
}
