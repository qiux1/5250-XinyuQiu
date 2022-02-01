using System;
using System.Linq;
using System.Threading.Tasks;

using SQLite;

using Mine.Models;
using System.Collections.Generic;

namespace Mine.Services
{
    public class DatabaseService: IDataStore<ItemModel>
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
                if (!Database.TableMappings.Any(m =>m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                //Change the status variable to true
                initialized = true;  
            }
        }

        public Task<bool> CreateAsync(ItemModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ItemModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemModel> ReadAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}