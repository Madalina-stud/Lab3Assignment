using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public IndexModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
