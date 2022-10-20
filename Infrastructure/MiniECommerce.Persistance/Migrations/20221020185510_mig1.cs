using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MiniECommerce.Persistance.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    IncorrectEntry = table.Column<short>(type: "smallint", nullable: true),
                    IsLock = table.Column<bool>(type: "boolean", nullable: true),
                    ActivationCode = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    LastActivty = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Category_Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Color_Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    AppUserID = table.Column<int>(type: "integer", nullable: true),
                    ProductID = table.Column<int>(type: "integer", nullable: true),
                    Product_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Product_Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsOfferable = table.Column<bool>(type: "boolean", nullable: true),
                    IsSold = table.Column<bool>(type: "boolean", nullable: true),
                    UsageStatus = table.Column<int>(type: "integer", nullable: true),
                    CategoryID = table.Column<int>(type: "integer", nullable: true),
                    BrandID = table.Column<int>(type: "integer", nullable: true),
                    ColorID = table.Column<int>(type: "integer", nullable: true),
                    Product_AppUserID = table.Column<int>(type: "integer", nullable: true),
                    Role_Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_BrandID",
                        column: x => x.BrandID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_ColorID",
                        column: x => x.ColorID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Product_AppUserID",
                        column: x => x.Product_AppUserID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_ProductID",
                        column: x => x.ProductID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    AppUserID = table.Column<int>(type: "integer", nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    ID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.RoleID, x.AppUserID });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_BaseEntity_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_BaseEntity_RoleID",
                        column: x => x.RoleID,
                        principalTable: "BaseEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppUserID",
                table: "AppUserRoles",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_AppUserID",
                table: "BaseEntity",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_BrandID",
                table: "BaseEntity",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CategoryID",
                table: "BaseEntity",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ColorID",
                table: "BaseEntity",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Product_AppUserID",
                table: "BaseEntity",
                column: "Product_AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ProductID",
                table: "BaseEntity",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
