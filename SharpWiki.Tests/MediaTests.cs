namespace SharpWiki.Tests
{
    public class MediaTests
    {
        [Theory]
        [InlineData("Jupiter")]
        public void CanGetFilesOnPage(string pageName)
        {
            using SharpWikiClient client = new SharpWikiClient(new SharpWikiClientOptions
            {
                ApiUserAgent = "SharpWiki.Tests",
                Language = Models.WikiLanguage.English,
                GetToken = () =>
                {
                    return "";
                }
            });
            var files = client.GetFilesOnPageAsync(pageName).GetAwaiter().GetResult();
        }
    }
}