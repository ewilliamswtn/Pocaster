using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Podcaster.Models
{
    // "Episode" will refer to an individual audio file from a series; e.g., "#865 - Wim Hof" (of "The Joe Rogan Experience"), or "#186: Tony Robbins on How to Resolve Internal Conflict" (of "The Time Ferriss Show")
    public class PodcastEpisode
    {
        // Id, for robots
        [Key]
        public int PodcastEpisodeId { get; set; }

        //  Display name, for humans
        public string EpisodeName { get; set; }

        // Topics discussed, genre, etc; e.g., "Fitness", "Nutrition", "Politics", etc
        public ICollection<Tags> EpisodeTags { get; set; }

        public ICollection<Reviews> Reviews { get; set; }

        // This property refers to the user who submitted this episode
        // public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int PodcastChannelId { get; set; }
        public PodcastChannel PodcastChannel { get; set; }

    }
}
