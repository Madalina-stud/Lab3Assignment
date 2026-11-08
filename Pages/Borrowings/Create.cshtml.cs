
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Borrowings;

public class CreateModel : PageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public CreateModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        await PopulateDropDownLists();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropDownLists();
            return Page();
        }

        _context.Borrowing.Add(Borrowing);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private async Task PopulateDropDownLists()
    {
        ViewData["MemberID"] = new SelectList(
            await _context.Member.ToListAsync(),
            "ID",
            "FullName"
        );

        ViewData["BookID"] = new SelectList(
            await _context.Book
                .Select(b => new
                {
                    b.ID,
                    BookFullName = b.Title + " - " + b.Author
                })
                .ToListAsync(),
            "ID",
            "BookFullName"
        );
    }
}

