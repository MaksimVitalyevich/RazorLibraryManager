
using LibraryRazorManager.LibraryModule.BookModels;

namespace LibraryRazorManager.LibraryModule.BookServices
{
    public class ModernBookService : AbstractBookService<ModernBook>
    {
        public ModernBookService() 
        {
            GetExistingNovelBooks();
        }

        private void GetExistingNovelBooks()
        {
            Books.Add(new()
            {
                Category = BookCategory.Modern,
                Era = BookEra.PostCovid,
                Title = "Red market",
                Author = "Scott Karney",
                IsDigital = true,
                Publication = 2021,
                Serial = "EU325IP72T"
            });
            Books.Add(new()
            {
                Category = BookCategory.Modern,
                Era = BookEra.Nowadays,
                Title = "Tuma",
                Author = "Zachar Prilepin",
                IsDigital = true,
                Publication = 2025,
                Serial = "OK317HUK36"
            });
        }
        public override List<ModernBook> GetBooks() => base.GetBooks();
        public override ModernBook AddNewBook(ModernBook book)
        {
            book.Category = BookCategory.Modern;
            var era = BookEraDefinitor.MatchEra(book.Publication);
            if (!BookEraDefinitor.IsCategoryAllowed(book.Category, era))
                throw new InvalidOperationException("Cannot add book of this chosen period.");

            if (GetBook(book.Publication, book.Title) is not null)
                throw new InvalidOperationException("Book with such title & publication already exists.");

            Books.Add(book);
            return book;
        }
        public override bool UpdateBook(ModernBook book)
        {
            var era = BookEraDefinitor.MatchEra(book.Publication);
            if (!BookEraDefinitor.IsCategoryAllowed(book.Category, era))
                throw new InvalidOperationException("Cannot change book of this selected period.");

            var changedbook = GetBook(book.Publication, book.Title);

            if (changedbook is not null)
            {
                changedbook.UpdateInfo(book);
                return true;
            }

            return false;
        }
        public override bool RemoveBook(int year, string title)
        {
            var removebook = GetBook(year, title);

            if (removebook is not null)
            {
                Books.Remove(removebook);
                return true;
            }

            return false;
        }
    }
}
