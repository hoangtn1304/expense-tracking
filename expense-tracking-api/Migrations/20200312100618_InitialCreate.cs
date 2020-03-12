using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace expense_tracking_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    CurrencyRegionName = table.Column<string>(nullable: true),
                    UseDarkMode = table.Column<bool>(nullable: false),
                    Hash = table.Column<byte[]>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Budget = table.Column<decimal>(nullable: false),
                    ColourHex = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Archived", "CreatedAt", "CurrencyRegionName", "Email", "FirstName", "FullName", "Hash", "LastName", "Salt", "SystemName", "UpdatedAt", "UseDarkMode" },
                values: new object[] { 1, false, new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), "GB", "test@demo.com", "John", "John Doe", new byte[] { 224, 46, 239, 166, 183, 247, 85, 46, 113, 59, 177, 68, 225, 13, 137, 96, 5, 103, 133, 178, 202, 210, 168, 36, 27, 172, 3, 38, 94, 208, 147, 31, 126, 160, 160, 216, 224, 13, 86, 61, 203, 70, 36, 22, 235, 54, 54, 61, 243, 54, 223, 232, 229, 89, 151, 20, 245, 72, 125, 10, 164, 118, 243, 111 }, "Doe", new byte[] { 242, 145, 184, 17, 205, 96, 169, 75, 182, 214, 192, 195, 132, 197, 211, 239 }, "VueExpenses", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), true });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Archived", "Budget", "ColourHex", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 1, false, 2000m, "#CE93D8", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "General Expenses", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Archived", "Budget", "ColourHex", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 2, false, 3000m, "#64B5F6", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Shopping", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Archived", "Budget", "ColourHex", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 3, false, 2500m, "#26A69A", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Utilities", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Archived", "Budget", "ColourHex", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 4, false, 1000m, "#FB8C00", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Travel", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Archived", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 1, false, new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Credit Card", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Archived", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 2, false, new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Debit Card", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Archived", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 3, false, new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Cheque", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Archived", "CreatedAt", "Description", "Name", "UpdatedAt", "UserId" },
                values: new object[] { 4, false, new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), null, "Cash", new DateTime(2020, 3, 12, 17, 6, 17, 784, DateTimeKind.Local).AddTicks(9793), 1 });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 2, false, 4, null, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 976.278912497814m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 20, false, 4, null, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1271.15897823645m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 17, false, 3, null, new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 935.645428921862m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 15, false, 3, null, new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1318.55821181953m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 6, false, 2, null, new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1369.05760265377m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 5, false, 2, null, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 839.149465709529m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 4, false, 3, null, new DateTime(2019, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 962.752318690881m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 3, false, 3, null, new DateTime(2019, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1464.65129589879m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 21, false, 3, null, new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1285.51300628368m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 18, false, 2, null, new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1409.91363833189m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 14, false, 4, null, new DateTime(2019, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 682.669731174908m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 13, false, 4, null, new DateTime(2019, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 146.690046715871m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 12, false, 4, null, new DateTime(2019, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1475.49262827984m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 8, false, 3, null, new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 672.269969327501m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 1, false, 2, null, new DateTime(2019, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1397.64575702029m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 24, false, 4, null, new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 967.260428921906m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 19, false, 3, null, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 999.938646797062m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 16, false, 3, null, new DateTime(2019, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1371.84388626918m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 11, false, 2, null, new DateTime(2019, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1376.06823974106m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 10, false, 3, null, new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 839.217063663163m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 9, false, 3, null, new DateTime(2019, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 882.588345735608m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 7, false, 4, null, new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 350.904874201354m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 22, false, 3, null, new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1076.70254403572m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Archived", "CategoryId", "Comments", "CreatedAt", "Date", "TypeId", "UpdatedAt", "UserId", "Value" },
                values: new object[] { 23, false, 4, null, new DateTime(2019, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1119.4886582063m });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_UserId",
                table: "ExpenseCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeId",
                table: "Expenses",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_UserId",
                table: "ExpenseTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
