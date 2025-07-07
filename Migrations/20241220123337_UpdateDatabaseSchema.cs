using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ML3.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__LearnersG__GoalI__04E4BC85",
                table: "LearnersGoals");

            migrationBuilder.DropForeignKey(
                name: "FK__LearnersG__Learn__05D8E0BE",
                table: "LearnersGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__3C3540FE3C198A0C",
                table: "LearnersGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__3214EC27E7E331DF",
                table: "Learning_goal");

            migrationBuilder.RenameTable(
                name: "Learning_goal",
                newName: "LearningGoal");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "LearningGoal",
                type: "varchar(1000)",
                unicode: false,
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "LearningGoal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learners_3C3540FE3C198A0C",
                table: "LearnersGoals",
                columns: new[] { "GoalID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learning_3214EC27E7E331DF",
                table: "LearningGoal",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnersGGoalI_04E4BC85",
                table: "LearnersGoals",
                column: "GoalID",
                principalTable: "LearningGoal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LearnersGLearn_05D8E0BE",
                table: "LearnersGoals",
                column: "LearnerID",
                principalTable: "Learner",
                principalColumn: "LearnerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearnersGGoalI_04E4BC85",
                table: "LearnersGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnersGLearn_05D8E0BE",
                table: "LearnersGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Learners_3C3540FE3C198A0C",
                table: "LearnersGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Learning_3214EC27E7E331DF",
                table: "LearningGoal");

            migrationBuilder.RenameTable(
                name: "LearningGoal",
                newName: "Learning_goal");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Learning_goal",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldUnicode: false,
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "deadline",
                table: "Learning_goal",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__3C3540FE3C198A0C",
                table: "LearnersGoals",
                columns: new[] { "GoalID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__3214EC27E7E331DF",
                table: "Learning_goal",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__LearnersG__GoalI__04E4BC85",
                table: "LearnersGoals",
                column: "GoalID",
                principalTable: "Learning_goal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__LearnersG__Learn__05D8E0BE",
                table: "LearnersGoals",
                column: "LearnerID",
                principalTable: "Learner",
                principalColumn: "LearnerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
