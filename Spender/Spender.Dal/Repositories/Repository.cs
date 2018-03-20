using Spender.Dal.Services;
using Spender.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Spender.Dal.Repositories
{
    public abstract class Repository<T> where T : IntIdent
    {
        protected SQLiteConnection database;

        protected Repository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            this.database = new SQLiteConnection(databasePath);
            this.database.CreateTable<T>();
        }

        public abstract TableQuery<T> AsQueryable { get; }
        
        public abstract IEnumerable<T> GetItems();

        public abstract T GetItem(int id);

        public virtual bool DeleteItem(int id)
        {
            return database.Delete<T>(id) == 1;
        }

        public virtual int SaveItem(T item)
        {
            var exist = this.GetItem(item.Id) != null;

            if (exist)
            {
                database.Update(item);
            }
            else
            {
                database.Insert(item);
            }

            return item.Id;
        }
    }
}