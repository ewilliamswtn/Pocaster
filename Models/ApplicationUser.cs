using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Podcaster.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<PodcastEpisode> Episodes { get; set; }
        ICollection<Reviews> Reviews { get; set; }

        // public string FirstName { get; set; }

        // public string LastName { get; set; }
    }
}
