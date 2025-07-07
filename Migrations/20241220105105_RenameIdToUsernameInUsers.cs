using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ML3.Migrations
{
    /// <inheritdoc />
    public partial class RenameIdToUsernameInUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__Learner__67ABFCFA790F756C",
                table: "Learner");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Learner",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Learner",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Learner",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Learner",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "cultural_background",
                table: "Learner",
                newName: "CulturalBackground");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Learner",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Learner",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Learner",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Learner",
                type: "DATE",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Learner",
                table: "Learner",
                column: "LearnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Learner",
                table: "Learner");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Learner",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Learner",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Learner",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Learner",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "CulturalBackground",
                table: "Learner",
                newName: "cultural_background");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Learner",
                newName: "birth_date");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Learner",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Learner",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "birth_date",
                table: "Learner",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "DATE",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learner__67ABFCFA790F756C",
                table: "Learner",
                column: "LearnerID");
        }
    }
}
