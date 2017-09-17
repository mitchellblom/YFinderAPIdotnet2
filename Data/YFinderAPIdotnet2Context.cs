using Microsoft.EntityFrameworkCore;

using YfinderAPIdotnet2.Models;

namespace YfinderAPIdotnet2.Data
{
    public class YfinderAPIdotnet2Context : DbContext
    {
        public YfinderAPIdotnet2Context(DbContextOptions<YfinderAPIdotnet2Context> options)
            : base(options)
        { }

        public DbSet<Descriptor> Descriptor { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Host> Host { get; set; }
        public DbSet<Hotspot> Hotspot { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<RatingDescriptor> RatingDescriptor { get; set; }
        public DbSet<User> User { get; set; }

    }
}
