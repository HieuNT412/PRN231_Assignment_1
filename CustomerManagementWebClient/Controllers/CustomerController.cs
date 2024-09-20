using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CustomerManagementWebClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyDbContext _context;
        private readonly HttpClient client;
        private string CustomerApiUrl = "";


        public CustomerController(MyDbContext context)
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CustomerApiUrl = "http://localhost:5053/api/Customers";
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(CustomerApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Customer> listCustomer = JsonSerializer.Deserialize<List<Customer>>(strData, options);
            return View(listCustomer);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(string username)
        {
            HttpResponseMessage response = await client.GetAsync($"{CustomerApiUrl}/name?name={username}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Customer customer = JsonSerializer.Deserialize<Customer>(strData, options);
            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("username,password,fullname,gender,birthday,address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(customer), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(CustomerApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(string username)
        {
            

            HttpResponseMessage response = await client.GetAsync($"{CustomerApiUrl}/name?name={username}");

            
            string strData = await response.Content.ReadAsStringAsync();


            if (!response.IsSuccessStatusCode || string.IsNullOrWhiteSpace(strData))
            {
                // Trả về NotFound nếu không tìm thấy khách hàng
                return NotFound();
            }


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Customer customer = JsonSerializer.Deserialize<Customer>(strData, options);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string username, [Bind("username,password,fullname,gender,birthday,address")] Customer customer)
        {
            if (username != customer.username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(customer), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{CustomerApiUrl}/name?name={username}", content);
                Console.WriteLine(await content.ReadAsStringAsync());
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(string username)
        {
            HttpResponseMessage response = await client.GetAsync($"{CustomerApiUrl}/name?name={username}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Customer customer = JsonSerializer.Deserialize<Customer>(strData, options);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string username)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{CustomerApiUrl}/name?name={username}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private async Task<bool> CustomerExists(string username)
        {
            HttpResponseMessage response = await client.GetAsync($"{CustomerApiUrl}/name?name={username}");
            return response.IsSuccessStatusCode;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMultiple(string[] selectedUsernames)
        {
            if (selectedUsernames == null || selectedUsernames.Length == 0)
            {
                ModelState.AddModelError("", "No customers selected.");
                return RedirectToAction(nameof(Index)); // Redirect back to Index if no customers were selected
            }

            foreach (var username in selectedUsernames)
            {
                HttpResponseMessage response = await client.DeleteAsync($"{CustomerApiUrl}/name?name={username}");
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", $"Error deleting customer: {username}");
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
