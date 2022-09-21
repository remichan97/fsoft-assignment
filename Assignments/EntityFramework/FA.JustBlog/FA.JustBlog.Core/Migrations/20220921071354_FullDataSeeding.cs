using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class FullDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("494cccb4-8f3f-46b5-a556-647cc06da55d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6b7ed439-9833-4499-88ae-6c09dbb8ee1b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("80add899-c0ea-43e5-badd-417a5bc0bde5"));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("9b9f639c-b23d-4278-b80f-ce77a9e25714"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(5049), "binhtruong@gmail.com", "A Demo Comment 3", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("a6f99cf6-556a-421b-bdc5-71bb43019f4b"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(5042), "binhtruong@gmail.com", "A Demo Comment 1", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("c9476b14-3be7-4447-8260-28ece11fc5fb"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 13, 53, 365, DateTimeKind.Local).AddTicks(5046), "binhtruong@gmail.com", "A Demo Comment 2", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"), new Guid("80fa9998-ca7b-4971-bce1-15f0688034c0") },
                    { new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"), new Guid("b32db558-8e83-47f7-94dd-b27678cf98ba") },
                    { new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), new Guid("80fa9998-ca7b-4971-bce1-15f0688034c0") }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"), new Guid("80fa9998-ca7b-4971-bce1-15f0688034c0") });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"), new Guid("b32db558-8e83-47f7-94dd-b27678cf98ba") });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "PostId", "TagId" },
                keyValues: new object[] { new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), new Guid("80fa9998-ca7b-4971-bce1-15f0688034c0") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("494cccb4-8f3f-46b5-a556-647cc06da55d"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4259), "binhtruong@gmail.com", "A Demo Comment 1", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("6b7ed439-9833-4499-88ae-6c09dbb8ee1b"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4262), "binhtruong@gmail.com", "A Demo Comment 2", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") },
                    { new Guid("80add899-c0ea-43e5-badd-417a5bc0bde5"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4265), "binhtruong@gmail.com", "A Demo Comment 3", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"),
                column: "PostedOn",
                value: new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),
                column: "PostedOn",
                value: new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4075));
        }
    }
}
