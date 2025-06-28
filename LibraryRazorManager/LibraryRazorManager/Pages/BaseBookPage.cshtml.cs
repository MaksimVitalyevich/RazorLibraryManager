using LibraryRazorManager.LibraryModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryRazorManager.Pages
{
    public abstract class BaseBookPageModel<T>(AbstractBookService<T> bookService) : PageModel where T : BookBase
    {
        protected AbstractBookService<T> _bookService = bookService;
        public bool IsSuccessedResult = false;

        [BindProperty]
        public T CurrentBook { get; set; }
        public BookCategory BookCats { get; set; }
        public List<SelectListItem> AvailableEra { get; set; } = new();
        [TempData]
        public bool IsNotFound { get; set; }
        public abstract IActionResult OnGet(int year, string title);
        public virtual IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
                return Page();

            if (string.IsNullOrEmpty(CurrentBook.Title) || CurrentBook.Publication <= 0)
            {
                ModelState.AddModelError(string.Empty, "Title & Publication are required.");
                AvailableEra = GetAllowedEras();
                return Page();
            }

            var existingBook = _bookService.GetBook(CurrentBook.Publication, CurrentBook.Title);

            if (existingBook is null)
            {
                try
                {
                    var added = _bookService.AddNewBook(CurrentBook);
                    IsSuccessedResult = added is not null;
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page();
                }
            }
            else
            {
                try
                {
                    IsSuccessedResult = _bookService.UpdateBook(CurrentBook);
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page();
                }
            }

            return RedirectToPage("/BookCards");
        }
        public abstract List<SelectListItem> GetAllowedEras();
    }
}
