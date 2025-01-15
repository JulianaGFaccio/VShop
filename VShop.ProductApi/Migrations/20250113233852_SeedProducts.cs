using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" + 
                "Values('Caderno', 7.55, 'CAderno' , 10, 'Caderno.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                "Values('Estojo', 7.55, 'Estojo' , 10, 'Estojo.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                "Values('Lapis', 7.55, 'Lapis' , 10, 'Lapis.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
