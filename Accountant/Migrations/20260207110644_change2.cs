using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accountant.Migrations
{
    /// <inheritdoc />
    public partial class change2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileAccounts",
                table: "ProfileAccounts");

            migrationBuilder.DropColumn(
                name: "SharesOwed",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Share",
                table: "ProfileAccounts",
                newName: "ShareOwned");

            migrationBuilder.RenameColumn(
                name: "InitialDate",
                table: "Accounts",
                newName: "ActiveMode");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileType",
                table: "Profiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProfileAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ClosedAt",
                table: "Accounts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "OpenedAt",
                table: "Accounts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileAccounts",
                table: "ProfileAccounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProfileAccountId",
                table: "Transactions",
                column: "ProfileAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileAccounts_ProfileId",
                table: "ProfileAccounts",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ProfileAccounts_ProfileAccountId",
                table: "Transactions",
                column: "ProfileAccountId",
                principalTable: "ProfileAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ProfileAccounts_ProfileAccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ProfileAccountId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileAccounts",
                table: "ProfileAccounts");

            migrationBuilder.DropIndex(
                name: "IX_ProfileAccounts_ProfileId",
                table: "ProfileAccounts");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ProfileAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfileAccounts");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OpenedAt",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ShareOwned",
                table: "ProfileAccounts",
                newName: "Share");

            migrationBuilder.RenameColumn(
                name: "ActiveMode",
                table: "Accounts",
                newName: "InitialDate");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SharesOwed",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileType",
                table: "Profiles",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountType",
                table: "Accounts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileAccounts",
                table: "ProfileAccounts",
                columns: new[] { "ProfileId", "AccountId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
