using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Podcaster.Models;
using Podcaster.Data;
using Podcaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Podcaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext context;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }
    
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            // Create new instance of the view model
            EpisodeListAllViewModel model = new EpisodeListAllViewModel(context, user);

            // Set the properties of the view model
            model.Episodes = await context.PodcastEpisode
            .Include(e => e.PodcastChannel)
            // .Where(e.PodcastChannelId == e.PodcastChannelId)
            .ToListAsync(); 
            return View(model);
        }

        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            PodcastCreateViewModel model = new PodcastCreateViewModel(context, user);
            return View(model); 
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(PodcastEpisode podcastepisode)
        {
            //Ignore user from model state
            ModelState.Remove("podcastepisode.User");

            //This creates a new variable to hold our current instance of the ActiveCustomer class and then sets the active customer's id to the CustomerId property on the product being created so that a valid model is sent to the database
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                podcastepisode.User = user;
                context.Add(podcastepisode);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            PodcastCreateViewModel model = new PodcastCreateViewModel(context, user);
            return View(model);
        }


        public async Task<IActionResult> Rate([FromRoute]int rating)
        {
            var user = await GetCurrentUserAsync();
            // Create new instance of the view model
            EpisodeListAllViewModel model = new EpisodeListAllViewModel(context, user);

            // Set the properties of the view model
            model.Episodes = await context.PodcastEpisode
            .Include(e => e.PodcastChannel)
            // .Where(e.PodcastChannelId == e.PodcastChannelId)
            .ToListAsync(); 
            return View(model);
        }


        // public IActionResult About()
        // {
        //     ViewData["Message"] = "Your application description page.";

        //     return View();
        // }

        // public IActionResult Contact()
        // {
        //     ViewData["Message"] = "Your contact page.";

        //     return View();
        // }

        // public IActionResult Error()
        // {
        //     return View();
        // }
    }
}
