using LibraryRazorManager.LibraryModule.BookModels;

namespace LibraryRazorManager.LibraryModule
{
    public interface IBookAggregator
    {
        List<BookBase> GetAllBooks();
        bool DeleteBook(int year, string title);
    }
    public class BookAggregatorService(AbstractBookService<HistoricalBook> historicalService, 
        AbstractBookService<GuideBook> guideService, 
        AbstractBookService<ModernBook> novelService) : IBookAggregator
    {
        private readonly AbstractBookService<HistoricalBook> _historicalService = historicalService;
        private readonly AbstractBookService<GuideBook> _guideService = guideService;
        private readonly AbstractBookService<ModernBook> _novelService = novelService;

        public List<BookBase> GetAllBooks()
        {
            var books = new List<BookBase>();
            books.AddRange(_historicalService.GetBooks());
            books.AddRange(_guideService.GetBooks());
            books.AddRange(_novelService.GetBooks());

            return books;
        }
        public bool DeleteBook(int year, string title)
        {
            if (_historicalService.RemoveBook(year, title)) return true;
            if (_guideService.RemoveBook(year, title)) return true;
            if (_novelService.RemoveBook(year, title)) return true;

            return false;
        }
    }
}
