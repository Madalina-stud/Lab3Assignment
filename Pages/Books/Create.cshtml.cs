
using Microsoft.AspNetCore.Mvc;
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.Pages.Books;

public class CreateModel : BookCategoriesPageModel
{
    private readonly Moroti_Madalina_Lab2Context _context;

    public CreateModel(Moroti_Madalina_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        Book = new Book();
        Book.BookCategories = new List<BookCategory>();

        PopulateAssignedCategoryData(_context, Book);

        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        var newBook = new Book();

        if (await TryUpdateModelAsync<Book>(
            newBook,
            "Book",
            b => b.Title,
            b => b.Author,
            b => b.Price,
            b => b.PublishingDate))
        {
            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();

            UpdateBookCategories(_context, selectedCategories, newBook);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        PopulateAssignedCategoryData(_context, newBook);

        return Page();
    }
}

