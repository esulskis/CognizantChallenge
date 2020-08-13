using CognizantChallenge.Data.Models;
using CognizantChallenge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CognizantChallenge.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1,
                    Name = "Decrement OR Increment",
                    Input = "5",
                    Output = "4"
                ,
                    Description = "Write a program to obtain a number N and increment its value by 1 " +
                "if the number is divisible by 4 otherwise decrement its value by 1."
                },
                new Task
                {
                    Id = 2,
                    Name = "Sum OR Difference",
                    Input = "82\n28",
                    Output = "54",
                    Description = "Write a program to take two numbers as input and print their difference " +
                "if the first number is greater than the second number otherwise print their sum."
                }
            );

  
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "509a4dc6-7cf2-45e5-8016-25da5745840d", Email = "user1@test", UserName = "user1@test",
                    EmailConfirmed = true, ConcurrencyStamp = "f5e8fedf-2ea6-4f8f-90e2-8e63307f25d9", SecurityStamp = "c9638791-b032-418c-8b4c-9c0d86828733"},
                new ApplicationUser { Id = "b299cb75-5c51-40af-9593-a50ba366b5c7", Email = "user2@test", UserName = "user2@test",
                    EmailConfirmed = true, ConcurrencyStamp = "8a166af6-5dbf-4a83-9359-74ed26e1cb1f", SecurityStamp = "072fe3bf-00e4-4c58-b345-cbfe194cad18"},
                new ApplicationUser { Id = "b8d8614a-eef7-409c-8174-6ef96935d47c", Email = "user3@test", UserName = "user3@test",
                    EmailConfirmed = true, ConcurrencyStamp = "3e72920e-b661-45d5-92f0-5787799b6645", SecurityStamp = "a0ef11ed-e2e6-4342-9cc1-a770171cb2bf"}
            );

            var taskSolution1 = @"using System;
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
                            }";
            var taskSolution2 = @"using System;
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
                            }";

            modelBuilder.Entity<UserTaskSolution>().HasData(
                new UserTaskSolution { Id = 1, Solution = taskSolution1, TaskId = 1, UserId = "509a4dc6-7cf2-45e5-8016-25da5745840d" },
                new UserTaskSolution { Id = 2, Solution = taskSolution2, TaskId = 2, UserId = "509a4dc6-7cf2-45e5-8016-25da5745840d" },
                new UserTaskSolution { Id = 3, Solution = taskSolution2, TaskId = 2, UserId = "b299cb75-5c51-40af-9593-a50ba366b5c7" }
                );

        }
    }
}
