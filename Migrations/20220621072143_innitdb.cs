using System;
using aspnet.Models;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet.Migrations
{
    public partial class innitdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });
            Randomizer.Seed = new Random(8675309);

            var bogusArticle = new Faker<Article>();

            bogusArticle.RuleFor(a => a.Title, setter => setter.Lorem.Sentence(5, 5));
            bogusArticle.RuleFor(a => a.PublishDate, setter => setter.Date.Between(new DateTime(2000, 1, 1), DateTime.Now));
            bogusArticle.RuleFor(a => a.Content, setter => setter.Lorem.Paragraphs(1, 4));

            for (int i = 1; i <= 150; i++)
            {
                Article article = bogusArticle.Generate();
                migrationBuilder.InsertData(
                    table: "Articles",
                    columns: new[] { "Title", "PublishDate", "Content" },
                    values: new object[]
                    {
                        article.Title,
                        article.PublishDate,
                        article.Content
                    }
                );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
