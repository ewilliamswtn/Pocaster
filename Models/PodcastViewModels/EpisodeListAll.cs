using System.Collections.Generic;
using Podcaster.Models;
using Podcaster.Data;

namespace Podcaster.ViewModels
{

  public class EpisodeListAll
  {
    private ApplicationDbContext context;
    public IEnumerable<PodcastEpisode> Episodes { get; set; }
    

    public EpisodeListAll(ApplicationDbContext ctx) { }
  }
}