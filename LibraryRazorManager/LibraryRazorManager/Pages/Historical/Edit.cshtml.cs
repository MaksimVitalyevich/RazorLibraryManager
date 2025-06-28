using LibraryRazorManager.LibraryModule.BookModels;
using LibraryRazorManager.LibraryModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryRazorManager.Pages.Historical
{
    public class EditModel(AbstractBookService<HistoricalBook> manager) : BaseBookPageModel<HistoricalBook>(manager)
    {
        public override IActionResult OnGet(int year, string title)
        {
            if (year == 0 && title == "NewBook")
            {
                CurrentBook = new HistoricalBook
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

            BookCats = BookCategory.Historical;
            AvailableEra = GetAllowedEras();
            return Page();
        }
        public override IActionResult OnPostSave() => base.OnPostSave();
        public override List<SelectListItem> GetAllowedEras()
        {
            var allowedPreDigitOnly = new[] { BookEra.PreDigits };
            return [.. allowedPreDigitOnly.Select(e => new SelectListItem {
                Value = e.ToString(),
                Text = BookEraDefinitor.EraLabeler(e)
            })];
        }
    }
}
