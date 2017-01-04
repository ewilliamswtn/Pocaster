using System.Collections.Generic;
using System.Linq;
using Podcaster.Models;
using Podcaster.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Podcaster.ViewModels
{

  public class ChannelCreateViewModel
  {
    private ApplicationDbContext context;
    public PodcastChannel PodcastChannel { get; set; }
    public IEnumerable<PodcastEpisode> Episodes { get; set; }
    public IEnumerable<PodcastChannel> Channels { get; set; }

    public ChannelCreateViewModel(ApplicationDbContext ctx, ApplicationUser user) { }
  }
}