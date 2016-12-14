using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Podcaster.Models;

namespace Podcaster.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
              // Look for any episodes.
              if (context.PodcastEpisode.Any())
              {
                  return;   // DB has been seeded
              }

              // add channels


              var channels = new PodcastChannel[]
              {
                  new PodcastChannel {
                      ChannelName = "The Joe Rogan Experience"
                  },
                  new PodcastChannel {
                      ChannelName = "The Tim Ferriss Show"
                  },
                  new PodcastChannel {
                      ChannelName = "Dan Carlin's Hardcore History"
                  }
              };

              foreach (PodcastChannel c in channels)
              {
                  context.PodcastChannel.Add(c);
              }
              context.SaveChanges();



              // add episodes

              var episodes = new PodcastEpisode[]
              {
                  new PodcastEpisode {
                      EpisodeName = "#310 - Neil DeGrasse Tyson",
                      PodcastChannelId = channels.Single(s => s.ChannelName == "The Joe Rogan Experience").PodcastChannelId
                  },
                  new PodcastEpisode {
                      EpisodeName = "Derek Sivers on Developing Confidence, Finding Happiness, and Saying “No” to Millions",
                      PodcastChannelId = channels.Single(s => s.ChannelName == "The Tim Ferriss Show").PodcastChannelId
                  },
                  new PodcastEpisode {
                      EpisodeName = "Show 56 - King of Kings",
                      PodcastChannelId = channels.Single(s => s.ChannelName == "Dan Carlin's Hardcore History").PodcastChannelId

                  }
              };

              foreach (PodcastEpisode e in episodes)
              {
                  context.PodcastEpisode.Add(e);
              }
              context.SaveChanges();



            //   var products = new Product[]
            //   {
            //       new Product {
            //           Description = "Colorful throw pillows to liven up your home",
            //           ProductTypeId = productTypes.Single(s => s.Label == "Housewares").ProductTypeId,
            //           Title = "Throw Pillow",
            //           Price = 7.49,
            //           CustomerId = customers.Single(s => s.FirstName == "Tractor").CustomerId
            //       },
            //       new Product {
            //           Description = "A 2012 iPod Shuffle. Headphones are included. 16G capacity.",
            //           ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
            //           Title = "iPod Shuffle",
            //           Price = 18.00,
            //           CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
            //       },
            //       new Product {
            //           Description = "Stainless steel refrigerator. Three years old. Minor scratches.",
            //           ProductTypeId = productTypes.Single(s => s.Label == "Appliances").ProductTypeId,
            //           Title = "Samsung refrigerator",
            //           Price = 500.00,
            //           CustomerId = customers.Single(s => s.FirstName == "Carson").CustomerId
            //       }
            //   };

            //   foreach (Product i in products)
            //   {
            //       context.Product.Add(i);
            //   }
            //   context.SaveChanges();
          }
       }
    }
}