using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
namespace Booking.WebUI.Services
{
    public interface IApiService
    {
        Task<T> GetAsync<T>(string endpoint, string token = null);
        Task<List<T>> GetListAsync<T>(string endpoint, string token = null);
        Task<T> PostAsync<T>(string endpoint, object data, string token = null);
        Task<T> PutAsync<T>(string endpoint, object data, string token = null);
        Task<bool> DeleteAsync(string endpoint, string token = null);
    }
}