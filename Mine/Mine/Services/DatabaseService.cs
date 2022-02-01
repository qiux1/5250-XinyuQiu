using System;
using System Ling;
using System.Threading.Tasks;

using SQLite;

using Mine.Models;

namespace Mine.Services
{
    public class DatabaseService
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });
    }
}