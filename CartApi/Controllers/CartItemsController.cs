using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartApi.Models;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly CartContext _context;

        public CartItemsController(CartContext context)
        {
            _context = context;
        }

        // GET: api/CartItems
        [HttpGet("List/")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            if (_context.CartItems == null)
            {
                return NotFound();
            }
            return await _context.CartItems.ToListAsync();
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(long id)
        {
            if (_context.CartItems == null)
            {
                return NotFound();
            }
            var cartItem = await _context.CartItems.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return cartItem;
        }





        // PUT: api/CartItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(long id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }




        [HttpPatch("Update/{id}")]
        public async Task<IActionResult> PatchCartItem(long id, CartItem cartItem, int quantity, int unitPrice)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }
            var model = _context.CartItems.SingleOrDefault(m => m.Id == id);

            // _context.Entry(cartItem).State = EntityState.Modified;
            if (model != null)
            {
                model.Quantity += quantity;
                model.UnitPrice += unitPrice;
                _context.SaveChanges();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add/")]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            if (_context.CartItems == null)
            {
                return Problem("Entity set 'CartContext.CartItems'  is null.");
            }

            var cart = _context.CartItems.SingleOrDefault(m => m.Id == cartItem.Id);
            if (cart != null)
            {
                cart.ItemName = cartItem.ItemName;
                cart.Quantity += cartItem.Quantity;
                cart.UnitPrice += cartItem.UnitPrice;

            }
            else
            {

                _context.CartItems.Add(cartItem);

            }

            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.Id }, cartItem);
        }


        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(long id)
        {
            if (_context.CartItems == null)
            {
                return NotFound();
            }
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("FilterRecordsByTime")] // Specify a unique route
        public List<CartItem> FilterRecordsByTime(DateTime startTime, DateTime endTime)
        {
            var filteredRecords = _context.CartItems
                .Where(model => model.CreatedAt >= startTime && model.CreatedAt <= endTime)
                .ToList();

            return filteredRecords;
        }


        [HttpGet("FilterRecordsByQuantity")] // Specify a unique route
        public List<CartItem> FilterRecordsByQuantity(int quantity)
        {
            var filteredRecords = _context.CartItems
                .Where(model => model.Quantity == quantity)
                .ToList();

            return filteredRecords;
        }



        [HttpGet("FilterRecordsByItem")] // Specify a unique route
        public List<CartItem> FilterRecordsByItem(string item)
        {
            var filteredRecords = _context.CartItems
                .Where(model => model.ItemName == item)
                .ToList();

            return filteredRecords;
        }



        [HttpGet("FilterRecordsByPhoneNumber")] // Specify a unique route
        public List<CartItem> FilterRecordsByPhoneNumber(string phoneNumber)
        {
            var filteredRecords = _context.CartItems
                .Where(model => model.PhoneNumber == phoneNumber)
                .ToList();

            return filteredRecords;
        }

        private bool CartItemExists(long id)
        {
            return (_context.CartItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
