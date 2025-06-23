﻿namespace LibraryRazorManager.LibraryModule.BookModels
{
    public class HistoricalBook : BookBase
    {
        public string Genre { get; set; }

        public override string BookInfo() => $"{Title} - {Author}; {Genre}; Year: {Publication}; Book code: {Serial}";
        public override void UpdateInfo(IBook Other)
        {
            base.UpdateInfo(Other);
            if (Other is HistoricalBook hb)
            {
                Category = BookCategory.Historical;
                Genre = hb.Genre;
            }
        }
        public override string GetShortDescription() => $"{Title} - {Author} [{Genre}]";
    }
}
