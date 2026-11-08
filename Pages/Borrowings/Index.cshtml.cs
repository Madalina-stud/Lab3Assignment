
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Borrowings;

public class IndexModel : PageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public IndexModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Borrowing = await _context.Borrowing
            .Include(b => b.Member)
            .Include(b => b.Book)
            .ToListAsync();
    }
}

