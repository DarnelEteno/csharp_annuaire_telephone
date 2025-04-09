using AnnuaireTelephone.Data;
using AnnuaireTelephone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AnnuaireTelephone.Controllers;

public class ClientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Clients.Include(c => c.Telephones).ToListAsync());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        if (ModelState.IsValid)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }

    public async Task<IActionResult> Details(int id)
    {
        var client = await _context.Clients.Include(c => c.Telephones).FirstOrDefaultAsync(c => c.Id == id);
        return View(client);
    }
    
    // Statistiques
    // [HttpPost]
    // public async Task<IActionResult> Create(Telephone tel)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Add(tel);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index));
    //     }
    //     ViewBag.Clients = new SelectList(_context.Clients, "Id", "Matricule");
    //     return View(tel);
    // }
}