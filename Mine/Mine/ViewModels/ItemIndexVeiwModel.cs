using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Mine.Models;
using Mine.Views;

namespace Mine.ViewModels
{
    public class ItemIndexVeiwModel : BaseViewModel
    {
        public ObservableCollection<ItemModel> DataSet { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemIndexVeiwModel()
        {
            Title = "Items";
            DataSet = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemCreatePage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ItemModel;
                DataSet.Add(newItem);
                await DataStore.CreateAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemDeletePage, ItemModel>(this, "DeleteItem", async (obj, item) =>
            {
                var data = item as ItemModel;
                await DeleteAsync(data);
            });

            MessagingCenter.Subscribe<ItemUpdatePage, ItemModel>(this, "UpdateItem", async (obj, item) =>
            {
                var data = item as ItemModel;
                await UpdateAsyc(data);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DataSet.Clear();
                var items = await DataStore.IndexAsync(true);
                foreach (var item in items)
                {
                    DataSet.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Read an item from the datastore
        /// </summary>
        /// <param name="id">ID of the Record</param>
        /// <returns>The Record from ReadAsync</returns>
        public async Task<ItemModel> ReadAsync(string id)
        {
            var result = await DataStore.ReadAsync(id);
            return result;

        }

        public async Task<bool> DeleteAsync(ItemModel data)
        {
            //Check if the record exists, if it does not, then null is returned
            var record = await ReadAsync(data.Id);
            if (record == null)
            {
                return false;
            }

            //Remove from the local data set cache
            DataSet.Remove(data);

            //Call to remove it from the Data Store
            var result = await DataStore.DeleteAsync(data.Id);

            return result;
        }

        public async Task<bool> UpdateAsyc(ItemModel data)
        {
            // Check if the record exists,
            // if it does not, then False is returned
            var record = await ReadAsync(data.Id);
            if (record == null)
            {
                return false;
            }

            // Call to update it from the Data Store
            var result = await DataStore.UpdateAsync(data);

            // Need the list box on ItemIndex to refresh
            // The way to do it is to force the ItemIndexViewModel
            // to refresh the dataset
            var canExecute = LoadItemsCommand.CanExecute(null);
            LoadItemsCommand.Execute(null);

            return result;
        }
    }
}