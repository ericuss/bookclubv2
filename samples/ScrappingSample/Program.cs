// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;

Console.WriteLine("Starting ...");

   
static async Task<string> CallUrl(string fullUrl)
{
	HttpClient client = new HttpClient();
	var response = await client.GetStringAsync(fullUrl);
	return response;
}

static async Task<string> ParseHtml()
{
    const string url = "https://www.goodreads.com/book/show/2767793-the-hero-of-ages";
    var web = new HtmlWeb();
    var doc = await web.LoadFromWebAsync(url);

    Thread.Sleep(5000);

    //var nodes = doc.DocumentNode.Descendants("input")
    //         .Select(y => y.Descendants()
    //         .Where(x => x.Attributes["class"].Value == "box"))
    //         .ToList();
    var nodes = doc.DocumentNode
                .Descendants()
                .FirstOrDefault(x => x.Attributes["data-testid"]?.Value == "bookTitle")
                ;
    return nodes?.InnerText;

    var t = doc.DocumentNode.SelectSingleNode("//*[@data-testid=\"bookTitle\"]").InnerText;
    return t;
}




var response = await ParseHtml();

response.ToString();





Console.WriteLine("End");
