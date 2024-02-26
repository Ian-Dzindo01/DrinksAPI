using System.Net.Http.Headers;

using HttpClient client = new();
// Accept header specifies media types that the client is willing to receive in the response.
// Clear previous headers
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add( 
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{

}