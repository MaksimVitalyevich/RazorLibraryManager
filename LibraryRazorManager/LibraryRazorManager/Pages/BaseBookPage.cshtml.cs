using LibraryRazorManager.LibraryModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryRazorManager.Pages
{
    public abstract class BaseBookPageModel<T>(AbstractBookService<T> bookService) : PageModel where T : BookBase
    {
        protected AbstractBookService<T> _bookService = bookService;
        public bool IsSuccessedResult = false;

        [BindProperty]
        public T CurrentBook { get; set; }
        public BookCategory BookCats { get; set; }
        public abstract IActionResult OnGet(int? id);
        public virtual IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
                return Page();

            if (CurrentBook.Id == 0)
            {
                IsSuccessedResult = (_bookService.AddNewBook(CurrentBook)).Id != 0;
            }
            else
            {
                IsSuccessedResult = _bookService.UpdateBook(CurrentBook);
            }

            return RedirectToPage("/BookCards");
        }
    }
}
