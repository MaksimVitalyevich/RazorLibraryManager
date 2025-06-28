using LibraryRazorManager.LibraryModule.BookModels;

namespace LibraryRazorManager.LibraryModule.BookServices
{
    public class GuideBookService : AbstractBookService<GuideBook>
    {
        public GuideBookService()
        {
            GetExistingGuideBooks();
        }

        private void GetExistingGuideBooks()
        {
            Books.Add(new()
            {
                Category = BookCategory.Guide,
                Era = BookEra.GenZ,
                Title = "Guide to create games on C++",
                Author = "Michael Doyson",
                PhoneData = 84992707359,
                Publication = 2016,
                Serial = "SP128HXU09"
            });
            Books.Add(new()
            {
                Category = BookCategory.Guide,
                Era = BookEra.GenZ,
                Title = "1C Guide",
                PhoneData = 84957379257,
                Publication = 2011,
                Serial = "S11OI62JIK"
            });
        }
        public override List<GuideBook> GetBooks() => base.GetBooks();
        public override GuideBook AddNewBook(GuideBook book)
        {
            book.Category = BookCategory.Guide;
            var era = BookEraDefinitor.MatchEra(book.Publication);
            if (!BookEraDefinitor.IsCategoryAllowed(book.Category, era))
                throw new InvalidOperationException("Cannot add book of this chosen period.");

            if (GetBook(book.Publication, book.Title) is not null)
                throw new InvalidOperationException("Book with such title & publication already exists.");

            Books.Add(book);
            return book;
        }
        public override bool UpdateBook(GuideBook book)
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
                Books.Remove(removedbook);
                return true;
            }

            return false;
        }
    }
}
