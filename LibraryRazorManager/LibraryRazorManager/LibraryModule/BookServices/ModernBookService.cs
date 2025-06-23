
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
                Id = SetAutoID(),
                Title = "Red market",
                Author = "Scott Karney",
                IsDigital = true,
                Publication = 2021,
                Serial = "EU325IP72T"
            });
            Books.Add(new()
            {
                Category = BookCategory.Modern,
                Id = SetAutoID(),
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
            book.Id = SetAutoID();

            Books.Add(book);
            return book;
        }
        public override bool UpdateBook(ModernBook book)
        {
            var changedbook = GetBook(book.Id);

            if (changedbook is not null && Books.Count != 0)
            {
                changedbook.UpdateInfo(book);
                return true;
            }

            return false;
        }
        public override bool RemoveBook(int id)
        {
            var removebook = GetBook(id);

            if (removebook is not null && Books.Count != 0)
            {
                Books.Remove(removebook);
                return true;
            }

            return false;
        }
    }
}
