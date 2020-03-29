using System.Linq;
using GanbariGate.MobileAppService.Data;
using GanbariGate.MobileAppService.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GanbariGate.Controllers
{
    [Route("api/[controller]")]
    public class DecksController : Controller
    {
        private readonly GanbariGateContext _dbContext;

        public DecksController(GanbariGateContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult List()
        {
            var decks = _dbContext
                .Set<Deck>()
                .Include(x => x.Cards)
                .Select(x=>new
                {
                    x.Id,
                    x.Name,
                    cards = x.Cards.Select(c=>new
                    {
                        c.Id,
                        c.VisibleSide,
                        c.HiddenSide,
                        c.DeckId
                    })
                })
                .ToArray();

            // if (decks.Length == 0)
            // {
            //     var newDeck = new Deck("Default deck if not exists");
            //     _dbContext.Add(newDeck);
            //     _dbContext.Add(new Card("Vis side #1", "Hid side #1", newDeck));
            //     _dbContext.Add(new Card("Vis side #2", "Hid side #2", newDeck));
            //     _dbContext.SaveChanges();
            //
            //     decks = _dbContext
            //         .Set<Deck>()
            //         .Include(x => x.Cards)
            //         .Select(x=>new
            //         {
            //             x.Id,
            //             x.Name,
            //             cards = x.Cards.Select(c=>new
            //             {
            //                 c.Id,
            //                 c.VisibleSide,
            //                 c.HiddenSide,
            //                 c.DeckId
            //             })
            //         })
            //         .ToArray();
            // }

            return Ok(decks);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(long id)
            => Ok(_dbContext
                .Set<Deck>()
                .Find(id));

        [HttpPost]
        public IActionResult Create([FromBody] Deck deck)
        {
            _dbContext.Add(deck);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Deck deck, long id)
        {
            var existingDeck = _dbContext
                .Set<Deck>()
                .Find(id);

            existingDeck.Cards = deck.Cards;
            existingDeck.Name = deck.Name;

            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var existingDeck = _dbContext
                .Set<Deck>()
                .Find(id);

            _dbContext.Remove(existingDeck);
            
            return Ok();
        }
    }
}