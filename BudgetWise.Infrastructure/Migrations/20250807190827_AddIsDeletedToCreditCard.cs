using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetWise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToCreditCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CreditCards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CreditCards");
        }
    }
}
