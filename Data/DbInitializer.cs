using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YfinderAPIdotnet2.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YfinderAPIdotnet2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YfinderAPIdotnet2Context(serviceProvider.GetRequiredService<DbContextOptions<YfinderAPIdotnet2Context>>()))
            {
                if (context.User.Any())
                {
                    return;
                }

                //seeding DESCRIPTORS
                var descriptors = new Descriptor[]
                {
                    new Descriptor {
                        Description = "Abundant Power Outlets"
                    },
                    new Descriptor {
                        Description = "Rare Power Outlets"
                    },
                    new Descriptor {
                        Description = "Loud Atmosphere"
                    },
                    new Descriptor {
                        Description = "Quiet Atmosphere"
                    },
                    new Descriptor {
                        Description = "Teamwork Friendly"
                    },
                    new Descriptor {
                        Description = "Teamwork Averse"
                    },
                    new Descriptor {
                        Description = "Password Protected"
                    },
                    new Descriptor {
                        Description = "Secluded Seating"
                    },
                    new Descriptor {
                        Description = "Easy To Focus"
                    },
                    new Descriptor {
                        Description = "Hard To Focus"
                    },
                    new Descriptor {
                        Description = "Introvert Paradise"
                    },
                    new Descriptor {
                        Description = "Extravert Playground"
                    }
                };

                foreach (Descriptor i in descriptors)
                {
                    context.Descriptor.Add(i);
                }
                context.SaveChanges();

                //seeding USERS
                var users = new User[]
                {
                    new User { 
                        Email = "dv@example.com",
                        FullName = "Dee Veloper",
                        Host = 0,
                        UserName = "deeveloper",
                        Zip = 37211
                    },
                    new User { 
                        Email = "bb@example.com",
                        FullName = "Bob Bernstein",
                        Host = 1,
                        UserName = "bobbernstein",
                        Zip = 37212
                    },
                    new User { 
                        Email = "ldb@example.com",
                        FullName = "Lila D. Bunch",
                        Host = 1,
                        UserName = "liladbunch",
                        Zip = 37212
                    },
                    new User { 
                        Email = "ts@example.com",
                        FullName = "Taylor Swift",
                        Host = 0,
                        UserName = "taylorswift",
                        Zip = 37203
                    },
                    new User { 
                        Email = "aa@example.com",
                        FullName = "Auntie Anne",
                        Host = 1,
                        UserName = "auntieanne",
                        Zip = 37213
                    },
                    new User { 
                        Email = "jf@example.com",
                        FullName = "Jango Fett",
                        Host = 0,
                        UserName = "jangofett",
                        Zip = 37214
                    },
                    new User { 
                        Email = "js@example.com",
                        FullName = "Jon Snow",
                        Host = 0,
                        UserName = "jonsnow",
                        Zip = 37210
                    },
                    new User { 
                        Email = "vk@example.com",
                        FullName = "Val Kilmer",
                        Host = 0,
                        UserName = "valkilmer",
                        Zip = 37211
                    }
                };

                foreach (User i in users)
                {
                    context.User.Add(i);
                }
                context.SaveChanges();

                //seeding HOSTS
                var hosts = new Host[]
                {
                    new Host { 
                        Address = "2007 Belmont Blvd", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Bongo Java",
                        UserId = users.Single(n => n.FullName == "Bob Bernstein").UserId,
                        Zip = 37212
                    },
                    new Host { 
                        Address = "1900 Belmont Blvd", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Belmont University Library",
                        UserId = users.Single(n => n.FullName == "Lila D. Bunch").UserId,
                        Zip = 37212
                    },
                    new Host { 
                        Address = "603 Taylor St", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Steadfast Coffee",
                        UserId = null,
                        Zip = 37208
                    },
                    new Host { 
                        Address = "603 Taylor St", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Nashville Software School",
                        UserId = users.Single(n => n.FullName == "Auntie Anne").UserId,
                        Zip = 37210
                    },
                    new Host { 
                        Address = "2519 Nolensville Pike", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Red Bicycle",
                        UserId = null,
                        Zip = 37211
                    },
                    new Host { 
                        Address = "900 Rosa Parks Blvd", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Farmers Market",
                        UserId = null,
                        Zip = 37208
                    },
                    new Host { 
                        Address = "4500 Murphy Rd", 
                        City = "Nashville", 
                        State= "TN",
                        Title = "Edley's BBQ",
                        UserId = null,
                        Zip = 37209
                    }
                };

                foreach (Host i in hosts)
                {
                    context.Host.Add(i);
                }
                context.SaveChanges();

                //seeding HOTSPOTS
                var hotspots = new Hotspot[]
                {
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Bongo Java").HostId,
                        Title = "BongoWifi"
                    },
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Belmont University Library").HostId,
                        Title = "BruinWifi"
                    },
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Steadfast Coffee").HostId,
                        Title = "SteadfastWifi"
                    },
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Nashville Software School").HostId,
                        Title = "NSSguest"
                    },
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Red Bicycle").HostId,
                        Title = "RBwifi"
                    },
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Farmers Market").HostId,
                        Title = "FMwifi"
                    },
                    new Hotspot { 
                        HostId = context.Host.Single(h => h.Title == "Edley's BBQ").HostId,
                        Title = "EdleysWifi"
                    },
                };

                foreach (Hotspot i in hotspots)
                {
                    context.Hotspot.Add(i);
                }
                context.SaveChanges();

                //seeding RATINGS
                var ratings = new Rating[]
                {
                    new Rating { 
                        Comment = "Killer good speed, and nice place to focus on the task",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "BongoWifi").HotspotId,
                        Public = 1,
                        Score = 4,
                        UserId = context.User.Single(h => h.FullName == "Jango Fett").UserId
                    },
                    new Rating { 
                        Comment = "Not the best wifi, but Iiked the darkness. It was almost like a cave.",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "BruinWifi").HotspotId,
                        Public = 1,
                        Score = 4,
                        UserId = context.User.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "Tried the coffee soda while sitting there for hours. Tons of outlets.",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "SteadfastWifi").HotspotId,
                        Public = 1,
                        Score = 5,
                        UserId = context.User.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "Couldn't find any outlets. Wouldn't recommend.",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "BruinWifi").HotspotId,
                        Public = 1,
                        Score = 2,
                        UserId = context.User.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "They let me sit here all day even though I didn't buy anything.",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "RBwifi").HotspotId,
                        Public = 1,
                        Score = 2,
                        UserId = context.User.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "They let me sit here all day even though I didn't buy anything.",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "RBwifi").HotspotId,
                        Public = 1,
                        Score = 2,
                        UserId = context.User.Single(h => h.FullName == "Dee Veloper").UserId
                    },
                    new Rating { 
                        Comment = "They let me sit here all day even though I didn't buy anything.",
                        RatingDate = DateTime.Now,
                        HotspotId = context.Hotspot.Single(h => h.Title == "FMwifi").HotspotId,
                        Public = 1,
                        Score = 2,
                        UserId = context.User.Single(h => h.FullName == "Jon Snow").UserId
                    }
                };

                foreach (Rating i in ratings)
                {
                    context.Rating.Add(i);
                }
                context.SaveChanges();

                //seeding RatingDescriptors, matching up with the initialized ratings and descriptors by id
                var ratingDescriptors = new RatingDescriptor[]
                {
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 1).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 1).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 1).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 3).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 1).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 5).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 2).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 2).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 2).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 4).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 2).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 6).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 3).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 3).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 3).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 5).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 4).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 5).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 4).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 7).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 5).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 9).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 6).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 12).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 6).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 10).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 7).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 11).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = context.Rating.Single(o => o.RatingId == 7).RatingId,
                        DescriptorId = context.Descriptor.Single(o => o.DescriptorId == 1).DescriptorId
                    }
                };
                   
                foreach (RatingDescriptor i in ratingDescriptors)
                {
                    context.RatingDescriptor.Add(i);
                }
                context.SaveChanges();

                //seeding Favorites, matching up with the initialized ratings and descriptors by id
                var favorites = new Favorite[]
                {
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 1).UserId,
                        HostId = context.Host.Single(o => o.HostId == 1).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 1).UserId,
                        HostId = context.Host.Single(o => o.HostId == 2).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 1).UserId,
                        HostId = context.Host.Single(o => o.HostId == 3).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 2).UserId,
                        HostId = context.Host.Single(o => o.HostId == 4).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 2).UserId,
                        HostId = context.Host.Single(o => o.HostId == 5).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 2).UserId,
                        HostId = context.Host.Single(o => o.HostId == 6).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 3).UserId,
                        HostId = context.Host.Single(o => o.HostId == 1).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 3).UserId,
                        HostId = context.Host.Single(o => o.HostId == 3).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 3).UserId,
                        HostId = context.Host.Single(o => o.HostId == 5).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 4).UserId,
                        HostId = context.Host.Single(o => o.HostId == 2).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 4).UserId,
                        HostId = context.Host.Single(o => o.HostId == 4).HostId
                    },
                    new Favorite {
                        UserId = context.User.Single(o => o.UserId == 4).UserId,
                        HostId = context.Host.Single(o => o.HostId == 6).HostId
                    }
                };
                   
                foreach (Favorite i in favorites)
                {
                    context.Favorite.Add(i);
                }
                context.SaveChanges();

            }
       }
    }
}