namespace LibraryRazorManager.LibraryModule
{
    public static class BookEraDefinitor
    {
        public static BookEra MatchEra(int year)
        {
            return year switch
            {
                <= 1999 => BookEra.PreDigits,
                2000 => BookEra.Early2000s,
                >= 2001 and <= 2010 => BookEra.From2000To2010,
                >= 2011 and <= 2019 => BookEra.GenZ,
                >= 2020 and <= 2023 => BookEra.PostCovid,
                _ => BookEra.Nowadays
            };
        }
        public static bool IsCategoryAllowed(BookCategory category, BookEra era)
        {
            return category switch
            {
                BookCategory.Historical => era == BookEra.PreDigits,
                BookCategory.Guide => era != BookEra.PreDigits,
                BookCategory.Modern => era is BookEra.GenZ or BookEra.PostCovid or BookEra.Nowadays,
                _ => false
            };
        }
        public static string EraLabeler(BookEra era) => era switch 
        { 
            BookEra.PreDigits => "PreDigital Era",
            BookEra.Early2000s => "Early 2000s",
            BookEra.From2000To2010 => "2000-2010",
            BookEra.GenZ => "Generation Z",
            BookEra.PostCovid => "Post-COVID Time",
            BookEra.Nowadays => "Modern times",
            _ => "Unknown Era"
        };
    }
}
