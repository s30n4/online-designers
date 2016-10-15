using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OD.DataLayer;

namespace OD.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161015112209_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<int?>("ProvinceId");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int?>("CityId");

                    b.Property<int?>("CountryId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Mobil");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<int?>("ProvinceId");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Companies","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.ToTable("Countries","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.EducationDegree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("EducationDegrees","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.EducationPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("EducationPlaces","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.ToTable("Favorites","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Industry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.ToTable("Industries","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.ToTable("Skills","Common");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 75);

                    b.Property<int?>("ProfileId");

                    b.Property<DateTime?>("StarDate");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Experiences","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.Hobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 75);

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.ToTable("Hobbies","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int?>("CityId");

                    b.Property<int?>("CountryId");

                    b.Property<string>("DisplayName")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int?>("EducationDegreeId");

                    b.Property<int?>("EducationPlaceId");

                    b.Property<int?>("IndustryId");

                    b.Property<string>("JobHeadline")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int?>("ProvinceId");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("EducationDegreeId");

                    b.HasIndex("EducationPlaceId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Profiles","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileFavorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FavoriteId");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileFavorites","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileHobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HobyId");

                    b.Property<int?>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("HobyId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileHobbies","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProfileId");

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProfileProjects","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProfileId");

                    b.Property<int?>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("SkillId");

                    b.ToTable("ProfileSkills","Profile");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Project.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Projects","Core");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.UM.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BannedDate");

                    b.Property<string>("BannedReason")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("DisplayName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsBanned");

                    b.Property<DateTime?>("LastActivityOn");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<DateTime?>("LastPasswordChangedDate");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.ToTable("Users","UM");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.UM.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<string>("Agent");

                    b.Property<string>("Description");

                    b.Property<string>("Entity");

                    b.Property<string>("EntityId");

                    b.Property<string>("NewValue");

                    b.Property<string>("OldValue");

                    b.Property<int>("OperantId");

                    b.Property<Guid?>("OperantId1");

                    b.Property<string>("OperantIp");

                    b.Property<DateTime>("OperatedOn");

                    b.HasKey("Id");

                    b.HasIndex("OperantId1");

                    b.ToTable("AuditLogs","UM");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.UM.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AccessTokenExpirationDateTime");

                    b.Property<string>("AccessTokenHash");

                    b.Property<int>("OwnerUserId");

                    b.Property<Guid?>("OwnerUserId1");

                    b.Property<string>("RefreshToken");

                    b.Property<DateTime>("RefreshTokenExpiresUtc");

                    b.Property<string>("RefreshTokenIdHash");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId1");

                    b.ToTable("UserTokens","UM");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.City", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Common.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Company", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Common.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("OD.DomainClasses.Entities.Common.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("OD.DomainClasses.Entities.Common.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Common.Province", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Common.Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.Experience", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Profile.Profile")
                        .WithMany("Experiences")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.Profile", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Common.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("OD.DomainClasses.Entities.Common.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("OD.DomainClasses.Entities.Common.EducationDegree", "EducationDegree")
                        .WithMany()
                        .HasForeignKey("EducationDegreeId");

                    b.HasOne("OD.DomainClasses.Entities.Common.EducationPlace", "EducationPlace")
                        .WithMany()
                        .HasForeignKey("EducationPlaceId");

                    b.HasOne("OD.DomainClasses.Entities.Common.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("OD.DomainClasses.Entities.Common.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileFavorite", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Common.Favorite", "Favorite")
                        .WithMany()
                        .HasForeignKey("FavoriteId");

                    b.HasOne("OD.DomainClasses.Entities.Profile.Profile", "Profile")
                        .WithMany("Favorites")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileHobby", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Profile.Hobby", "Hoby")
                        .WithMany()
                        .HasForeignKey("HobyId");

                    b.HasOne("OD.DomainClasses.Entities.Profile.Profile", "Profile")
                        .WithMany("Hobbies")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileProject", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Profile.Profile", "Profile")
                        .WithMany("Projects")
                        .HasForeignKey("ProfileId");

                    b.HasOne("OD.DomainClasses.Entities.Project.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.Profile.ProfileSkill", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.Profile.Profile", "Profile")
                        .WithMany("Skills")
                        .HasForeignKey("ProfileId");

                    b.HasOne("OD.DomainClasses.Entities.Common.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.UM.AuditLog", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.UM.ApplicationUser", "Operant")
                        .WithMany("AuditLogs")
                        .HasForeignKey("OperantId1");
                });

            modelBuilder.Entity("OD.DomainClasses.Entities.UM.UserToken", b =>
                {
                    b.HasOne("OD.DomainClasses.Entities.UM.ApplicationUser", "OwnerUser")
                        .WithMany("UserTokens")
                        .HasForeignKey("OwnerUserId1");
                });
        }
    }
}
