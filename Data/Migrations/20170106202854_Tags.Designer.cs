using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Podcaster.Data;

namespace Podcaster.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170106202854_Tags")]
    partial class Tags
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Podcaster.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Podcaster.Models.PodcastChannel", b =>
                {
                    b.Property<int>("PodcastChannelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChannelName");

                    b.HasKey("PodcastChannelId");

                    b.ToTable("PodcastChannel");
                });

            modelBuilder.Entity("Podcaster.Models.PodcastEpisode", b =>
                {
                    b.Property<int>("PodcastEpisodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EpisodeName");

                    b.Property<int>("PodcastChannelId");

                    b.Property<int?>("UserFavoritesId");

                    b.Property<string>("UserId");

                    b.HasKey("PodcastEpisodeId");

                    b.HasIndex("PodcastChannelId");

                    b.HasIndex("UserFavoritesId");

                    b.HasIndex("UserId");

                    b.ToTable("PodcastEpisode");
                });

            modelBuilder.Entity("Podcaster.Models.Reviews", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("PodcastEpisodeId");

                    b.Property<int>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("PodcastEpisodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Podcaster.Models.Tags", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PodcastEpisodeId");

                    b.Property<string>("Tag");

                    b.HasKey("TagId");

                    b.HasIndex("PodcastEpisodeId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Podcaster.Models.UserFavorites", b =>
                {
                    b.Property<int>("UserFavoritesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("UserFavoritesId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFavorites");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Podcaster.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Podcaster.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Podcaster.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Podcaster.Models.PodcastEpisode", b =>
                {
                    b.HasOne("Podcaster.Models.PodcastChannel", "PodcastChannel")
                        .WithMany("Episodes")
                        .HasForeignKey("PodcastChannelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Podcaster.Models.UserFavorites")
                        .WithMany("Episodes")
                        .HasForeignKey("UserFavoritesId");

                    b.HasOne("Podcaster.Models.ApplicationUser", "User")
                        .WithMany("Episodes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Podcaster.Models.Reviews", b =>
                {
                    b.HasOne("Podcaster.Models.PodcastEpisode", "PodcastEpisode")
                        .WithMany("Reviews")
                        .HasForeignKey("PodcastEpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Podcaster.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Podcaster.Models.Tags", b =>
                {
                    b.HasOne("Podcaster.Models.PodcastEpisode", "Episodes")
                        .WithMany("Tags")
                        .HasForeignKey("PodcastEpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Podcaster.Models.UserFavorites", b =>
                {
                    b.HasOne("Podcaster.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
