using LibraryRazorManager.LibraryModule;
using LibraryRazorManager.LibraryModule.BookModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRazorManager.Pages.Modern
{
    public class EditModel(AbstractBookService<ModernBook> manager) : BaseBookPageModel<ModernBook>(manager)
    {
        public override IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                CurrentBook = new ModernBook();
            }
            else
            {
                CurrentBook = _bookService.GetBook(id.Value);
                if (CurrentBook == null)
                    return NotFound();
            }

            BookCats = BookCategory.Modern;
            return Page();
        }

        public override IActionResult OnPostSave() => base.OnPostSave();
    }
}
