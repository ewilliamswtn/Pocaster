using System.Collections.Generic;
using Podcaster.Models;
using Podcaster.Data;

namespace Podcaster.ViewModels
{

  public class PodcastReviewViewModel
  {
    private ApplicationDbContext context;
    public IEnumerable<PodcastEpisode> Episodes { get; set; }
    public IEnumerable<PodcastChannel> Channels { get; set; }

    public PodcastReviewViewModel(ApplicationDbContext ctx, ApplicationUser user) { }
  }
}