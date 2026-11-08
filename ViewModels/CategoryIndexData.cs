
using Moroti_Madalina_Lab2.Models;

namespace Moroti_Madalina_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
