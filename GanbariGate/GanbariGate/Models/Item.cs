using System;

namespace GanbariGate.Models
{
    public class Item : BaseEntity
    {
        //For SQLite
        public Item()
        {
        }

        public string Text { get; set; }
        public string Description { get; set; }
    }
}