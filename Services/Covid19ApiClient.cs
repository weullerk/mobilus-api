using mobilus_test_api.Interfaces;
using mobilus_test_api.Model;
using System.Text.Json;

namespace mobilus_test_api.Services
{
    public class Covid19ApiClient : ICovid19Api
    {
        private string _url = "https://api.covid19api.com/country/brazil/status/confirmed?from={0}T00:00:00Z&to={1}T00:00:00Z";

        public List<Case> getLastSixMonthsCase()
        {
            using (var httpClient = new HttpClient())
            {
                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddMonths(-6);

                var response = httpClient.GetAsync(new Uri(String.Format(_url, startDate.Date, endDate.Date)));
                response.Wait();
                response.Result.EnsureSuccessStatusCode();
                
                var responseStream = response.Result.Content.ReadAsStringAsync();
                responseStream.Wait();

                var cases = JsonSerializer.Deserialize<List<Case>>(responseStream.Result);
                
                if (cases == null)
                {
                    return new List<Case>();
                }
                
                return cases;
            }
        }
    }
}
