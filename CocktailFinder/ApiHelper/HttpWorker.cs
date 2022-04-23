namespace CocktailFinder.ApiHelper
{
    public class HttpWorker
    {
        public async Task<string> GetJsonResponse(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string response = await httpClient.GetStringAsync(httpClient.BaseAddress);

                if (String.IsNullOrWhiteSpace(response))
                {
                    return "";
                }
                return response;
            }
        }
    }
}
