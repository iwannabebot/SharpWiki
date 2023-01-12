# SharpWiki - A tiny C# client for Wikipedia

#### Install from Nuget

```pwsh
Install-Package SharpWiki
```

### Status

![CI](https://github.com/iwannabebot/sharpwiki/actions/workflows/dotnet.yml/badge.svg)
![CodeQL](https://github.com/iwannabebot/sharpwiki/actions/workflows/codeql.yml/badge.svg)
![Nuget](https://github.com/iwannabebot/sharpwiki/actions/workflows/nuget.yml/badge.svg)


### Supported APIs
|Support|Resource|Operation|
|-------|--------|----------|
|✅|Search|Page|
|✅|Search|Title|
|✅|Page|Create|
|✅|Page|Update|
|✅|Page|Get|
|✅|Page|Get Offline|
|✅|Page|Get Source|
|✅|Page|Get HTML|
|✅|Page|Get Languages|
|✅|Page|Get Files|
|✅|Media|Get|
|❌|History|Get Page History|
|❌|History|Get Page History Counts|
|❌|History|Get Revision|
|❌|History|Compare Revisions|

#### Quick Start

```cs
// Initialize SharpWikiClient
SharpWikiClient client= new SharpWikiClient(new SharpWikiClientOptions
{
    ApiUserAgent = "SharpWiki.Tests", // Write name of you app
    Language = WikiLanguage.English, // Choose wikipedia language
    GetToken = () =>
    {
        // Get Mediawiki token (required to create or update page only)
        // For more details, refer: https://www.mediawiki.org/wiki/Extension:OAuth
        return "";
    }
});

// Search page
// This will search entire wikipedia page
WikiSearch searchPages = await client.SearchPagesAsync("Jupiter", 5);
foreach(WikiSearchPage page in searchPages.Pages)
{
    Console.WriteLine($"{page.Id}");
    Console.WriteLine($"{page.Title}");
    Console.WriteLine($"{page.Description}");
    Console.WriteLine($"{page.Thumbnail.Url}");
}

// Search title
// This will search wikipedia titles only
// A good use case is to use this for autocomplete
WikiSearch searchTitles = await client.SearchTitleAsync("Jupiter", 5);
foreach (WikiSearchPage page in searchTitles.Pages)
{
    Console.WriteLine($"{page.Id}");
    Console.WriteLine($"{page.Title}");
}

// Get a wiki page by title
WikiPage page= await client.GetPageAsync("Jupiter");
Console.WriteLine($"{page.Id}");
Console.WriteLine($"{page.Title}");
Console.WriteLine($"{page.HtmlUrl}");

// Get a wiki page by title with html
WikiPage offlinePage = await client.GetPageOfflineAsync("Jupiter");
Console.WriteLine($"{offlinePage.Id}");
Console.WriteLine($"{offlinePage.Title}");
Console.WriteLine($"{offlinePage.Html}");

// Get a wiki page by title with original source
// Read more about source types from https://www.mediawiki.org/wiki/Content_handlers
WikiPage sourcePage = await client.GetPageSourceAsync("Jupiter");
Console.WriteLine($"{offlinePage.Id}");
Console.WriteLine($"{offlinePage.Title}");
Console.WriteLine($"{offlinePage.Source}");

// Get a wiki page by title as HTML
string wikiPageHtml = await client.GetPageHtmlAsync("Jupiter");
Console.WriteLine($"{wikiPageHtml}");

// Get list of languages in which this title is also present
IEnumerable<WikiPageLanguage> pageLanguages = await client.GetPageLanguagesAsync("Jupiter");
foreach(WikiPageLanguage pageLanguage in pageLanguages)
{
    Console.WriteLine($"{pageLanguage.Name}");
    Console.WriteLine($"{pageLanguage.Code}");
    Console.WriteLine($"{pageLanguage.Title}");
    Console.WriteLine($"{pageLanguage.Key}");
}

// Get list of files present on a wiki page
IEnumerable<WikiFile> filesOnPage = await client.GetFilesOnPageAsync("Jupiter");
foreach (WikiFile fileOnPage in filesOnPage)
{
    Console.WriteLine($"{fileOnPage.Title}");
    Console.WriteLine($"{fileOnPage.Original.Url}");
}

// Create a wiki page
WikiPageRequestCreate createWikiModel = new WikiPageRequestCreate
{
    Title = "My Wiki Page",
    Comment = "This is a test page",
    // core types :wikitext, text, json, javascript, css
    // For more types refer https://www.mediawiki.org/wiki/Content_handlers
    ContentModel = "text",
    Source = "This is test wiki page content"
};

WikiPage createdPage = await client.CreatePageAsync(createWikiModel);

// Update a wiki page
WikiPageRequestUpdate updateWikiModel = new WikiPageRequestUpdate
{
    Comment = "This is a test page",
    // core types :wikitext, text, json, javascript, css
    // For more types refer https://www.mediawiki.org/wiki/Content_handlers
    ContentModel = "text",
    Source = "This is updated wiki page content",
    Latest = new WikiPageRevision
    {
        Id = 100
    }
};

WikiPage updatedPage = await client.UpdatePageAsync("My Wiki Page", updateWikiModel);

// Get a file by name
WikiFile file = await client.GetFileAsync("filename");
```
