//using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

using searching.troll.Domain.Catalog;

using searching.troll.Data;

namespace searching.troll.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {

        private readonly StoreContext _context;

        public CatalogController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_context.Items);
            // var items = new[]
            // {
            //     new Item(name: "Item 1", description: "Description 1", brand: "Brand 1", price: 100.00m ),
            //     new Item(name: "Item 2", description: "Description 2", brand: "Brand 2", price: 200.00m ),
            //     new Item(name: "Item 3", description: "Description 3", brand: "Brand 3", price: 300.00m ),
            //     new Item(name: "Item 4", description: "Description 4", brand: "Brand 4", price: 400.00m ),
            //     new Item(name: "Item 5", description: "Description 5", brand: "Brand 5", price: 500.00m )
            // };

            // return Ok(items);
       }
         [HttpGet("{id:int}")]
            public IActionResult GetItem(int id)
            {
                var item = _context.Items.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            [HttpPost]
            public IActionResult CreateItem(Item item)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return Created($"api/catalog/{item.Id}", item);
            }
            [HttpPost("{id:int}/ratings")]
            public IActionResult AddRating(int id, Rating rating)
            {
                var item = _context.Items.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.AddRating(rating);
                _context.SaveChanges();
                return Ok(item);
            }
            [HttpPut("{id:int}")]

                public IActionResult UpdateItem(int id, Item item)
                {
                 // return NoContent();
                   if(id != item.Id)
                   {
                       return BadRequest();
                   }
                   var existingItem = _context.Items.Find(id);
                   if(existingItem == null)
                   {
                       return NotFound();
                   }
                   _context.Entry(existingItem).CurrentValues.SetValues(item);
                   _context.SaveChanges();
                   return Ok(item);
                }
            [HttpDelete("{id:int}")]
            public IActionResult DeleteItem(int id)
            {
                var item = _context.Items.Find(id);
                if (item == null)
                {
                    return NotFound();
                }
                _context.Items.Remove(item);
                _context.SaveChanges();
                return NoContent();
            }
    }
}