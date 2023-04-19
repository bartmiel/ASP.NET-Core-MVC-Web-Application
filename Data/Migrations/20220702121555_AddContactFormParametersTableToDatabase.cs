using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddContactFormParametersTableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field1Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field1Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field2Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field2Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field3Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field3Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field4Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field4Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field5Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Field5Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmitButtonTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactForm");
        }
    }
}
