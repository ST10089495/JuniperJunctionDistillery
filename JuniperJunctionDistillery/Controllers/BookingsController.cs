using JuniperJunctionDistillery.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Firebase.Auth;
using System.Diagnostics;

namespace JuniperJunctionDistillery.Controllers
{
    public class BookingsController : Controller
    {

        private const string FirebaseUrl = "https://juniper-junction-distill-2b013-default-rtdb.firebaseio.com";

        FirebaseAuthProvider auth;

        public BookingsController()
        {

            auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDdb5V5qgZvc-ZUyslp79Ulo0vFw3-g9mI"));
        }

        // GET: Booking

        [HttpGet]
        public IActionResult Bookingsform()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Bookingsform(Bookings booking)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    booking.Id = Guid.NewGuid();
                    client.BaseAddress = new Uri(FirebaseUrl);
                    string databaseNode = "bookings.json";
                    string json = JsonConvert.SerializeObject(booking);

                    var response = await client.PostAsync($"{databaseNode}?auth={auth}", new StringContent(json));



                    if (response.IsSuccessStatusCode)
                    {
                        // Data was successfully added to Firebase.
                        return RedirectToAction("GinExperiences");
                    }
                    else
                    {
                        // Handle the error.
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View("Bookingsform");
                    }
                }

            }

            catch (Exception ex)
            {
                // Handle exceptions.
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Bookingsform");
            }
            // Return the view with a blank booking form
           
        }

        public ActionResult GinExperiences()
        {
            return View();
        }
    }
}
