
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Books;

public class EditModel : BookCategoriesPageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public EditModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Book = await _context.Book
            .Include(b => b.BookCategories)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (Book == null)
        {
            return NotFound();
        }

        PopulateAssignedCategoryData(_context, Book);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        var bookToUpdate = await _context.Book
            .Include(b => b.BookCategories)
            .FirstOrDefaultAsync(b => b.ID == Book.ID);

        if (bookToUpdate == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            bookToUpdate.Title = Book.Title;
            bookToUpdate.Author = Book.Author;
            bookToUpdate.Price = Book.Price;
            bookToUpdate.PublishingDate = Book.PublishingDate;

            UpdateBookCategories(_context, selectedCategories, bookToUpdate);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        PopulateAssignedCategoryData(_context, bookToUpdate);

        return Page();
    }
}
