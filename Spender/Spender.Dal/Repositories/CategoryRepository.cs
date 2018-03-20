using Spender.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Spender.Dal.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(string filename) : base(filename)
        {

        }

        public override TableQuery<Category> AsQueryable => this.database.Table<Category>();

        public override IEnumerable<Category> GetItems()
        {
            return database.Table<Category>().Select(x => x).ToList();
        }

        public override Category GetItem(int id)
        {
            try
            {
                return database.Get<Category>(id);
            }
            catch
            {
                return null;
            }
        }
    }
}