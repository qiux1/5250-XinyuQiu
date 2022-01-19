using System;

using Mine.Models;

namespace Mine.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemModel ItemModel { get; set; }
        public ItemDetailViewModel(Item ItemModel = null)
        {
            Title = item?.Text;
            ItemModel = item;
        }
    }
}
