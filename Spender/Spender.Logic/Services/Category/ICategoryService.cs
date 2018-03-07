using Spender.Logic.Models;
using System.Collections.Generic;

namespace Spender.Logic.Services
{
    public interface ICategoryService
    {
        ICollection<CategoryModel> GetList();

        int Create(CategoryModel newCategory);

        int Edit(CategoryModel newCategory);

        int Delete(int id);

        void InitDefault();
    }
}
