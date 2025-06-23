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
                Id = SetAutoID(),
                Title = "Crime & Punishment",
                Author = "Fedor Dostoevskyu",
                Genre = "Philosophical novel",
                Publication = 1866,
                Serial = "PZ442ST81I"
            });
            Books.Add(new()
            {
                Category = BookCategory.Historical,
                Id = SetAutoID(),
                Title = "A word to Igorev squad",
                Genre = "Ancient russian poem",
                Publication = 1185,
                Serial = "YS113FG6HK"
            });
        }
        public override List<HistoricalBook> GetBooks() => base.GetBooks();
        public override HistoricalBook AddNewBook(HistoricalBook book)
        {
            book.Category = BookCategory.Historical;
            book.Id = SetAutoID();

            Books.Add(book);
            return book;
        }
        public override bool UpdateBook(HistoricalBook book)
        {
            var changedbook = GetBook(book.Id);

            if (changedbook is not null && Books.Count == 0)
            {
                changedbook.UpdateInfo(book);
                return true;
            }

            return false;
        }
        public override bool RemoveBook(int id)
        {
            var removedbook = GetBook(id);

            if (removedbook is not null && Books.Count == 0)
            {
                Books.Remove(removedbook);
                return true;
            }

            return false;
        }
    }
}
