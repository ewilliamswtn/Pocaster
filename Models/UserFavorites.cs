using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
