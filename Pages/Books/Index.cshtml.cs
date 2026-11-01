
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Books;

public class IndexModel : PageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public IndexModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    public BookData BookData { get; set; } = default!;

    public async Task OnGetAsync()
    {
        BookData = new BookData
        {
            Books = await _context.Book
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .ToListAsync()
        };
    }
}
