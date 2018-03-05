using Spender.Dal.Services;
using Spender.Droid.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace Spender.Droid.Services
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
        {

        }

        public string GetDatabasePath(string sqliteFilename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return Path.Combine(documentsPath, sqliteFilename);
        }
    }
}