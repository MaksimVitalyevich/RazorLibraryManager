using Microsoft.AspNetCore.Mvc;

namespace LibraryRazorManager.LibraryModule.BookModels
{
    public class GuideBook : BookBase
    {
        public long PhoneData { get; set; }

        private string FormatPhoneNumber(long phone) => phone == 0 ? "" : phone.ToString();

        public override string BookInfo() => $"{Title} - {Author}; Phone number: {FormatPhoneNumber(PhoneData)}; Year: {Publication}; Book code: {Serial}";
        public override void UpdateInfo(IBook Other)
        {
            base.UpdateInfo(Other);
            if (Other is GuideBook gb)
            {
                Category = BookCategory.Guide;
                PhoneData = gb.PhoneData;
            }
        }
        public override string GetShortDescription() => $"{Title} - {Author} ({FormatPhoneNumber(PhoneData)})";
    }
}
