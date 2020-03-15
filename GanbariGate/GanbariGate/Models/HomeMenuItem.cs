using System;
using System.Collections.Generic;
using System.Text;

namespace GanbariGate.Models
{
    public enum MenuItemType
    {
        About,
        Decks,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
