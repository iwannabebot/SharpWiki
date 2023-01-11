namespace SharpWiki.Tests
{
    public class ClientTests
    {
        [Theory]
        [InlineData(Models.WikiLanguage.English)]
        [InlineData(Models.WikiLanguage.Hindi)]
        [InlineData(Models.WikiLanguage.Chinese)]
        [InlineData(Models.WikiLanguage.Greek)]
        [InlineData(Models.WikiLanguage.Gothic)]
        [InlineData(Models.WikiLanguage.Hebrew)]
        [InlineData(Models.WikiLanguage.Cree)]
        [InlineData(Models.WikiLanguage.Santali)]
        [InlineData(Models.WikiLanguage.Sanskrit)]
        [InlineData(Models.WikiLanguage.Tamil)]
        public void CanCreateEndpoints(Models.WikiLanguage language)
        {
            using SharpWikiClient client= new SharpWikiClient(new SharpWikiClientOptions
            {
                ApiUserAgent = "SharpWiki.Tests",
                Language = language,
                GetToken = () =>
                {
                    return "";
                }
            });
            client.GetEndpoint();
        }
    }
}