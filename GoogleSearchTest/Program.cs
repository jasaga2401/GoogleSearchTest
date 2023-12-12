using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "AIzaSyA2GlCvK7Dlja_JAUEOp_wCTfHruLDMuIk";
        string searchEngineId = "73e695d8beacc42e4";
        string query = "recipes for christmas";

        // Specify the number of search results to retrieve
        int numberOfResults = 1;

        HttpClient httpClient = new HttpClient();

        try
        {
            // Modify the apiUrl to include the 'num' parameter
            string apiUrl = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={searchEngineId}&q={query}&num={numberOfResults}";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Failed to get a response. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            httpClient.Dispose();
        }

        Console.ReadLine();
    }
}
