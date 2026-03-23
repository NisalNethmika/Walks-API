using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddWalksSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageURL" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a5b-8c9d-1e2f3a4b5c6d"), "This loop track takes you to the top of Mount Victoria for stunning 360-degree views of Wellington and its harbour.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 3.5, "Mount Victoria Loop", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("a7b8c9d0-e1f2-4a5b-4c5d-7e8f9a0b1c2d"), "A scenic coastal walk from Owhiro Bay to the Red Rocks, where you might spot seals basking on the shore.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 8.0, "Red Rocks Coastal Walk", new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), null },
                    { new Guid("b2c3d4e5-f6a7-4b5c-9d0e-2f3a4b5c6d7e"), "One of New Zealand's most spectacular day walks featuring volcanic landscapes, emerald lakes, and panoramic views.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 19.399999999999999, "Tongariro Alpine Crossing", new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), null },
                    { new Guid("b8c9d0e1-f2a3-4b5c-5d6e-8f9a0b1c2d3e"), "An easy, family-friendly walk through beautiful parkland around One Tree Hill with views across Auckland.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 4.2000000000000002, "Cornwall Park Walk", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), null },
                    { new Guid("c3d4e5f6-a7b8-4c5d-0e1f-3a4b5c6d7e8f"), "A stunning coastal track with golden beaches, crystal clear water, and lush native forest.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 12.5, "Abel Tasman Coast Track", new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("d4e5f6a7-b8c9-4d5e-1f2a-4b5c6d7e8f9a"), "Climb to the summit of Auckland's iconic volcanic island for spectacular 360-degree views of the city and Hauraki Gulf.", new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), 7.0, "Rangitoto Summit Track", new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("e5f6a7b8-c9d0-4e5f-2a3b-5c6d7e8f9a0b"), "Walk among ancient kauri trees, including the famous Tane Mahuta, New Zealand's largest living kauri tree.", new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), 2.5, "Waipoua Forest Walk", new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), null },
                    { new Guid("f6a7b8c9-d0e1-4f5a-3b4c-6d7e8f9a0b1c"), "One of the world's finest walks, showcasing New Zealand's dramatic fiordland scenery with waterfalls, rainforests, and mountain passes.", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), 53.5, "Milford Track", new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a5b-4c5d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b5c-9d0e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b5c-5d6e-8f9a0b1c2d3e"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c5d-0e1f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d5e-1f2a-4b5c6d7e8f9a"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e5f-2a3b-5c6d7e8f9a0b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f5a-3b4c-6d7e8f9a0b1c"));
        }
    }
}
