namespace SharpWiki.Tests
{
    public class SearchTests
    {
        [Theory]
        [InlineData("Jupiter", 10)]
        [InlineData("Sun", null)]
        [InlineData("Earth", 100)]
        public void CanSearchPage(string search, int? limit)
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
            if (limit.HasValue)
            {
                var searchResult = client.SearchPagesAsync(search, limit.Value).GetAwaiter().GetResult();
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.Pages);
                Assert.NotEmpty(searchResult.Pages);
            }
            else
            {
                var searchResult = client.SearchPagesAsync(search).GetAwaiter().GetResult();
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.Pages);
                Assert.NotEmpty(searchResult.Pages);
            }
        }

        [Theory]
        [InlineData("Jupiter", 10)]
        [InlineData("Sun", null)]
        [InlineData("Earth", 100)]
        public void CanSearchTitle(string search, int? limit)
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
            if (limit.HasValue)
            {
                var searchResult = client.SearchTitleAsync(search, limit.Value).GetAwaiter().GetResult();
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.Pages);
                Assert.NotEmpty(searchResult.Pages);
            }
            else
            {
                var searchResult = client.SearchTitleAsync(search).GetAwaiter().GetResult();
                Assert.NotNull(searchResult);
                Assert.NotNull(searchResult.Pages);
                Assert.NotEmpty(searchResult.Pages);
            }
            
        }
    }
}
