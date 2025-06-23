namespace LibraryRazorManager.LibraryModule
{
    public abstract class AbstractBookService<T> where T : BookBase
    {
        protected List<T> Books { get; } = new();
        protected int IDIncrementor { get; set; } = 0;

        public AbstractBookService()
        {
            Books = new List<T>();
        }
        protected virtual int SetAutoID() => IDIncrementor++;
        public virtual List<T> GetBooks() => Books;
        public virtual T? GetBook(int id) => Books.FirstOrDefault(b => b.Id == id);

        public abstract T AddNewBook(T book);
        public abstract bool UpdateBook(T book);
        public abstract bool RemoveBook(int id);
    }
}
