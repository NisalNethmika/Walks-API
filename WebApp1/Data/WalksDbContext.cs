using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Domain;

namespace WebApp1.Data
{
    public class WalksDbContext:DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageURL = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageURL = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageURL = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageURL = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageURL = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);

            // Seed data for Walks
            var walks = new List<Walk>
            {
                new Walk
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c9d-1e2f3a4b5c6d"),
                    Name = "Mount Victoria Loop",
                    Description = "This loop track takes you to the top of Mount Victoria for stunning 360-degree views of Wellington and its harbour.",
                    LengthInKm = 3.5,
                    WalkImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    RegionId = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), // Wellington
                    DifficultyId = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f") // Easy
                },
                new Walk
                {
                    Id = Guid.Parse("b2c3d4e5-f6a7-4b5c-9d0e-2f3a4b5c6d7e"),
                    Name = "Tongariro Alpine Crossing",
                    Description = "One of New Zealand's most spectacular day walks featuring volcanic landscapes, emerald lakes, and panoramic views.",
                    LengthInKm = 19.4,
                    WalkImageURL = null,
                    RegionId = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"), // Bay Of Plenty
                    DifficultyId = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434") // Hard
                },
                new Walk
                {
                    Id = Guid.Parse("c3d4e5f6-a7b8-4c5d-0e1f-3a4b5c6d7e8f"),
                    Name = "Abel Tasman Coast Track",
                    Description = "A stunning coastal track with golden beaches, crystal clear water, and lush native forest.",
                    LengthInKm = 12.5,
                    WalkImageURL = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    RegionId = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), // Nelson
                    DifficultyId = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c") // Medium
                },
                new Walk
                {
                    Id = Guid.Parse("d4e5f6a7-b8c9-4d5e-1f2a-4b5c6d7e8f9a"),
                    Name = "Rangitoto Summit Track",
                    Description = "Climb to the summit of Auckland's iconic volcanic island for spectacular 360-degree views of the city and Hauraki Gulf.",
                    LengthInKm = 7.0,
                    WalkImageURL = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    RegionId = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), // Auckland
                    DifficultyId = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c") // Medium
                },
                new Walk
                {
                    Id = Guid.Parse("e5f6a7b8-c9d0-4e5f-2a3b-5c6d7e8f9a0b"),
                    Name = "Waipoua Forest Walk",
                    Description = "Walk among ancient kauri trees, including the famous Tane Mahuta, New Zealand's largest living kauri tree.",
                    LengthInKm = 2.5,
                    WalkImageURL = null,
                    RegionId = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), // Northland
                    DifficultyId = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f") // Easy
                },
                new Walk
                {
                    Id = Guid.Parse("f6a7b8c9-d0e1-4f5a-3b4c-6d7e8f9a0b1c"),
                    Name = "Milford Track",
                    Description = "One of the world's finest walks, showcasing New Zealand's dramatic fiordland scenery with waterfalls, rainforests, and mountain passes.",
                    LengthInKm = 53.5,
                    WalkImageURL = null,
                    RegionId = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"), // Southland
                    DifficultyId = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434") // Hard
                },
                new Walk
                {
                    Id = Guid.Parse("a7b8c9d0-e1f2-4a5b-4c5d-7e8f9a0b1c2d"),
                    Name = "Red Rocks Coastal Walk",
                    Description = "A scenic coastal walk from Owhiro Bay to the Red Rocks, where you might spot seals basking on the shore.",
                    LengthInKm = 8.0,
                    WalkImageURL = null,
                    RegionId = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), // Wellington
                    DifficultyId = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c") // Medium
                },
                new Walk
                {
                    Id = Guid.Parse("b8c9d0e1-f2a3-4b5c-5d6e-8f9a0b1c2d3e"),
                    Name = "Cornwall Park Walk",
                    Description = "An easy, family-friendly walk through beautiful parkland around One Tree Hill with views across Auckland.",
                    LengthInKm = 4.2,
                    WalkImageURL = null,
                    RegionId = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), // Auckland
                    DifficultyId = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f") // Easy
                }
            };

            modelBuilder.Entity<Walk>().HasData(walks);
        }
    }
}
