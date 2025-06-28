namespace LibraryRazorManager.LibraryModule
{
    public enum BookCategory { Historical, Guide, Modern }
    public enum BookEra { PreDigits, Early2000s, From2000To2010, GenZ, PostCovid, Nowadays}
    public interface IBook
    {
        BookCategory Category { get; set; }
        BookEra Era { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        int Publication { get; set; }
        string Serial { get; set; }
    }
    public abstract class BookBase : IBook 
    {
        public string Title { get; set; }
        public string Author { get; set; } = "Unknown";
        public int Publication { get; set; }
        public string Serial { get; set; }
        public BookEra Era { get; set; }
        public BookCategory Category { get; set; }

        public virtual string BookInfo() => $"{Title} - {Author}; Year: {Publication}; Book code: {Serial}";
        public virtual void UpdateInfo(IBook Other)
        {
            Title = Other.Title;
            Author = Other.Author;
            Publication = Other.Publication;
            Serial = Other.Serial;
        }
        public virtual string GetShortDescription() => $"{Title} - {Author} ({Publication})";
    }
}
