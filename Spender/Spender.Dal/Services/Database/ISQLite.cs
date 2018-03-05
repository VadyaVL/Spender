namespace Spender.Dal.Services
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}