using Spender.Dal.Services;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Spender.Dal.Repositories
{
    public abstract class Repository<T>
    {
        protected SQLiteConnection database;

        protected Repository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            this.database = new SQLiteConnection(databasePath);
            this.database.CreateTable<T>();
        }

        public abstract IEnumerable<T> GetItems();

        public abstract T GetItem(int id);

        public abstract int DeleteItem(int id);

        public abstract int SaveItem(T item);
    }
}