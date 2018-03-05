using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Spender.Dal;
using Spender.Logic.Models;
using Spender.Models;

namespace Spender.Logic.Services
{
    public class CategoryService : BasicService, ICategoryService
    {
        public CategoryService(IUow uow) : base(uow)
        {

        }

        public long Create(CategoryModel newCategory)
        {
            return this.Unit.Categories.SaveItem(Mapper.Map<Category>(newCategory));
        }

        public ICollection<CategoryModel> GetList()
        {
            return this.Unit.Categories.GetItems().Select(category => Mapper.Map<CategoryModel>(category)).ToList();
        }

        public void InitDefault()
        {
            // Read it from default.xml - create it
            this.Unit.Categories.SaveItem(new Category { Title = "Work" });
            this.Unit.Categories.SaveItem(new Category { Title = "Home Work" });
        }
    }
}