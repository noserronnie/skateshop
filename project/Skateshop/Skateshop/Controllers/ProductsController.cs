using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skateshop.Composite;
using Skateshop.Data;
using Skateshop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skateshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SkateshopContext _context;

        public ProductsController(SkateshopContext context)
        {
            _context = context;
        }

        // GET: DeckProducts
        public async Task<IActionResult> Index()
        {
            var products = new List<Product>();
            products.AddRange(await _context.DeckProduct.ToListAsync());
            products.AddRange(await _context.TrucksProduct.ToListAsync());
            return View(products);
        }

        // GET: DeckProducts/Details/5
        public async Task<IActionResult> DeckDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.DeckProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null && !(product is DeckProduct))
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: DeckProducts/Details/5
        public async Task<IActionResult> TrucksDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.DeckProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null && !(product is DeckProduct))
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: DeckProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeckProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Width,Length,Wheelbase,Nose,Tail,Description,Price")] DeckProduct deckProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deckProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deckProduct);
        }

        // GET: DeckProducts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckProduct = await _context.DeckProduct.FindAsync(id);
            if (deckProduct == null)
            {
                return NotFound();
            }
            return View(deckProduct);
        }

        // POST: DeckProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Width,Length,Wheelbase,Nose,Tail,Description,Price")] DeckProduct deckProduct)
        {
            if (id != deckProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deckProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckProductExists(deckProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deckProduct);
        }

        // GET: DeckProducts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deckProduct = await _context.DeckProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deckProduct == null)
            {
                return NotFound();
            }

            return View(deckProduct);
        }

        // POST: DeckProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var deckProduct = await _context.DeckProduct.FindAsync(id);
            _context.DeckProduct.Remove(deckProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckProductExists(long id)
        {
            return _context.DeckProduct.Any(e => e.Id == id);
        }
    }
}
