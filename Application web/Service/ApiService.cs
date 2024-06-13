using Application_web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Application_web.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync()
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5148/Token/Login", new { Username = "3il", Password = "gy;ljD|F1!0E\\S?\",9p+P$w2%=3wJNn)Bb66#.EP2-ySXr2WFG-=GUS&Uyjp-&>" });
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            return result["token"];
        }

        public void SetAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("GetUserByCredentials", new { Username = username, Password = password });

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                return user;
            }

            return null;
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            var request = await _httpClient.GetAsync("http://localhost:5148/GetAllGroup");

            if (request.IsSuccessStatusCode)
            {
                var content = await request.Content.ReadAsStringAsync();
                var groups = JsonConvert.DeserializeObject<List<Group>>(content);
                return groups;
            }

            return new List<Group>();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5148/GetByIdGroup/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Group>(content);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5148/GetByIdStudent/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Student>(content);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5148/GetAllStudent");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Student>>(content);
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5148/GetAllGroup");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Group>>(content);
        }

        public async Task<List<StudentPresence>> GetAllStudentPresenceAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5148/GetAllStudentPresence");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<StudentPresence>>(content);
        }
    }
}
