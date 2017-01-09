using System;
using System.Threading.Tasks;
using Podcaster.Models;
using Podcaster.Data;
using Podcaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Podcaster.Controllers
{
    // Home Controller Class
    public class HomeController : Controller
    {
        // User Manager, used to get active user
        private readonly UserManager<ApplicationUser> _userManager;

        // Databse Context
        private ApplicationDbContext context;

        // Home Controller Method
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }
    
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // *****************************
        // ***** View Constructors *****
        // *****************************
    
        // ***** Index *****

        // Index Method on Home Controller, creates instance of Index View
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

            model.TagsList = await context.Tags
            .Include(e => e.Episode)
            // .Where(e.PodcastChannelId == e.PodcastChannelId)
            .ToListAsync(); 

            return View(model);
        }

        // ***** Create *****

        // Create Method on Home Controller, creates instance of Create(podcast) View
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            PodcastCreateViewModel model = new PodcastCreateViewModel(context, user);
            return View(model); 
        }
    
        // Create(Overload) Method on Home Controller, posts new podcast episode to database, then sends user back to Index View
        [HttpPost]
        public async Task<IActionResult> Create(PodcastEpisode podcastepisode)
        {
            //Ignore user from model state
            ModelState.Remove("podcastepisode.User");

            //This creates a new variable to hold our current instance of the ActiveCustomer class and then sets the active customer's id to the CustomerId property on the product being created so that a valid model is sent to the database
            var user = await GetCurrentUserAsync();

            if (podcastepisode.PodcastChannelId == 0)
            {
                return RedirectToAction("Create");
            }

            if (podcastepisode.PodcastChannelId == 1)
            {
                return RedirectToAction("ChannelCreate");
            }

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

        // ***** ChannelCreate *****

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ChannelCreate()
        {
            var user = await GetCurrentUserAsync();
            ChannelCreateViewModel model = new ChannelCreateViewModel(context, user);
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> ChannelCreate(PodcastChannel podcastchannel)
        {
            //Ignore user from model state
            // ModelState.Remove("podcastchannel.User");

            //This creates a new variable to hold our current instance of the ActiveCustomer class and then sets the active customer's id to the CustomerId property on the product being created so that a valid model is sent to the database
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                // podcastchannel.User = user;
                context.Add(podcastchannel);
                await context.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ChannelCreateViewModel model = new ChannelCreateViewModel(context, user);
            return View(model);
        }

        // ***** Tag *****

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> TagCreate(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var episode = await context.PodcastEpisode
                    .SingleOrDefaultAsync(m => m.PodcastEpisodeId == id);

            if (episode == null)
            {
                return NotFound();
            }


            var user = await GetCurrentUserAsync();
            TagCreateViewModel model = new TagCreateViewModel(context, user);
            model.CurrentEpisode = episode;
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> TagCreate(int id, Tags tag)
        {
            //Ignore user from model state
            // ModelState.Remove("podcastchannel.User");

            //This creates a new variable to hold our current instance of the ActiveCustomer class and then sets the active customer's id to the CustomerId property on the product being created so that a valid model is sent to the database
            var user = await GetCurrentUserAsync();


            if (ModelState.IsValid)
            {
                tag.Tag = "Test";
                tag.PodcastEpisodeId = id;                
                context.Add(tag);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            TagCreateViewModel model = new TagCreateViewModel(context, user);

            return View(model);
        }

        // ***** Description *****

        // ***** Rate *****

        [HttpGet]
        public async Task<IActionResult> Review(int rating)
        {
            var user = await GetCurrentUserAsync();
            PodcastReviewViewModel model = new PodcastReviewViewModel(context, user);
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Review(Reviews review)
        {
            //Ignore user from model state
            ModelState.Remove("review.User");

            //This creates a new variable to hold our current instance of the ActiveCustomer class and then sets the active customer's id to the CustomerId property on the product being created so that a valid model is sent to the database
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                review.User = user;
                review.PodcastEpisodeId = 4;
                context.Add(review);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ChannelCreateViewModel model = new ChannelCreateViewModel(context, user);
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
