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

        //Create a variable to store the value from the initialization
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        //Boolean status variable to check if the connection is initialized
        static bool initialized = false;

        //Constructor
        public DatabaseService()
        {
            InitializeAsnyc().SafeFireAndForget(false);
        } 

        //Task to initialized the DatabaseService
        async Task InitializeAsnyc()
        {
            //If the DatabaseService is nto initialized
            if (!initialized)
            {
                if (!Database.TableMappings.Any(mbox =>m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                //Change the status variable to true
                initialized = true;  
            }
        }


    }
}