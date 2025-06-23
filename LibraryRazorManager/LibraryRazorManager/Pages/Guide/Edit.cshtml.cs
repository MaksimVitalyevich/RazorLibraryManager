using LibraryRazorManager.LibraryModule;
using LibraryRazorManager.LibraryModule.BookModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRazorManager.Pages.Guide
{
    public class EditModel(AbstractBookService<GuideBook> manager) : BaseBookPageModel<GuideBook>(manager)
    {
        public override IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                CurrentBook = new GuideBook();
            }
            else
            {
                CurrentBook = _bookService.GetBook(id.Value);
                if (CurrentBook == null)
                    return NotFound();
            }

            BookCats = BookCategory.Guide;
            return Page();
        }
        public override IActionResult OnPostSave() => base.OnPostSave();
    }
}
