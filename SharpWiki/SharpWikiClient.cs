namespace SharpWiki
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Net.Mime;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using SharpWiki.Exceptions;
    using SharpWiki.Exceptions.Guards;
    using SharpWiki.Models;

    /// <summary>
    /// SharpWiki Client Object
    /// </summary>
    public class SharpWikiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly SharpWikiClientOptions _options;

        /// <summary>
        /// Initialize a SharpWiki Client
        /// </summary>
        /// <param name="options">SharpWiki Client Option</param>
        /// <param name="httpClientFactory"></param>
        /// <exception cref="WikiTokenNotFoundException"></exception>
        public SharpWikiClient(SharpWikiClientOptions? options = null, IHttpClientFactory? httpClientFactory = null)
        {
            _options = options ?? SharpWikiClientOptions.Default;
            if (httpClientFactory == null)
            {
                _httpClient = new HttpClient();
            }
            else
            {
                _httpClient = httpClientFactory.CreateClient("SharpWikiClient");
            }
            _httpClient.DefaultRequestHeaders.Add("Api-User-Agent", _options.ApiUserAgent);
        }

        /// <summary>
        /// Get wikipedia endpoint from language. Default to en.wikipedia.org
        /// </summary>
        /// <returns>Wikipedia endpoint</returns>
        public Uri GetEndpoint()
        {
            return new Uri(@$"https://{GetLanguage(_options?.Language)}.wikipedia.org/w/rest.php/v1");
        }

        /// <summary>
        /// Get language symbol
        /// </summary>
        /// <param name="language">WikiLanguage</param>
        /// <returns>language symbol</returns>
        private string GetLanguage(WikiLanguage? language)
        {
            return (int)(language??WikiLanguage.English) switch
            {
                1 => "en",
                2 => "ceb",
                3 => "de",
                4 => "sv",
                5 => "fr",
                6 => "nl",
                7 => "ru",
                8 => "es",
                9 => "it",
                10 => "arz",
                11 => "pl",
                12 => "ja",
                13 => "zh",
                14 => "vi",
                15 => "war",
                16 => "uk",
                17 => "ar",
                18 => "pt",
                19 => "fa",
                20 => "ca",
                21 => "sr",
                22 => "id",
                23 => "ko",
                24 => "no",
                25 => "fi",
                26 => "tr",
                27 => "hu",
                28 => "cs",
                29 => "ce",
                30 => "tt",
                31 => "sh",
                32 => "ro",
                33 => "zh-min-nan",
                34 => "eu",
                35 => "ms",
                36 => "eo",
                37 => "he",
                38 => "hy",
                39 => "da",
                40 => "bg",
                41 => "cy",
                42 => "sk",
                43 => "azb",
                44 => "et",
                45 => "kk",
                46 => "be",
                47 => "min",
                48 => "simple",
                49 => "uz",
                50 => "el",
                51 => "hr",
                52 => "lt",
                53 => "gl",
                54 => "az",
                55 => "ur",
                56 => "sl",
                57 => "ka",
                58 => "nn",
                59 => "hi",
                60 => "th",
                61 => "ta",
                62 => "la",
                63 => "bn",
                64 => "mk",
                65 => "ast",
                66 => "zh-yue",
                67 => "lv",
                68 => "tg",
                69 => "af",
                70 => "my",
                71 => "mg",
                72 => "bs",
                73 => "mr",
                74 => "oc",
                75 => "sq",
                76 => "nds",
                77 => "ml",
                78 => "ky",
                79 => "be-tarask",
                80 => "te",
                81 => "br",
                82 => "sw",
                83 => "new",
                84 => "jv",
                85 => "lld",
                86 => "vec",
                87 => "ht",
                88 => "pnb",
                89 => "pms",
                90 => "ba",
                91 => "lb",
                92 => "su",
                93 => "ku",
                94 => "ga",
                95 => "lmo",
                96 => "szl",
                97 => "is",
                98 => "cv",
                99 => "fy",
                100 => "ckb",
                101 => "tl",
                102 => "an",
                103 => "wuu",
                104 => "diq",
                105 => "sco",
                106 => "pa",
                107 => "io",
                108 => "vo",
                109 => "yo",
                110 => "ne",
                111 => "gu",
                112 => "als",
                113 => "kn",
                114 => "ia",
                115 => "bar",
                116 => "scn",
                117 => "avk",
                118 => "bpy",
                119 => "qu",
                120 => "crh",
                121 => "mn",
                122 => "nv",
                123 => "ha",
                124 => "xmf",
                125 => "si",
                126 => "ban",
                127 => "bat-smg",
                128 => "ps",
                129 => "os",
                130 => "frr",
                131 => "or",
                132 => "sah",
                133 => "gd",
                134 => "bug",
                135 => "cdo",
                136 => "yi",
                137 => "ilo",
                138 => "sd",
                139 => "am",
                140 => "nap",
                141 => "li",
                142 => "fo",
                143 => "hsb",
                144 => "gor",
                145 => "map-bms",
                146 => "mai",
                147 => "mzn",
                148 => "ig",
                149 => "bcl",
                150 => "eml",
                151 => "ace",
                152 => "shn",
                153 => "zh-classical",
                154 => "sa",
                155 => "wa",
                156 => "ie",
                157 => "lij",
                158 => "as",
                159 => "zu",
                160 => "mhr",
                161 => "mrj",
                162 => "hyw",
                163 => "hif",
                164 => "bjn",
                165 => "mni",
                166 => "sn",
                167 => "hak",
                168 => "km",
                169 => "roa-tara",
                170 => "so",
                171 => "pam",
                172 => "rue",
                173 => "nso",
                174 => "bh",
                175 => "tum",
                176 => "se",
                177 => "mi",
                178 => "sat",
                179 => "myv",
                180 => "vls",
                181 => "nds-nl",
                182 => "nah",
                183 => "sc",
                184 => "vep",
                185 => "kw",
                186 => "kab",
                187 => "tk",
                188 => "gan",
                189 => "co",
                190 => "glk",
                191 => "dag",
                192 => "fiu-vro",
                193 => "ary",
                194 => "bo",
                195 => "ab",
                196 => "gv",
                197 => "frp",
                198 => "zea",
                199 => "skr",
                200 => "ug",
                201 => "kv",
                202 => "pcd",
                203 => "udm",
                204 => "csb",
                205 => "mt",
                206 => "ay",
                207 => "gn",
                208 => "smn",
                209 => "nrm",
                210 => "lez",
                211 => "lfn",
                212 => "stq",
                213 => "olo",
                214 => "lo",
                215 => "rw",
                216 => "mwl",
                217 => "ang",
                218 => "fur",
                219 => "rm",
                220 => "lad",
                221 => "gom",
                222 => "koi",
                223 => "ext",
                224 => "tyv",
                225 => "dsb",
                226 => "av",
                227 => "dty",
                228 => "ln",
                229 => "cbk-zam",
                230 => "pap",
                231 => "kaa",
                232 => "dv",
                233 => "ksh",
                234 => "gag",
                235 => "bxr",
                236 => "pfl",
                237 => "ks",
                238 => "pag",
                239 => "pi",
                240 => "szy",
                241 => "haw",
                242 => "mdf",
                243 => "awa",
                244 => "tay",
                245 => "tw",
                246 => "za",
                247 => "blk",
                248 => "inh",
                249 => "krc",
                250 => "xal",
                251 => "pdc",
                252 => "atj",
                253 => "to",
                254 => "arc",
                255 => "tcy",
                256 => "lg",
                257 => "mnw",
                258 => "kbp",
                259 => "jam",
                260 => "na",
                261 => "wo",
                262 => "kbd",
                263 => "nia",
                264 => "nov",
                265 => "ki",
                266 => "bi",
                267 => "nqo",
                268 => "tpi",
                269 => "tet",
                270 => "shi",
                271 => "jbo",
                272 => "roa-rup",
                273 => "fj",
                274 => "lbe",
                275 => "kg",
                276 => "xh",
                277 => "ty",
                278 => "cu",
                279 => "om",
                280 => "guw",
                281 => "trv",
                282 => "srn",
                283 => "sm",
                284 => "gcr",
                285 => "alt",
                286 => "chr",
                287 => "ltg",
                288 => "tn",
                289 => "ny",
                290 => "st",
                291 => "pih",
                292 => "mad",
                293 => "got",
                294 => "ami",
                295 => "rmy",
                296 => "bm",
                297 => "ve",
                298 => "ts",
                299 => "ff",
                300 => "chy",
                301 => "ss",
                302 => "rn",
                303 => "kcg",
                304 => "ak",
                305 => "iu",
                306 => "ch",
                307 => "ee",
                308 => "pnt",
                309 => "ik",
                310 => "ady",
                311 => "pcm",
                312 => "sg",
                313 => "pwn",
                314 => "din",
                315 => "ti",
                316 => "kl",
                317 => "dz",
                318 => "cr",
                _ => "",
            };
        }

        /// <summary>
        /// Dispose client
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <summary>
        /// Searches wiki page titles and contents for the provided search terms, and returns matching pages.
        /// </summary>
        /// <param name="query">Search terms</param>
        /// <param name="limit">Maximum number of search results to return, between 1 and 100. Default: 50</param>
        /// <returns>pages object containing array of search results</returns>
        public async Task<WikiSearch?> SearchPagesAsync(string query, int limit = 50)
        {
            Guard.Against.SearchLimit(limit);
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/search/page?q={query}&limit={limit}");
            Guard.Against.SearchErrors(response);
            var x = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadFromJsonAsync<WikiSearch>();
        }

        /// <summary>
        /// Searches wiki page titles, and returns matches between the beginning of a title and the provided search terms.
        /// </summary>
        /// <param name="query">Search terms</param>
        /// <param name="limit">Maximum number of search results to return, between 1 and 100. Default: 50</param>
        /// <returns>pages object containing array of search results</returns>
        public async Task<WikiSearch?> SearchTitleAsync(string query, int limit = 50)
        {
            Guard.Against.SearchLimit(limit);
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/search/title?q={query}&limit={limit}");
            Guard.Against.SearchErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiSearch>();
        }

        /// <summary>
        /// Creates a wiki page
        /// </summary>
        /// <param name="createPageRequest"></param>
        /// <returns>Page object with source property</returns>
        public async Task<WikiPage?> CreatePageAsync(WikiPageRequestCreate createPageRequest)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.GetToken()}");
            Guard.Against.CreatePage(createPageRequest);
            var postContent = new StringContent(JsonSerializer.Serialize(createPageRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{GetEndpoint()}/page", postContent);
            Guard.Against.CreatePageErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiPage>();
        }

        /// <summary>
        /// Updates or creates a wiki page. 
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <param name="updatePageRequest"></param>
        /// <returns>Page object with source property</returns>
        public async Task<WikiPage?> UpdatePageAsync(string title, WikiPageRequestUpdate updatePageRequest)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.GetToken()}");
            Guard.Against.UpdatePage(updatePageRequest);
            var postContent = new StringContent(JsonSerializer.Serialize(updatePageRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{GetEndpoint()}/page/{title}", postContent);
            Guard.Against.UpdatePageErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiPage>();
        }

        /// <summary>
        /// Returns the standard page object for a wiki page, including the API route to fetch the latest content 
        /// in HTML, the license, and information about the latest revision.
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <returns>Page object with html_url property</returns>
        public async Task<WikiPage?> GetPageAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/page/{title}/bare");
            Guard.Against.GetPageErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiPage>();
        }

        /// <summary>
        /// Returns information about a wiki page, including the license, latest revision, and latest content in HTML.
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <returns>Page object with html property</returns>
        public async Task<WikiPage?> GetPageOfflineAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/page/{title}/with_html");
            Guard.Against.GetPageErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiPage>();
        }

        /// <summary>
        /// Returns the content of a wiki page in the format specified by the content_model property, the license, 
        /// and information about the latest revision.
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <returns>Page object with source property</returns>
        public async Task<WikiPage?> GetPageSourceAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/page/{title}");
            Guard.Against.GetPageErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiPage>();
        }

        /// <summary>
        /// Returns the latest content of a wiki page in HTML.
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <returns>Page HTML in HTML 2.1.0 format</returns>
        public async Task<string?> GetPageHtmlAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/page/{title}/html");
            Guard.Against.GetPageErrors(response);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Searches connected wikis for pages with the same topic in different languages. Returns an array of 
        /// page language objects that include the name of the language, the language code, and the translated 
        /// page title.
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <returns>Array of page languages</returns>
        public async Task<IEnumerable<WikiPageLanguage>?> GetPageLanguagesAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/page/{title}/links/language");
            Guard.Against.GetPageLanguagesErrors(response);
            return await response.Content.ReadFromJsonAsync<IEnumerable<WikiPageLanguage>>();
        }

        /// <summary>
        /// Returns information about media files used on a wiki page.
        /// </summary>
        /// <param name="title">Wiki page title</param>
        /// <returns>files object containing array of files</returns>
        public async Task<IEnumerable<WikiFile>?> GetFilesOnPageAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/page/{title}/links/media");
            Guard.Against.GetPageFilesErrors(response);
            return await response.Content.ReadFromJsonAsync<IEnumerable<WikiFile>>();
        }

        /// <summary>
        /// Returns information about a file, including links to download the file in thumbnail, preview, and original formats.
        /// </summary>
        /// <param name="title">File title</param>
        /// <returns>File</returns>
        public async Task<WikiFile?> GetFileAsync(string title)
        {
            var response = await _httpClient.GetAsync($"{GetEndpoint()}/file/{title}");
            Guard.Against.GetFileErrors(response);
            return await response.Content.ReadFromJsonAsync<WikiFile>();
        }
    }
}
