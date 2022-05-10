using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skateshop.Data;
using Skateshop.Models;
using Skateshop.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Skateshop.Controllers;

public class BrandsController : Controller
{
    private readonly SkateshopContext _context;
    private readonly IAuthService _authService;

    public BrandsController(SkateshopContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    // GET: Brands
    public async Task<IActionResult> Index()
    {
        if (_authService.IsAdmin(HttpContext))
        {
            return View(await _context.Brand.ToListAsync());
        }
        return Unauthorized();
    }

    // GET: Brands/Create
    public IActionResult Create()
    {
        if (_authService.IsAuthorized(HttpContext))
        {
            return View();
        }
        return Unauthorized();
    }

    // POST: Brands/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Brand brand)
    {
        if (!_authService.IsAuthorized(HttpContext))
        {
            return Unauthorized();
        }

        if (ModelState.IsValid)
        {
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(brand);
    }

    // GET: Brands/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (!_authService.IsAuthorized(HttpContext))
        {
            return Unauthorized();
        }

        if (id == null)
        {
            return NotFound();
        }

        var brand = await _context.Brand.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    // POST: Brands/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] Brand brand)
    {
        if (!_authService.IsAuthorized(HttpContext))
        {
            return Unauthorized();
        }

        if (id != brand.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(brand);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(brand.Id))
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
        return View(brand);
    }

    // GET: Brands/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (!_authService.IsAuthorized(HttpContext))
        {
            return Unauthorized();
        }

        if (id == null)
        {
            return NotFound();
        }

        var brand = await _context.Brand
            .FirstOrDefaultAsync(m => m.Id == id);
        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // POST: Brands/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_authService.IsAuthorized(HttpContext))
        {
            var brand = await _context.Brand.FindAsync(id);
            _context.Brand.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return Unauthorized();
    }

    private bool BrandExists(long id)
    {
        return _context.Brand.Any(e => e.Id == id);
    }
}
