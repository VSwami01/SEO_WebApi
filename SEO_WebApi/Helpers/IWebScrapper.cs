namespace SEO_WebApi.Helpers
{
    public interface IWebScrapper
    {
        string GetHTMLText(string url);
    }
}
