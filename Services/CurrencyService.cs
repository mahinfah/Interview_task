using System.Text.Json;

namespace Interview_task.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal?> ConvertCurrency(decimal amount, string from, string to)
        {
            string url = $"https://open.er-api.com/v6/latest/{from}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(json);

            var rates = document.RootElement.GetProperty("rates");

            if (!rates.TryGetProperty(to, out JsonElement rateElement))
            {
                return null;
            }

            decimal rate = rateElement.GetDecimal();

            return amount * rate;
        }
    }
}