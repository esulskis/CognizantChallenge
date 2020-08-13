using Microsoft.EntityFrameworkCore.Migrations;

namespace CognizantChallenge.Data.Migrations
{
    public partial class TopUserView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"  CREATE VIEW dbo.TopUser
                                      AS
	                                    select [user].UserName as [Name], count(1) as TaskCount, STRING_AGG(task.Name,', ') as Tasks
	                                    from AspNetUsers as [user]
	                                    inner join UserTaskSolution as taskSolution on taskSolution.UserId = [user].Id
	                                    inner join Task as task on task.Id = taskSolution.TaskId
	                                    group by [user].UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS dbo.TopUser");
        }
    }
}
