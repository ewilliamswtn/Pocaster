using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
