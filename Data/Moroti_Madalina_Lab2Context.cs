using Microsoft.EntityFrameworkCore;

public class Moroti_Madalina_Lab2Context(DbContextOptions<Moroti_Madalina_Lab2Context> options) : DbContext(options)
{
    public DbSet<Moroti_Madalina_Lab2.Models.Book> Book { get; set; } = default!;
}
