using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("0549b13b-668a-4556-8176-e3d9abbbbefe"), "Demo category", "Category 3", "cat-3" },
                    { new Guid("37b2a62e-b9b8-456c-bcce-6c30c696575f"), "Demo category", "Category 1", "cat-1" },
                    { new Guid("59918479-bfae-4794-8477-b5c0f4ad05e2"), "Demo category", "Category 2", "cat-2" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("80fa9998-ca7b-4971-bce1-15f0688034c0"), 0, "A Demo tag", "Tag1", "tag-1" },
                    { new Guid("ab0cbc9d-14e3-4c3b-a0d7-a28bd2ad471b"), 0, "A Demo tag", "Tag2", "tag-2" },
                    { new Guid("b32db558-8e83-47f7-94dd-b27678cf98ba"), 0, "A Demo tag", "Tag3", "tag-3" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoriesId", "Meta", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"), new Guid("37b2a62e-b9b8-456c-bcce-6c30c696575f"), "Test", "A whatever text here", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4058), true, 4.5, "A Short Desc", "A Post number 1", 50.0, "post-1", 100 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoriesId", "Meta", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { new Guid("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"), new Guid("59918479-bfae-4794-8477-b5c0f4ad05e2"), "Test", "A whatever text here", new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0.0, "A Short Desc", "A Post number 3", 0.0, "post-3", 0 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoriesId", "Meta", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), new Guid("37b2a62e-b9b8-456c-bcce-6c30c696575f"), "Test", "A whatever text here", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4075), true, 4.5, "A Short Desc", "A Post number 2", 50.0, "post-2", 100 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[] { new Guid("494cccb4-8f3f-46b5-a556-647cc06da55d"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4259), "binhtruong@gmail.com", "A Demo Comment 1", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[] { new Guid("6b7ed439-9833-4499-88ae-6c09dbb8ee1b"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4262), "binhtruong@gmail.com", "A Demo Comment 2", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[] { new Guid("80add899-c0ea-43e5-badd-417a5bc0bde5"), "Header", "A Comment Body", new DateTime(2022, 9, 21, 14, 9, 5, 242, DateTimeKind.Local).AddTicks(4265), "binhtruong@gmail.com", "A Demo Comment 3", new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0549b13b-668a-4556-8176-e3d9abbbbefe"));

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

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("80fa9998-ca7b-4971-bce1-15f0688034c0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ab0cbc9d-14e3-4c3b-a0d7-a28bd2ad471b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b32db558-8e83-47f7-94dd-b27678cf98ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("59918479-bfae-4794-8477-b5c0f4ad05e2"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("18d6c8da-6d80-4b5c-a94f-66e32835aede"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("37b2a62e-b9b8-456c-bcce-6c30c696575f"));
        }
    }
}
