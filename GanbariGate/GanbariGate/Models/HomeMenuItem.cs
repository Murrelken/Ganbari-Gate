using System;
using System.Collections.Generic;
using System.Text;

namespace GanbariGate.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Decks,
        DevelopmentTest2,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
