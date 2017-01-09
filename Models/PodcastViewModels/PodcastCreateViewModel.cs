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
    public List<SelectListItem> PodcastChannelId { get; set; }
    public PodcastEpisode PodcastEpisode { get; set; }

    public PodcastCreateViewModel(ApplicationDbContext ctx, ApplicationUser user)
    {
      this.PodcastChannelId = ctx.PodcastChannel
                              .OrderBy(l => l.ChannelName)
                              .AsEnumerable()
                              .Select(li => new SelectListItem
                              {
                                  Text = li.ChannelName,
                                  Value = li.PodcastChannelId.ToString()
                              }).ToList();

      this.PodcastChannelId.Insert(0, new SelectListItem
      {
          Text = "-CHOOSE A PODCAST-",
          Value = "0"
      });

        this.PodcastChannelId.Insert(1, new SelectListItem
      {
          Text = "-ADD NEW-",
          Value = "1"
      });
    }
  }
}