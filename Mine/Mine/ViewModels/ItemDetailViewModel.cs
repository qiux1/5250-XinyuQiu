using System;

using Mine.Models;

namespace Mine.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemModel ItemModel { get; set; }
        public ItemDetailViewModel(ItemModel ItemModel = null)
        {
            Title = ItemModel?.Text;
            this.ItemModel = ItemModel;
        }
    }
}
