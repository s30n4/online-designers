using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OD.DataLayer.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileHobbies_Hobies_HobyId",
                table: "ProfileHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobies",
                table: "Hobies");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "Profile");

            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileHobbies_Hobbies_HobyId",
                table: "ProfileHobbies",
                column: "HobyId",
                principalTable: "Hobies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Projects",
                newSchema: "Core");

            migrationBuilder.RenameTable(
                name: "ProfileSkills",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "ProfileProjects",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "ProfileHobbies",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "ProfileFavorites",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "Hobies",
                newName: "Hobbies",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "Experiences",
                newSchema: "Profile");

            migrationBuilder.RenameTable(
                name: "Skills",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Industries",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "EducationPlaces",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "EducationDegrees",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Countries",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Companies",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Cities",
                newSchema: "Common");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileHobbies_Hobbies_HobyId",
                schema: "Profile",
                table: "ProfileHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                schema: "Profile",
                table: "Hobbies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobies",
                schema: "Profile",
                table: "Hobbies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileHobbies_Hobies_HobyId",
                schema: "Profile",
                table: "ProfileHobbies",
                column: "HobyId",
                principalSchema: "Profile",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Projects",
                schema: "Core");

            migrationBuilder.RenameTable(
                name: "ProfileSkills",
                schema: "Profile");

            migrationBuilder.RenameTable(
                name: "ProfileProjects",
                schema: "Profile");

            migrationBuilder.RenameTable(
                name: "ProfileHobbies",
                schema: "Profile");

            migrationBuilder.RenameTable(
                name: "ProfileFavorites",
                schema: "Profile");

            migrationBuilder.RenameTable(
                name: "Profiles",
                schema: "Profile");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                schema: "Profile",
                newName: "Hobies");

            migrationBuilder.RenameTable(
                name: "Experiences",
                schema: "Profile");

            migrationBuilder.RenameTable(
                name: "Skills",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "Provinces",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "Industries",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "Favorites",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "EducationPlaces",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "EducationDegrees",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "Countries",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "Common");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "Common");
        }
    }
}
