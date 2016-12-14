using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Podcaster.Models
{
    public class Reviews
    {

        [Key]
        public int ReviewId { get; set; }

        // User who submitted the review
        public virtual ApplicationUser User { get; set; }

        public PodcastEpisode PodcastEpisode { get; set; }

        // A rating put into words.  Should be more than "was good" (use Rating), and not only list topics discussed (use tags).  Should more be focused on the significance of the episode to the user
        public string Description { get; set; }

        // Rating, from 1 - 5; 1 being completely terrible, 5 absolutely amazing.  Should be represented in star icons
        public int Rating { get; set; }
    }
}
