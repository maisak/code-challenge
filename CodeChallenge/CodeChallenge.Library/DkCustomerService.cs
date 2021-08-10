using System;
using System.Linq;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace CodeChallenge.Library
{
    public class Customers
    {
        public Customer GetCustomer(string id)
        {
            var hc = new HttpClient();
            hc.BaseAddress = new Uri("https://api.dkplus.is/api/v1");
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "3541031f-baf2-4737-a7e8-c66396e5a5e3");

            var m = new HttpRequestMessage(HttpMethod.Get, "https://api.dkplus.is/api/v1/customer/" + id);

            var r = hc.SendAsync(m).Result;
            var c = JsonSerializer.Deserialize<Customer>(r.Content.ReadAsStringAsync().Result);
            return c;
        }

        public Customer GetCustomer2(string email)
        {
            var hc = new HttpClient();
            hc.BaseAddress = new Uri("https://api.dkplus.is/api/v1");
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "3541031f-baf2-4737-a7e8-c66396e5a5e3");

            var m = new HttpRequestMessage(HttpMethod.Get, "https://api.dkplus.is/api/v1/customer/search" + HttpUtility.UrlEncode(email) + "/10");

            var r = hc.SendAsync(m).Result;
            var c = JsonSerializer.Deserialize<Customer>(r.Content.ReadAsStringAsync().Result);
            return c;
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
