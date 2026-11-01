
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Books;

public class DetailsModel : PageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public DetailsModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (book == null)
        {
            return NotFound();
        }

        Book = book;

        return Page();
    }
}
