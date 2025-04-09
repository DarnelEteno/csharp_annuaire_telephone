using AnnuaireTelephone.Data;
using AnnuaireTelephone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AnnuaireTelephone.Controllers;

public class TelephonesController : Controller
{
    private readonly ApplicationDbContext _context;

    public TelephonesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string clientMatricule, string operateur)
    {
        var query = _context.Telephones.Include(t => t.Client).AsQueryable();

        if (!string.IsNullOrEmpty(clientMatricule))
            query = query.Where(t => t.Client.Matricule == clientMatricule);

        if (!string.IsNullOrEmpty(operateur) && Enum.TryParse(operateur, out Operateur op))
            query = query.Where(t => t.Operateur == op);

        return View(await query.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewBag.Clients = new SelectList(_context.Clients, "Id", "Matricule");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Telephone tel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Clients = new SelectList(_context.Clients, "Id", "Matricule");
        return View(tel);
    }
}