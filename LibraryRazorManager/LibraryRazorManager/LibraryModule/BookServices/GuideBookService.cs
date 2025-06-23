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
                Id = SetAutoID(),
                Title = "Guide to create games on C++",
                Author = "Michael Doyson",
                PhoneData = 84992707359,
                Publication = 2016,
                Serial = "SP128HXU09"
            });
            Books.Add(new()
            {
                Category = BookCategory.Guide,
                Id = SetAutoID(),
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
            book.Id = SetAutoID();

            Books.Add(book);
            return book;
        }
        public override bool UpdateBook(GuideBook book)
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
