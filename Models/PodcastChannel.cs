using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Podcaster.Models
{
    // "Channel" will refer to a series of podcasts, to avoid confusion; e.g., The Joe Rogan Experience, Radiolab, The Tim Ferriss Show, etc
    public class PodcastChannel
    {

        // Id, for robots
        [Key]
        public int PodcastChannelId { get; set; }

        // List of episodes related to this channel
        public ICollection<PodcastEpisode> Episodes { get; set; }

        // Display name, for humans
        public string ChannelName { get; set; }

    }
}
