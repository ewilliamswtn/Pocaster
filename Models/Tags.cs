using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Podcaster.Models
{
    public class Tags
    {

        [Key]
        public int TagId { get; set; }
        public string Tag { get; set; }
        public int PodcastEpisodeId { get; set; }
        public PodcastEpisode Episode { get; set; }

    }
}
