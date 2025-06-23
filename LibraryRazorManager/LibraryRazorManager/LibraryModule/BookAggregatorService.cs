using LibraryRazorManager.LibraryModule.BookModels;

namespace LibraryRazorManager.LibraryModule
{
    public interface IBookAggregator
    {
        List<BookBase> GetAllBooks();
        bool DeleteBook(int id);
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
        public bool DeleteBook(int id)
        {
            if (_historicalService.RemoveBook(id)) return true;
            if (_guideService.RemoveBook(id)) return true;
            if (_novelService.RemoveBook(id)) return true;

            return false;
        }
    }
}
