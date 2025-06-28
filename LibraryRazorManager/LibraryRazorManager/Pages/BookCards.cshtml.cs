using LibraryRazorManager.LibraryModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryRazorManager.Pages
{
    public class BookCardsModel(IBookAggregator bookAggregator) : PageModel
    {
        private readonly IBookAggregator _bookAggregator = bookAggregator;

        [BindProperty(SupportsGet = true)]
        public BookCategory? SelectedCategory { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? AuthorQuery { get; set; }
        [BindProperty(SupportsGet = true)]
        public BookEra? SelectedEra { get; set; }
        public List<BookBase> Books { get; set; } = new();
        
        public void OnGet()
        {
             var allBooks = _bookAggregator.GetAllBooks();

            if (SelectedCategory.HasValue)
                allBooks = [.. allBooks.Where(b => b.Category == SelectedCategory.Value)];

            if (SelectedEra.HasValue)
                allBooks = [.. allBooks.Where(b => b.Era == SelectedEra.Value)];

            if (!string.IsNullOrEmpty(AuthorQuery))
                allBooks = [.. allBooks.Where(b => b.Author.Contains(AuthorQuery, StringComparison.OrdinalIgnoreCase))];

            Books = allBooks;
        }
        public IActionResult OnPostDelete(int year, string title)
        {
            var success = _bookAggregator.DeleteBook(year, title);

            if (!success)
                return RedirectToPage("/Error");

            return RedirectToPage();
        }
    }
}
