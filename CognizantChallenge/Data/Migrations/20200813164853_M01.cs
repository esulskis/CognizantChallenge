using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantChallenge.Data.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Input = table.Column<string>(maxLength: 50, nullable: true),
                    Output = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskSolution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Solution = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskSolution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTaskSolution_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskSolution_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "509a4dc6-7cf2-45e5-8016-25da5745840d", 0, "f5e8fedf-2ea6-4f8f-90e2-8e63307f25d9", "user1@test", true, false, null, null, null, null, null, false, "c9638791-b032-418c-8b4c-9c0d86828733", false, "user1@test" },
                    { "b299cb75-5c51-40af-9593-a50ba366b5c7", 0, "8a166af6-5dbf-4a83-9359-74ed26e1cb1f", "user2@test", true, false, null, null, null, null, null, false, "072fe3bf-00e4-4c58-b345-cbfe194cad18", false, "user2@test" },
                    { "b8d8614a-eef7-409c-8174-6ef96935d47c", 0, "3e72920e-b661-45d5-92f0-5787799b6645", "user3@test", true, false, null, null, null, null, null, false, "a0ef11ed-e2e6-4342-9cc1-a770171cb2bf", false, "user3@test" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Input", "Name", "Output" },
                values: new object[,]
                {
                    { 1, "Write a program to obtain a number N and increment its value by 1 if the number is divisible by 4 otherwise decrement its value by 1.", "5", "Decrement OR Increment", "4" },
                    { 2, "Write a program to take two numbers as input and print their difference if the first number is greater than the second number otherwise print their sum.", @"82
                28", "Sum OR Difference", "54" }
                });

            migrationBuilder.InsertData(
                table: "UserTaskSolution",
                columns: new[] { "Id", "Solution", "TaskId", "UserId" },
                values: new object[] { 1, @"using System;
                            namespace Rextester
                            {
                                public class Program
                                {
                                    public static void Main(string[] args)
                                    {
                                        int input = int.Parse(Console.ReadLine());
                                        Console.WriteLine(input % 4 == 0 ? ++input : --input);
                                    }
                                }
                            }", 1, "509a4dc6-7cf2-45e5-8016-25da5745840d" });

            migrationBuilder.InsertData(
                table: "UserTaskSolution",
                columns: new[] { "Id", "Solution", "TaskId", "UserId" },
                values: new object[] { 2, @"using System;
                            namespace Rextester
                            {
                                public class Program
                                {
                                    public static void Main(string[] args)
                                    {
                                        var firstInput = Convert.ToInt32(Console.ReadLine());
                                        var secondInput = Convert.ToInt32(Console.ReadLine());
                                        if (firstInput > secondInput)
		                                {
		                                    Console.WriteLine(firstInput - secondInput);
                                        }
                                        else
                                        {
                                            Console.WriteLine(firstInput + secondInput);
                                        }
                                    }
                                }
                            }", 2, "509a4dc6-7cf2-45e5-8016-25da5745840d" });

            migrationBuilder.InsertData(
                table: "UserTaskSolution",
                columns: new[] { "Id", "Solution", "TaskId", "UserId" },
                values: new object[] { 3, @"using System;
                            namespace Rextester
                            {
                                public class Program
                                {
                                    public static void Main(string[] args)
                                    {
                                        var firstInput = Convert.ToInt32(Console.ReadLine());
                                        var secondInput = Convert.ToInt32(Console.ReadLine());
                                        if (firstInput > secondInput)
		                                {
		                                    Console.WriteLine(firstInput - secondInput);
                                        }
                                        else
                                        {
                                            Console.WriteLine(firstInput + secondInput);
                                        }
                                    }
                                }
                            }", 2, "b299cb75-5c51-40af-9593-a50ba366b5c7" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskSolution_TaskId",
                table: "UserTaskSolution",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskSolution_UserId",
                table: "UserTaskSolution",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTaskSolution");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "509a4dc6-7cf2-45e5-8016-25da5745840d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b299cb75-5c51-40af-9593-a50ba366b5c7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8d8614a-eef7-409c-8174-6ef96935d47c");
        }
    }
}
