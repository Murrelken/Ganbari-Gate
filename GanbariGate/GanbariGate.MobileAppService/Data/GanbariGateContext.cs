using GanbariGate.Models;
using Microsoft.EntityFrameworkCore;

namespace GanbariGate.MobileAppService.Data
{
    public class GanbariGateContext : DbContext
    {
        public virtual DbSet<Deck> Decks { get; set; }
        public virtual DbSet<Card> Cards { get; set; }

        public GanbariGateContext(DbContextOptions options) : base(options)
        {
        }
    }
}