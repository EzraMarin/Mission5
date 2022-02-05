using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission5.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MovieInfo",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInfo", x => x.Title);
                    table.ForeignKey(
                        name: "FK_MovieInfo_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Horror" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Romance" });

            migrationBuilder.InsertData(
                table: "MovieInfo",
                columns: new[] { "Title", "CategoryId", "Director", "Edited", "LentTo", "Notes", "Rating", "Year" },
                values: new object[] { "The Dark Knight", 1, "Christopher Nolan", false, "", "", "PG-13", 2008 });

            migrationBuilder.InsertData(
                table: "MovieInfo",
                columns: new[] { "Title", "CategoryId", "Director", "Edited", "LentTo", "Notes", "Rating", "Year" },
                values: new object[] { "Hacksaw Ridge", 1, "Mel Gibson", false, "", "", "R", 2016 });

            migrationBuilder.InsertData(
                table: "MovieInfo",
                columns: new[] { "Title", "CategoryId", "Director", "Edited", "LentTo", "Notes", "Rating", "Year" },
                values: new object[] { "Nacho Libre", 2, "Jared Hess", false, "", "", "PG", 2006 });

            migrationBuilder.CreateIndex(
                name: "IX_MovieInfo_CategoryId",
                table: "MovieInfo",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieInfo");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
