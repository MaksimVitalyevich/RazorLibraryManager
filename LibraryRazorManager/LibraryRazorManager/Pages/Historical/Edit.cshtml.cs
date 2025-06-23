using LibraryRazorManager.LibraryModule.BookModels;
using LibraryRazorManager.LibraryModule;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRazorManager.Pages.Historical
{
    public class EditModel(AbstractBookService<HistoricalBook> manager) : BaseBookPageModel<HistoricalBook>(manager)
    {
        public override IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                CurrentBook = new HistoricalBook();
            }
            else
            {
                CurrentBook = _bookService.GetBook(id.Value);
                if (CurrentBook == null)
                    return NotFound();
            }

            BookCats = BookCategory.Historical;
            return Page();
        }
        public override IActionResult OnPostSave() => base.OnPostSave();
    }
}
