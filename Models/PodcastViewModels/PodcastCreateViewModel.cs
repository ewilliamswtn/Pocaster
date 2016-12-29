using System.Collections.Generic;
using System.Linq;
using Podcaster.Models;
using Podcaster.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcaster.ViewModels
{

  public class PodcastCreateViewModel
  {
    private ApplicationDbContext context;
    public IEnumerable<PodcastEpisode> Episodes { get; set; }
    public IEnumerable<PodcastChannel> Channels { get; set; }
    public IEnumerable<SelectListItem> PodcastChannels { get; set; }
    public PodcastEpisode PodcastEpisode { get; set; }

    public PodcastCreateViewModel(ApplicationDbContext ctx, ApplicationUser user) {
        // this.PodcastChannels = ctx.PodcastChannel
        //                         .OrderBy(l => l.ChannelName)
        //                         .AsEnumerable()
        //                         .Select(li => new SelectListItem { 
        //                             Text = li.ChannelName,
        //                             Value = li.PodcastChannelId.ToString()
        //                         }).ToList();

        // this.PodcastChannels.Insert(0, new SelectListItem { 
        //     Text = "Select Podcast Channel",
        //     Value = "0"
        // }); 
    }
  }
}