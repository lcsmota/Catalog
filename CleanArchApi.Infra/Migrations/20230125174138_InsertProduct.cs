using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchApi.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InsertProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO 
                    Products(Name, Description, Price, Stock, Image, CategoryId) 
                VALUES('Notebook', 'Notebook 100 pages', 8.55, 22, 'notebook.jpg', 1)");

            migrationBuilder.Sql(@"
                INSERT INTO 
                    Products(Name, Description, Price, Stock, Image, CategoryId) 
                VALUES('Pencil', 'Pencil T Large', 3.55, 12, 'pencil.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
