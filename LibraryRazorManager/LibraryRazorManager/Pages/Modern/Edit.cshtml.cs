using LibraryRazorManager.LibraryModule;
using LibraryRazorManager.LibraryModule.BookModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryRazorManager.Pages.Modern
{
    public class EditModel(AbstractBookService<ModernBook> manager) : BaseBookPageModel<ModernBook>(manager)
    {
        public override IActionResult OnGet(int year, string title)
        {
            if (year == 0 && title == "NewBook")
            {
                CurrentBook = new ModernBook
                {
                    Title = string.Empty,
                    Publication = DateTime.Now.Year
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

            BookCats = BookCategory.Modern;
            AvailableEra = GetAllowedEras();
            return Page();
        }

        public override List<SelectListItem> GetAllowedEras()
        {
            var allowed = new[] { BookEra.GenZ, BookEra.PostCovid, BookEra.Nowadays };

            return [.. allowed.Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = BookEraDefinitor.EraLabeler(e)
            })];
        }

        public override IActionResult OnPostSave()
        {
            var allowedEras = GetAllowedEras().Select(e => e.Value);
            if (!allowedEras.Contains(CurrentBook.Era.ToString()))
            {
                ModelState.AddModelError(nameof(CurrentBook.Era), "Chosen era is NOT allowed for Modern categiry books.");
                AvailableEra = GetAllowedEras();
                return Page();
            }

            return base.OnPostSave();
        }
    }
}
