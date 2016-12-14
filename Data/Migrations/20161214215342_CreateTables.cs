using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podcaster.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "PodcastChannel",
                columns: table => new
                {
                    PodcastChannelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChannelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastChannel", x => x.PodcastChannelId);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserFavoritesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.UserFavoritesId);
                    table.ForeignKey(
                        name: "FK_UserFavorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PodcastEpisode",
                columns: table => new
                {
                    PodcastEpisodeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EpisodeName = table.Column<string>(nullable: true),
                    PodcastChannelId = table.Column<int>(nullable: false),
                    UserFavoritesId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastEpisode", x => x.PodcastEpisodeId);
                    table.ForeignKey(
                        name: "FK_PodcastEpisode_PodcastChannel_PodcastChannelId",
                        column: x => x.PodcastChannelId,
                        principalTable: "PodcastChannel",
                        principalColumn: "PodcastChannelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PodcastEpisode_UserFavorites_UserFavoritesId",
                        column: x => x.UserFavoritesId,
                        principalTable: "UserFavorites",
                        principalColumn: "UserFavoritesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PodcastEpisode_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    PodcastEpisodeId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_PodcastEpisode_PodcastEpisodeId",
                        column: x => x.PodcastEpisodeId,
                        principalTable: "PodcastEpisode",
                        principalColumn: "PodcastEpisodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PodcastEpisodeId = table.Column<int>(nullable: false),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_PodcastEpisode_PodcastEpisodeId",
                        column: x => x.PodcastEpisodeId,
                        principalTable: "PodcastEpisode",
                        principalColumn: "PodcastEpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisode_PodcastChannelId",
                table: "PodcastEpisode",
                column: "PodcastChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisode_UserFavoritesId",
                table: "PodcastEpisode",
                column: "UserFavoritesId");

            migrationBuilder.CreateIndex(
                name: "IX_PodcastEpisode_UserId",
                table: "PodcastEpisode",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PodcastEpisodeId",
                table: "Reviews",
                column: "PodcastEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PodcastEpisodeId",
                table: "Tags",
                column: "PodcastEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "PodcastEpisode");

            migrationBuilder.DropTable(
                name: "PodcastChannel");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
