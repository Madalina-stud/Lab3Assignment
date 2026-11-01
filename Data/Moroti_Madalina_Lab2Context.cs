
using Microsoft.EntityFrameworkCore;
using Moroti_Madalina_Lab2.Models;

public class Moroti_Madalina_Lab2Context(DbContextOptions<Moroti_Madalina_Lab2Context> options) : DbContext(options)
{
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<BookCategory> BookCategory { get; set; } = default!;
}
