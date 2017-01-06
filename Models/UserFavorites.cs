using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Podcaster.Models
{
    public class UserFavorites
    {

        [Key]
        public int UserFavoritesId { get; set; }

        // The user
        public virtual ApplicationUser User { get; set; }

        public ICollection<PodcastEpisode> Episodes { get; set; }

    }
}
