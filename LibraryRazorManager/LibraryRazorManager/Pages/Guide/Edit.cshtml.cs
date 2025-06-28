using LibraryRazorManager.LibraryModule;
using LibraryRazorManager.LibraryModule.BookModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryRazorManager.Pages.Guide
{
    public class EditModel(AbstractBookService<GuideBook> manager) : BaseBookPageModel<GuideBook>(manager)
    {
        public override IActionResult OnGet(int year, string title)
        {
            if (year == 0 && title == "NewBook")
            {
                CurrentBook = new GuideBook
                {
                    Title = string.Empty,
                    Publication = 1000
                };
            }
            else
            {
                CurrentBook = _bookService.GetBook(year, title);
                if (CurrentBook is null)
                {
                    IsNotFound = true;
                    return RedirectToPage("/Error");
                }
            }

            BookCats = BookCategory.Guide;
            AvailableEra = GetAllowedEras();
            return Page();
        }
        public override IActionResult OnPostSave() => base.OnPostSave();
        public override List<SelectListItem> GetAllowedEras()
        {
            return [.. Enum.GetValues<BookEra>().Cast<BookEra>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = BookEraDefinitor.EraLabeler(e)
            })];
        }
    }
}
