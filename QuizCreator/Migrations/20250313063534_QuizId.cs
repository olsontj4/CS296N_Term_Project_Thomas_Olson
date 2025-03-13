using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizCreator.Migrations
{
    /// <inheritdoc />
    public partial class QuizId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A_Question_QuestionId",
                table: "A");

            migrationBuilder.DropForeignKey(
                name: "FK_AKey_Question_QuestionId",
                table: "AKey");

            migrationBuilder.DropForeignKey(
                name: "FK_EndResultsMessage_EndResult_EndResultId",
                table: "EndResultsMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_EndResultsTitle_EndResult_EndResultId",
                table: "EndResultsTitle");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quizzes_QuizId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_EndResult_EndResultId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_EndResultId",
                table: "Quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndResult",
                table: "EndResult");

            migrationBuilder.DropColumn(
                name: "EndResultId",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quizzes",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Question",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EndResultsTitle",
                newName: "EndResultsTitleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EndResultsMessage",
                newName: "EndResultsMessageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EndResult",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AKey",
                newName: "AKeyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "A",
                newName: "AId");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EndResultId",
                table: "EndResultsTitle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EndResultId",
                table: "EndResultsMessage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "EndResult",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "EndResultId",
                table: "EndResult",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "AKey",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "A",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndResult",
                table: "EndResult",
                column: "EndResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EndResult_QuizId",
                table: "EndResult",
                column: "QuizId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_A_Question_QuestionId",
                table: "A",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AKey_Question_QuestionId",
                table: "AKey",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndResult_Quizzes_QuizId",
                table: "EndResult",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndResultsMessage_EndResult_EndResultId",
                table: "EndResultsMessage",
                column: "EndResultId",
                principalTable: "EndResult",
                principalColumn: "EndResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndResultsTitle_EndResult_EndResultId",
                table: "EndResultsTitle",
                column: "EndResultId",
                principalTable: "EndResult",
                principalColumn: "EndResultId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quizzes_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A_Question_QuestionId",
                table: "A");

            migrationBuilder.DropForeignKey(
                name: "FK_AKey_Question_QuestionId",
                table: "AKey");

            migrationBuilder.DropForeignKey(
                name: "FK_EndResult_Quizzes_QuizId",
                table: "EndResult");

            migrationBuilder.DropForeignKey(
                name: "FK_EndResultsMessage_EndResult_EndResultId",
                table: "EndResultsMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_EndResultsTitle_EndResult_EndResultId",
                table: "EndResultsTitle");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quizzes_QuizId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndResult",
                table: "EndResult");

            migrationBuilder.DropIndex(
                name: "IX_EndResult_QuizId",
                table: "EndResult");

            migrationBuilder.DropColumn(
                name: "EndResultId",
                table: "EndResult");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Quizzes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EndResultsTitleId",
                table: "EndResultsTitle",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EndResultsMessageId",
                table: "EndResultsMessage",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "EndResult",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AKeyId",
                table: "AKey",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AId",
                table: "A",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "EndResultId",
                table: "Quizzes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EndResultId",
                table: "EndResultsTitle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EndResultId",
                table: "EndResultsMessage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EndResult",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "AKey",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "A",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndResult",
                table: "EndResult",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_EndResultId",
                table: "Quizzes",
                column: "EndResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_A_Question_QuestionId",
                table: "A",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AKey_Question_QuestionId",
                table: "AKey",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndResultsMessage_EndResult_EndResultId",
                table: "EndResultsMessage",
                column: "EndResultId",
                principalTable: "EndResult",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndResultsTitle_EndResult_EndResultId",
                table: "EndResultsTitle",
                column: "EndResultId",
                principalTable: "EndResult",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quizzes_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_EndResult_EndResultId",
                table: "Quizzes",
                column: "EndResultId",
                principalTable: "EndResult",
                principalColumn: "Id");
        }
    }
}
