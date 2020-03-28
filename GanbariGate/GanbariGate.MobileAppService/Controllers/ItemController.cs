using System;
using System.Collections.Generic;
using System.Linq;
using GanbariGate.MobileAppService.Data;
using Microsoft.AspNetCore.Mvc;
using GanbariGate.Models;
using Microsoft.EntityFrameworkCore;

namespace GanbariGate.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly GanbariGateContext _dbContext;

        public ItemController(GanbariGateContext dbContext)
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

            var list = new List<int> {1, 2, 3};

            return Ok(decks);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(string id)
        {
            // Item item = ItemRepository.Get(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Item item)
        {
            // try
            // {
            //     if (item == null || !ModelState.IsValid)
            //     {
            //         return BadRequest("Invalid State");
            //     }
            //
            //     ItemRepository.Add(item);
            // }
            // catch (Exception)
            // {
            //     return BadRequest("Error while creating");
            // }

            return Ok(item);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Item item)
        {
            // try
            // {
            //     if (item == null || !ModelState.IsValid)
            //     {
            //         return BadRequest("Invalid State");
            //     }
            //
            //     ItemRepository.Update(item);
            // }
            // catch (Exception)
            // {
            //     return BadRequest("Error while creating");
            // }

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            // ItemRepository.Remove(id);
            return Ok();
        }
    }
}