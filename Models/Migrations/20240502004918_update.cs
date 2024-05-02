using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormationUserApplier_Formation_FormationsId",
                table: "FormationUserApplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formation",
                table: "Formation");

            migrationBuilder.RenameTable(
                name: "Formation",
                newName: "Formations");

            migrationBuilder.AlterColumn<string>(
                name: "HomeLocation",
                table: "UserAppliers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserAppliers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formations",
                table: "Formations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormationUserApplier_Formations_FormationsId",
                table: "FormationUserApplier",
                column: "FormationsId",
                principalTable: "Formations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormationUserApplier_Formations_FormationsId",
                table: "FormationUserApplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formations",
                table: "Formations");

            migrationBuilder.RenameTable(
                name: "Formations",
                newName: "Formation");

            migrationBuilder.AlterColumn<string>(
                name: "HomeLocation",
                table: "UserAppliers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserAppliers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formation",
                table: "Formation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormationUserApplier_Formation_FormationsId",
                table: "FormationUserApplier",
                column: "FormationsId",
                principalTable: "Formation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
