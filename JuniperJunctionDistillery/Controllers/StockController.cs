using Firebase.Auth;
using JuniperJunctionDistillery.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JuniperJunctionDistillery.Controllers
{
    public class StockController : Controller
    {
        private const string FirebaseUrl = "https://juniper-junction-distill-2b013-default-rtdb.firebaseio.com";
        private FirebaseAuthProvider auth;

        public StockController()
        {
            auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDdb5V5qgZvc-ZUyslp79Ulo0vFw3-g9mI"));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = "Stock.json";

                    var response = await client.GetAsync($"{databaseNode}?auth={auth}");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Dictionary<string, Stock>>(json);

                        var list = new List<Stock>();
                        foreach (var item in data.Values)
                        {
                            list.Add(item);
                        }

                        return View(list);
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View(new List<Stock>());
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(new List<Stock>());
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Stock stock)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    stock.ID = Guid.NewGuid().ToString();
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = "Stock.json";
                    string json = JsonConvert.SerializeObject(stock);

                    var response = await client.PostAsync($"{databaseNode}?auth={auth}", new StringContent(json));

                    if (response.IsSuccessStatusCode)
                    {
                        // Data was successfully added to Firebase.
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View("Create");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Create");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Detail(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = $"Stock/{id}.json";

                    var response = await client.GetAsync($"{databaseNode}?auth={auth}");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Stock>(json);

                        return View(data);
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = $"Stock/{id}.json";

                    var response = await client.GetAsync($"{databaseNode}?auth={auth}");

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Stock>(json);

                        return View(data);
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Stock stock)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = $"Stock/{stock.ID}.json";
                    string json = JsonConvert.SerializeObject(stock);

                    var response = await client.PutAsync($"{databaseNode}?auth={auth}", new StringContent(json));

                    if (response.IsSuccessStatusCode)
                    {
                        // Data was successfully updated in Firebase.
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View("Edit", stock);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Edit", stock);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = $"Stock/{id}.json";

                    var response = await client.DeleteAsync($"{databaseNode}?auth={auth}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Data was successfully deleted from Firebase.
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
