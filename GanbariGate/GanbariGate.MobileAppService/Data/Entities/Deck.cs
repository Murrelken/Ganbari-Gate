using System.Collections.Generic;

namespace GanbariGate.MobileAppService.Data.Entities
{
    public class Deck : BaseEntity
    {
        protected Deck()
        {
            
        }
        
        public Deck(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public virtual IEnumerable<Card> Cards { get; set; }
    }
}