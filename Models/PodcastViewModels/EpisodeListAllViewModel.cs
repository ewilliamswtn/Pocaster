using System.Collections.Generic;
using Podcaster.Models;
using Podcaster.Data;

namespace Podcaster.ViewModels
{

  public class EpisodeListAllViewModel
  {
    private ApplicationDbContext context;
    public IEnumerable<PodcastEpisode> Episodes { get; set; }
    public IEnumerable<PodcastChannel> Channels { get; set; }
    public IEnumerable<Tags> TagsList { get; set; }
    public IEnumerable<Reviews> ReviewsList { get; set; }
    public EpisodeListAllViewModel(ApplicationDbContext ctx, ApplicationUser user) { }
  }
}