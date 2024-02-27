using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
// Accept header specifies media types that the client is willing to receive in the response.
// Clear previous headers
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add( 
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
// User-Agent necessary for GitHub
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

    var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

    foreach (var repo in repositories ?? Enumerable.Empty<Repository>())
        Console.WriteLine(repo.name);
    }