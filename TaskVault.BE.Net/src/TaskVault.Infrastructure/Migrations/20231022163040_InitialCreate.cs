using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskVault.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "Item");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auth",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Salt = table.Column<Guid>(type: "uniqueidentifier", maxLength: 1000, nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Status" },
                values: new object[] { 1L, "administrator@administrator.com", "Administrator", 1 });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Auth",
                columns: new[] { "Id", "Password", "Roles", "Salt", "UserId", "Username" },
                values: new object[] { 1L, "L4DYwGl7p4dvA4xKMRrhE1aMywSN0LYEOJ0jd5nelZzf/PZjfVVg607JRjDgQjFmkF9gGR7Zsc7LUNaaHMplDne351ErT/EJZn6/KcVEbOUXb9qY+SOgs34HT6zTKs3jj4siCZkpOqY5VE5O+SFMSNbAp2iZK1L9xX5ER6Ibs1CgWCgsQghTdjAtF9JjFO8FhXfDMeLdwLz3TSlsKEwNaMdp5s6gzYoxbHrq33SVLD/pOy7OxsjlNCKXK3LqzaICYppNKq8y5Pgu0RI/lGFIezV0hTkY/np6+VzAimSsUUgbZiNez7ook9FSyGZwW4NEfYERMe0O5amb2jiDV9G0cAUhMuQdRJj5rDgTo55WEwSb9r9h99q323GVVLg8zjfj0acThxIK/ZHSocpc/NgoIGEksR1TMEOXZNr6O79C9/FPNi6HME44MI1+dGYKXqnYc6DpccrATtcNuTJ/B5Ouowh25ZmKZuupmPuVTU+dbZmEcGPuaITUD5Fd2k4sVISOy2HhlyK9vv4q/LsCZqa1OP9fEalWBx/1uuUMY0lG39gG4JVgoWKWAvcINDaEmUbhINqKCLkj8353Z7wdI1PHILP4Yqj6H27S2c1eB7NfAIpakaG72wBPGNzXG9XpAJBz622JBCrP2wxTDERUKe9/y512DMpfvbg9xJKNWFq3Bkw=", 3, new Guid("3340f9d5-cba1-4fa8-b0ea-a28c4f974ae7"), 1L, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_Salt",
                schema: "Auth",
                table: "Auth",
                column: "Salt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserId",
                schema: "Auth",
                table: "Auth",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_Username",
                schema: "Auth",
                table: "Auth",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "User",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Item");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");
        }
    }
}
