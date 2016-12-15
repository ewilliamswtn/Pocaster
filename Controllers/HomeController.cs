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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Podcaster.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;
        public HomeController(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        
        public async Task<IActionResult> Index()
        {
            // Create new instance of the view model
            EpisodeListAll model = new EpisodeListAll(context);

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
