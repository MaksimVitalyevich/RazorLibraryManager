namespace LibraryRazorManager.LibraryModule
{
    public abstract class AbstractBookService<T> where T : BookBase
    {
        protected List<T> Books { get; } = new();

        public AbstractBookService()
        {
            Books = new List<T>();
        }
        public virtual List<T> GetBooks() => Books;
        public virtual T? GetBook(int year, string title) => Books.FirstOrDefault(p => p.Publication == year && p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        public virtual List<T> GetBooksByPeriod(BookEra period) =>
            [.. Books.Where(b => BookEraDefinitor.MatchEra(b.Publication) == period)];

        public abstract T AddNewBook(T book);
        public abstract bool UpdateBook(T book);
        public abstract bool RemoveBook(int year, string title);
    }
}
