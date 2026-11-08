
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;
using Moroti_Madalina_Lab2.ViewModels;

namespace Moroti_Madalina_Lab2.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public IndexModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    public CategoryIndexData CategoryData { get; set; } = new CategoryIndexData();

    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id)
    {
        CategoryData.Categories = await _context.Category
            .Include(c => c.BookCategories)
            .ThenInclude(bc => bc.Book)
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;

            Category category = CategoryData.Categories
                .Single(c => c.ID == id.Value);

            CategoryData.Books = category.BookCategories?
                .Select(bc => bc.Book)
                .Where(b => b != null)
                .ToList() ?? new List<Book>();
        }
    }
}