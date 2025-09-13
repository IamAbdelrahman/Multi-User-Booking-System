using Booking.WebUI.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Booking.WebUI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string endpoint, string token = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync(endpoint);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }

                _logger.LogError($"API GET failed: {endpoint}, Status: {response.StatusCode}");
                return default(T);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"API GET exception: {endpoint}");
                throw;
            }
        }

        public async Task<List<T>> GetListAsync<T>(string endpoint, string token = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(endpoint);
                var content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<T>>(content);
                }
                _logger.LogError($"API GET List failed: {endpoint}, Status: {response.StatusCode}");
                return new List<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"API GET List exception: {endpoint}");
                throw;
            }
        }
        public async Task<T> PostAsync<T>(string endpoint, object data, string token = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }

                _logger.LogError($"API POST failed: {endpoint}, Status: {response.StatusCode}");
                return default(T);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"API POST exception: {endpoint}");
                throw;
            }
        }

        public async Task<T> PutAsync<T>(string endpoint, object data, string token = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }

                _logger.LogError($"API PUT failed: {endpoint}, Status: {response.StatusCode}");
                return default(T);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"API PUT exception: {endpoint}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(string endpoint, string token = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.DeleteAsync(endpoint);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"API DELETE exception: {endpoint}");
                return false;
            }
        }
    }
}