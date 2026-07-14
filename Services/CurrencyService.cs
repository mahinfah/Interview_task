using System.Text.Json;
using Interview_task.Models;

namespace Interview_task.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;

        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeRateResponse?> ConvertCurrency(
            decimal amount,
            string from,
            string to  )
        {
            string url =
                $"https://api.frankfurter.app/latest?amount={amount}&from={from}&to={to}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ExchangeRateResponse>(json);
        }
    }
}