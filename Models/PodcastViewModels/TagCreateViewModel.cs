using System.Collections.Generic;
using Podcaster.Models;
using Podcaster.Data;

namespace Podcaster.ViewModels
{

    public class TagCreateViewModel
  {
    private ApplicationDbContext context;
    public PodcastChannel PodcastChannel { get; set; }
    public IEnumerable<PodcastEpisode> Episodes { get; set; }
    public IEnumerable<PodcastChannel> Channels { get; set; }
     public PodcastEpisode CurrentEpisode { get; set; }
    public Tags NewTag { get; set; }


    public TagCreateViewModel(ApplicationDbContext ctx, ApplicationUser user) { }
  }
}