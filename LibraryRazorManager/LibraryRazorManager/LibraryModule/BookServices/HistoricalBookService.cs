using LibraryRazorManager.LibraryModule.BookModels;

namespace LibraryRazorManager.LibraryModule.BookServices
{
    public class HistoricalBookService : AbstractBookService<HistoricalBook>
    {
        public HistoricalBookService()
        {
            GetExistingHistoricalBooks();
        }

        private void GetExistingHistoricalBooks()
        {
            Books.Add(new()
            {
                Category = BookCategory.Historical,
                Era = BookEra.PreDigits,
                Title = "Crime & Punishment",
                Author = "Fedor Dostoevskyu",
                Genre = "Philosophical novel",
                Publication = 1866,
                Serial = "PZ442ST81I"
            });
            Books.Add(new()
            {
                Category = BookCategory.Historical,
                Era = BookEra.PreDigits,
                Title = "A word to Igorev squad",
                Genre = "Ancient russian poem",
                Publication = 1185,
                Serial = "YS113FG6HK"
            });
        }
        private bool IsRareBook(HistoricalBook book)
        {
            var era = BookEraDefinitor.MatchEra(book.Publication);
            return book.Category == BookCategory.Historical && era == BookEra.PreDigits;
        }
        public override List<HistoricalBook> GetBooks() => base.GetBooks();
        public override HistoricalBook AddNewBook(HistoricalBook book)
        {
            book.Category = BookCategory.Historical;
            var era = BookEraDefinitor.MatchEra(book.Publication);
            if (!BookEraDefinitor.IsCategoryAllowed(book.Category, era))
                throw new InvalidOperationException("Cannot add book of this chosen period.");

            if (GetBook(book.Publication, book.Title) is not null)
                throw new InvalidOperationException("Book with such title & publication already exists.");

            Books.Add(book);
            return book;
        }
        public override bool UpdateBook(HistoricalBook book)
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
            var removedbook = GetBook(year, title);

            if (removedbook is not null)
            {
                if (IsRareBook(removedbook))
                {
                    throw new InvalidOperationException($"Warning! This is RARE sample, saved in {removedbook.Publication} year! " +
                        "Considered as priceless exponate. Seriously wish to delete? This action cannot be revoked!");
                }

                Books.Remove(removedbook);
                return true;
            }

            return false;
        }
    }
}
