using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class IdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9b9f639c-b23d-4278-b80f-ce77a9e25714"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a6f99cf6-556a-421b-bdc5-71bb43019f4b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c9476b14-3be7-4447-8260-28ece11fc5fb"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f685516-1abd-4315-8831-a5a03c58e76f", "c0e14bba-55cf-4905-a7f9-97a7e996e2ab", "Contributor", "CONTRIBUTOR" },
                    { "7786d32d-f3eb-444c-bb70-6e8172ab019c", "0ddae8d1-8569-4442-a108-0f60b0061978", "Blog Owner", "BLOG OWNER" },
                    { "95a1cdb8-09ca-4a78-8e97-23d111568fa8", "c4156964-e88c-44c4-b866-96445fc5bbcc", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "017888d8-e46a-4a2f-b207-7df331fe49e4", 0, "307e1b30-71f5-4e34-a77c-36b26b9a6a80", "BlogUsers", "contributor2@localhost.com", false, "System", "Contributor 2", false, null, "CONTRIBUTOR2@LOCALHOST.COM", "CONTRIBUTOR2@LOCALHOST.COM", "AQAAAAEAACcQAAAAEH35EXlmVHzUXmheu/ZzH4xPneVKtivIYHJ3ssWjfKGisj2VhZIVBjJIUHTqyaDtxQ==", null, false, "26aa2b77-4d7b-46a7-b21d-c329bc2a3077", false, "contributor2@localhost.com" },
                    { "149d42c3-9385-467c-934b-1d4d18b415b5", 0, "2a737093-bf1a-4410-848b-237c15127739", "BlogUsers", "mod2@localhost.com", false, "System", "Administrator 3", false, null, "MOD2@LOCALHOST.COM", "MOD2@LOCALHOST.COM", "AQAAAAEAACcQAAAAEFeB4mAKFp0S/Apn1EQwgsKEjVu5Ll3ff1I3DtFM02nYO2+RhBRyT/5icZRxPsy1Pg==", null, false, "3c86a064-372c-4129-8c42-b078d51294af", false, "mod2@localhost.com" },
                    { "3c97c3a6-5626-445c-a7cc-df5da48b7df7", 0, "4dbfad5b-828f-49f7-8685-cc967abe38d3", "BlogUsers", "mod1@localhost.com", false, "System", "Administrator 2", false, null, "MOD1@LOCALHOST.COM", "MOD1@LOCALHOST.COM", "AQAAAAEAACcQAAAAEOjmt91aYepOfX8vQ4IpcRvpO0+YncpXSxN0Uw7z/yBv0W8nQ4b888Qn5YATFiu3PA==", null, false, "7740a616-3fd1-4491-9a98-d82c6f09a7a1", false, "mod1@localhost.com" },
                    { "5d8610ce-c87e-44de-b63d-db947edc8a16", 0, "a6020c1a-826d-407d-a5c0-80f27f24ab95", "BlogUsers", "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEBr8sA8tqxl6WqJV14opWs/0QCWrF1O4vly0Q+ZqXnSMWSut0NHA+6vUPY+fYq/Zgw==", null, false, "0646b46b-f61b-4d14-94c6-006e9a731f62", false, "admin@localhost.com" },
                    { "7ee8dfab-7cf9-4f1b-b9ea-5f92e11af797", 0, "c923fb17-fb12-418c-a3b0-9775b471abbc", "BlogUsers", "contributor3@localhost.com", false, "System", "Contributor 3", false, null, "CONTRIBUTOR3@LOCALHOST.COM", "CONTRIBUTOR3@LOCALHOST.COM", "AQAAAAEAACcQAAAAEDuuwL9ui5DnaVXdZGdVNns47VSXiNl5XaUvJB/uc0G4Lx7EmAsShV2qdpxXjoEgGw==", null, false, "b074a947-5f19-4ddb-928a-f34c97fdbb92", false, "contributor3@localhost.com" },
                    { "c3cb4a1a-eaf3-4f18-9626-2e72301b8bd1", 0, "a13dd5c1-7b8b-4c55-9e21-632dcfa87904", "BlogUsers", "user3@localhost.com", false, "System", "User 3", false, null, "USER3@LOCALHOST.COM", "USER3@LOCALHOST.COM", "AQAAAAEAACcQAAAAEHLDklm685LD658LfYr83iQ35tailTo2ADCroTsfFaMl9uJTJXcZtOVjSjZ0tYAT9Q==", null, false, "015115de-e54b-44ed-9680-851d85d2b0f5", false, "user3@localhost.com" },
                    { "d77e4bf3-a0a1-4eb5-9e61-901b51dfcd4d", 0, "7f8c3f34-15a3-4a67-95a2-43648f55a2ab", "BlogUsers", "user2@localhost.com", false, "System", "User 2", false, null, "USER2@LOCALHOST.COM", "USER2@LOCALHOST.COM", "AQAAAAEAACcQAAAAEJB9DHOv4gwT6641cfUTF8u5bFiktX0MIMzUtIl7jaPj/xFvq28TdTTv9ObOKfztNg==", null, false, "1ce046ad-86b2-448b-aea6-2afc2efb8a1e", false, "user2@localhost.com" },
                    { "e52e436f-03f8-4d09-911e-60c7b41e58ab", 0, "83a63ce4-b776-4d1b-880e-4be7e553ffff", "BlogUsers", "user1@localhost.com", false, "System", "User 1", false, null, "USER1@LOCALHOST.COM", "USER1@LOCALHOST.COM", "AQAAAAEAACcQAAAAEOmjcaGVV2uAoQKpFL7iP5i89XAYhqdZ5pPS6ssUKI8nnXev0mRF8YLRWfpsQRcHww==", null, false, "cff39f41-a66e-4a64-9a5d-71e9e66f10fe", false, "user1@localhost.com" },
                    { "f91b9d5b-cb78-4410-9eda-a085f3219e7b", 0, "a97dc22a-767d-40f1-b1ad-e590ef538431", "BlogUsers", "contributor@localhost.com", false, "System", "Contrubutor 1", false, null, "CONTRIBUTOR@LOCALHOST.COM", "CONTRIBUTOR@LOCALHOST.COM", "AQAAAAEAACcQAAAAEMfmjKM4fxdYLD+h6CIfSKLUEwMpu2OSjKq2+/xRLzKYqm2XcV40NCEo1gV44SAwnw==", null, false, "a9cc2618-8580-4076-b1ed-1227907b43c0", false, "contributor@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("6435e4f7-c437-4b1c-9494-5a6c408d3263"), "Header", "A Comment Body", new DateTime(2022, 10, 4, 22, 24, 31, 911, DateTimeKind.Local).AddTicks(6114), "binhtruong@gmail.com", "A Demo Comment 1", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("863627da-e97c-491e-9d27-0d3165806c5c"), "Header", "A Comment Body", new DateTime(2022, 10, 4, 22, 24, 31, 911, DateTimeKind.Local).AddTicks(6120), "binhtruong@gmail.com", "A Demo Comment 2", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("cd5520ac-0ade-430f-920e-f6ac148d8d0c"), "Header", "A Comment Body", new DateTime(2022, 10, 4, 22, 24, 31, 911, DateTimeKind.Local).AddTicks(6122), "binhtruong@gmail.com", "A Demo Comment 3", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"),
                column: "PostedOn",
                value: new DateTime(2022, 10, 4, 22, 24, 31, 911, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),
                column: "PostedOn",
                value: new DateTime(2022, 10, 4, 22, 24, 31, 911, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3f685516-1abd-4315-8831-a5a03c58e76f", "017888d8-e46a-4a2f-b207-7df331fe49e4" },
                    { "7786d32d-f3eb-444c-bb70-6e8172ab019c", "149d42c3-9385-467c-934b-1d4d18b415b5" },
                    { "7786d32d-f3eb-444c-bb70-6e8172ab019c", "3c97c3a6-5626-445c-a7cc-df5da48b7df7" },
                    { "7786d32d-f3eb-444c-bb70-6e8172ab019c", "5d8610ce-c87e-44de-b63d-db947edc8a16" },
                    { "3f685516-1abd-4315-8831-a5a03c58e76f", "7ee8dfab-7cf9-4f1b-b9ea-5f92e11af797" },
                    { "95a1cdb8-09ca-4a78-8e97-23d111568fa8", "c3cb4a1a-eaf3-4f18-9626-2e72301b8bd1" },
                    { "95a1cdb8-09ca-4a78-8e97-23d111568fa8", "d77e4bf3-a0a1-4eb5-9e61-901b51dfcd4d" },
                    { "95a1cdb8-09ca-4a78-8e97-23d111568fa8", "e52e436f-03f8-4d09-911e-60c7b41e58ab" },
                    { "3f685516-1abd-4315-8831-a5a03c58e76f", "f91b9d5b-cb78-4410-9eda-a085f3219e7b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6435e4f7-c437-4b1c-9494-5a6c408d3263"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("863627da-e97c-491e-9d27-0d3165806c5c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cd5520ac-0ade-430f-920e-f6ac148d8d0c"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("9b9f639c-b23d-4278-b80f-ce77a9e25714"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(5049), "binhtruong@gmail.com", "A Demo Comment 3", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("a6f99cf6-556a-421b-bdc5-71bb43019f4b"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(5042), "binhtruong@gmail.com", "A Demo Comment 1", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("c9476b14-3be7-4447-8260-28ece11fc5fb"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(5046), "binhtruong@gmail.com", "A Demo Comment 2", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"),
                column: "PostedOn",
                value: new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),
                column: "PostedOn",
                value: new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(4812));
        }
    }
}
