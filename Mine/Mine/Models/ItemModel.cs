using System;

namespace Mine.Models
{
    public class ItemModel
    {
        //The Id for the Item
        public string Id { get; set; }

        //The Display for the Item
        public string Text { get; set; }

        //The Description for the Item
        public string Description { get; set; }

        //The Value of the Item +9 Damge
        public int Value { get; set; } = 0;
    }
}