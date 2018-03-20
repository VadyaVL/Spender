using Spender.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Spender.Dal.Repositories
{
    public class JobRepository : Repository<Job>
    {
        public JobRepository(string filename) : base(filename)
        {

        }

        public override TableQuery<Job> AsQueryable => this.database.Table<Job>();

        public override IEnumerable<Job> GetItems()
        {
            return database.Table<Job>().Select(x => x).ToList();
        }

        public override Job GetItem(int id)
        {
            try
            {
                return database.Get<Job>(id);
            }
            catch
            {
                return null;
            }
        }
    }
}
