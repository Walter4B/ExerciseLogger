using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciseLogger.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "GymId", "Address", "Name" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Jhon's street 124", "Steve's Stoneworks" });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "GymId", "Address", "Name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jhon's street 123", "Jhon's Pumphouse" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Comments", "Duration", "EndTime", "GymId", "StartTime", "Type" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Steve's is excelent for physical.", new TimeSpan(0, 0, 30, 0, 0), new DateTime(2022, 6, 17, 9, 45, 0, 0, DateTimeKind.Unspecified), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 6, 17, 9, 15, 0, 0, DateTimeKind.Unspecified), "Physical" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Comments", "Duration", "EndTime", "GymId", "StartTime", "Type" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Jhon's has a nice view, lacking in equipment but got a good exercise feeling the burn.", new TimeSpan(0, 0, 45, 0, 0), new DateTime(2022, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateTime(2022, 5, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), "Cardio" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseId", "Comments", "Duration", "EndTime", "GymId", "StartTime", "Type" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Steve's is briliant, they have all the equipmnet I need, before I go I will bench 200kg gonna go slow.", new TimeSpan(0, 1, 30, 0, 0), new DateTime(2022, 5, 2, 10, 45, 0, 0, DateTimeKind.Unspecified), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateTime(2022, 5, 2, 9, 15, 0, 0, DateTimeKind.Unspecified), "Strength" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "ExerciseId",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "GymId",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "GymId",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
