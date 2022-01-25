using System;

using Mine.Models;

namespace Mine.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemModel Item { get; set; }
        public ItemDetailViewModel(ItemModel Item = null)
        {
            Title = Item?.Text;
            this.Item = Item;
        }
    }
}
