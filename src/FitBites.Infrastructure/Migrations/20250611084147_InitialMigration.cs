using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitBites.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CookingMethodDicts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingMethodDicts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CuisineDicts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineDicts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HumanGroupDicts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanGroupDicts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientNutritionDicts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutritionDicts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    WaterContent = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlavorProfile = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainFunctions = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CookingBehavior = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreferredUsage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Volatile = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealTimeDicts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTimeDicts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PermissionCode = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Module = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleCode = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TasteDicts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasteDicts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserCode = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nickname = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpireTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientHumanGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IngredientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Effect = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HumanGroupDictId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientHumanGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientHumanGroups_HumanGroupDicts_GroupId",
                        column: x => x.GroupId,
                        principalTable: "HumanGroupDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientHumanGroups_HumanGroupDicts_HumanGroupDictId",
                        column: x => x.HumanGroupDictId,
                        principalTable: "HumanGroupDicts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngredientHumanGroups_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientNutritions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IngredientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NutrientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PerUnit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNutritions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientNutritions_IngredientNutritionDicts_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "IngredientNutritionDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientNutritions_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientPreprocesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IngredientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DurationSec = table.Column<int>(type: "int", nullable: true),
                    TemperatureDesc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPreprocesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientPreprocesses_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientPreprocesses_Ingredients_IngredientId1",
                        column: x => x.IngredientId1,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuisineId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CookingMethodId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TasteId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: true),
                    CookTime = table.Column<int>(type: "int", nullable: true),
                    Servings = table.Column<int>(type: "int", nullable: true),
                    Recommended = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_CookingMethodDicts_CookingMethodId",
                        column: x => x.CookingMethodId,
                        principalTable: "CookingMethodDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_CuisineDicts_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "CuisineDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_TasteDicts_TasteId",
                        column: x => x.TasteId,
                        principalTable: "TasteDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FamilyCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Families_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermissionMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ObjectType = table.Column<int>(type: "int", nullable: false),
                    ObjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PermissionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ExpireTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionMappings_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    // table.ForeignKey(
                    //     name: "FK_PermissionMappings_Roles_ObjectId",
                    //     column: x => x.ObjectId,
                    //     principalTable: "Roles",
                    //     principalColumn: "Id");
                    // table.ForeignKey(
                    //     name: "FK_PermissionMappings_Users_ObjectId",
                    //     column: x => x.ObjectId,
                    //     principalTable: "Users",
                    //     principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserHumanGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GroupId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Source = table.Column<int>(type: "int", nullable: true),
                    Confidence = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHumanGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHumanGroups_HumanGroupDicts_GroupId",
                        column: x => x.GroupId,
                        principalTable: "HumanGroupDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHumanGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TargetType = table.Column<int>(type: "int", nullable: false),
                    TargetId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PreferenceType = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecipeCookingSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientRefs = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DurationSec = table.Column<int>(type: "int", nullable: true),
                    TemperatureDesc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WaitTimeSec = table.Column<int>(type: "int", nullable: true),
                    IsOptional = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AiInstruction = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCookingSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCookingSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IngredientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessMethod = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsageMethod = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientWeight = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsageOrder = table.Column<int>(type: "int", nullable: true),
                    PostProcessImage = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsKeyIngredient = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId1",
                        column: x => x.IngredientId1,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FamilyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MemberRole = table.Column<int>(type: "int", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeeklyMealPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PlanCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FamilyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatorUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FamilyId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserId2 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyMealPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyMealPlans_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyMealPlans_Families_FamilyId1",
                        column: x => x.FamilyId1,
                        principalTable: "Families",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeeklyMealPlans_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyMealPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyMealPlans_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeeklyMealPlans_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealPlanDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MealPlanId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    MealTimeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Servings = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanDetails_MealTimeDicts_MealTimeId",
                        column: x => x.MealTimeId,
                        principalTable: "MealTimeDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanDetails_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanDetails_WeeklyMealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "WeeklyMealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealPlanNutritions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MealPlanId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NutrientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Unit = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientNutritionDictId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanNutritions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanNutritions_IngredientNutritionDicts_IngredientNutrit~",
                        column: x => x.IngredientNutritionDictId,
                        principalTable: "IngredientNutritionDicts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealPlanNutritions_IngredientNutritionDicts_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "IngredientNutritionDicts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanNutritions_WeeklyMealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "WeeklyMealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealPlanOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MealPlanId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RecipeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanOrders_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanOrders_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MealPlanOrders_WeeklyMealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "WeeklyMealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CookingMethodDicts",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "Name", "SortOrder", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), "FRY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "快速翻炒烹饪方式", "炒", 1, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff2"), "STEAM", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "蒸汽加热烹饪方式", "蒸", 2, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), "BOIL", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "水煮烹饪方式", "煮", 3, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff4"), "STEW", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "慢火长时间烹饪方式", "炖", 4, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff5"), "DEEP_FRY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "油炸烹饪方式", "炸", 5, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff6"), "BAKE", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "烤箱烹饪方式", "烤", 6, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff7"), "SAUTE", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "小火煎制烹饪方式", "煎", 7, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), "BRAISE", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "加盖闷煮烹饪方式", "焖", 8, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff9"), "COLD_DISH", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "不需加热直接食用的烹饪方式", "冷菜", 9, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bffa"), "FERMENT", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "通过微生物作用发酵制作的烹饪方式", "发酵", 10, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CuisineDicts",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "Name", "SortOrder", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "SICHUAN", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "四川菜系，特点是麻辣鲜香", "川菜", 1, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "CANTONESE", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "广东菜系，特点是清淡鲜美", "粤菜", 2, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "SHANDONG", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "山东菜系，特点是咸鲜为主", "鲁菜", 3, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff4"), "JIANGSU", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "江苏菜系，特点是清鲜甘醇", "苏菜", 4, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff5"), "ZHEJIANG", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "浙江菜系，特点是鲜嫩脆爽", "浙菜", 5, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff6"), "ANHUI", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "安徽菜系，特点是注重火功", "徽菜", 6, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff7"), "FUJIAN", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "福建菜系，特点是清鲜、和、精", "闽菜", 7, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff8"), "HUNAN", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "湖南菜系，特点是香辣酸", "湘菜", 8, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff9"), "WESTERN", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "西方国家菜系", "西餐", 9, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cffa"), "JAPANESE", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "日本料理", "日料", 10, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66cffb"), "KOREAN", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "韩国料理", "韩餐", 11, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HumanGroupDicts",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "怀孕期间的女性", "孕妇", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "哺乳期间的女性", "哺乳期", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3岁以下儿童", "婴幼儿", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb4"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3-12岁儿童", "儿童", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "65岁以上老年人", "老人", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "糖尿病患者", "糖尿病", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "高血压患者", "高血压", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "高血脂患者", "高血脂", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "IngredientNutritionDicts",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的热量，表示为千卡", "能量", "kcal", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的蛋白质总量", "蛋白质", "g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的脂肪总量", "脂肪", "g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd4"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的碳水化合物总量", "碳水化合物", "g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的膳食纤维总量", "膳食纤维", "g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的维生素A总量", "维生素A", "μg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的维生素C总量", "维生素C", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的维生素E总量", "维生素E", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的钙元素总量", "钙", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afe1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的铁元素总量", "铁", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afe2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的锌元素总量", "锌", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afe3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的钾元素总量", "钾", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afe4"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "食物中所含的钠元素总量", "钠", "mg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Category", "CookingBehavior", "CreatedAt", "FlavorProfile", "MainFunctions", "Name", "Notes", "PreferredUsage", "UpdatedAt", "Volatile", "WaterContent" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), 0, "易熟易老", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜味", "提供优质蛋白质", "鸡胸肉", "优质蛋白质来源，低脂肪", "切片,切丁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), 1, "易碎,吸味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清淡", "提供植物蛋白", "豆腐", "富含植物蛋白和钙质", "切块,炸,烫", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa03"), 2, "爆炒保脆", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "微辣,清香", "提供维生素C", "青椒", "富含维生素C和抗氧化物质", "切丝,切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa04"), 4, "爆香", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "辛辣", "去腥,提香", "姜", "常用于提味和去腥", "切片,切丝,切末", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa05"), 4, "爆香", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "辛辣", "提香,增味", "蒜", "常用于提味和增香", "切片,切末,压泥", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa06"), 4, "易糊", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "咸鲜", "调味,上色", "酱油", "提供咸鲜味和褐色", "调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa07"), 4, "增强口感", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "咸", "调味", "盐", "基础调味品", "调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "极低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), 5, "爽脆,吸味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清香", "补血,清肠", "木耳", "富含膳食纤维和铁质", "泡发,切碎", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低(干品), 高(泡发后)" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), 0, "纤维感强,需要煮烂", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供优质蛋白质和铁质", "牛肉", "富含优质蛋白质和铁质，有助于补血", "切片,切丁,切条", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa10"), 0, "油脂较多", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜甜", "提供蛋白质和脂肪", "猪肉", "常见肉类，口感滑嫩", "切片,切丝,剁馅", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa11"), 0, "需要长时间烹煮才够酥烂", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "肥美", "提供丰富脂肪和蛋白质", "五花肉", "肥瘦相间，适合红烧、扣肉等", "切片,切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "极低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa12"), 0, "肉质细嫩,需去膻", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "膻香", "提供蛋白质和维生素", "羊肉", "温补食材，冬季常食", "切片,切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa13"), 0, "肉质较韧,需适当烹煮", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供蛋白质和脂肪", "鸭肉", "肉质细嫩，脂肪含量适中", "切块,切片", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa14"), 7, "肉质脆嫩,易碎", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供优质蛋白质和不饱和脂肪酸", "鱼肉", "富含蛋白质和DHA，有益健康", "片,切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa15"), 7, "肉质爽脆,易熟", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜甜", "提供优质蛋白质和矿物质", "虾", "富含蛋白质，口感鲜甜", "去壳,拍扁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa16"), 7, "需要适当处理", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜美", "提供优质蛋白质", "螃蟹", "鲜美海鲜，富含蛋白质", "清洗,去壳", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), 2, "吸油,易软烂", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清淡", "提供膳食纤维", "茄子", "质地柔软，吸味能力强", "切块,切条", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), 2, "煮熟才可食用", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清淡微甜", "提供碳水化合物和维生素C", "土豆", "富含淀粉，可作主食或配菜", "切丝,切片,切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa19"), 2, "脆嫩多汁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清爽", "补水,提供膳食纤维", "黄瓜", "水分充足，适合生食凉拌", "切片,切条,拍碎", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "极高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa20"), 2, "多汁,酸甜", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "酸甜", "提供维生素C和番茄红素", "西红柿", "富含番茄红素，有抗氧化作用", "切片,切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa21"), 2, "香味浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "独特香气", "提供膳食纤维和维生素", "韭菜", "香气浓郁，常与鸡蛋同炒", "切段", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa22"), 4, "香味浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "辛香", "提香,增味", "葱", "常用调味品，提香去腥", "切段,切丝,切花", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa23"), 11, "熟制方式多样", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供优质蛋白质", "鸡蛋", "营养丰富，烹饪方式多样", "打散,煎,蒸", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa24"), 6, "口感柔软", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "淡香", "提供碳水化合物", "米饭", "主食，可做多种米饭料理", "蒸熟,炒", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa25"), 6, "韧性好", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "麦香", "提供碳水化合物", "面条", "多种烹饪方式，可做汤面或炒面", "煮,炒,拌", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa26"), 4, "麻味强烈", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "麻香", "增香,提味", "花椒", "川菜常用调料，有独特麻味", "炒香,研磨", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "极低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa27"), 4, "辣味浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "辣", "增辣,提色", "干辣椒", "增添菜品辣味和红色", "切段,泡发,炒香", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "极低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa28"), 5, "鲜香味浓", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供膳食纤维和蛋白质", "香菇", "菌类食材，风味独特", "切片,切丁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa29"), 2, "爽脆清香", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清香", "提供维生素和膳食纤维", "西兰花", "富含维生素C和膳食纤维", "切小朵", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa30"), 2, "质地柔嫩", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清香", "提供膳食纤维和维生素", "油菜", "叶绿菜，营养丰富易消化", "切段", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa31"), 2, "脆嫩多孔", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清甜", "提供淀粉和膳食纤维", "莲藕", "爽脆可口，可凉拌或炖煮", "切片,切丁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa32"), 0, "骨肉相连", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供蛋白质和钙质", "排骨", "肉质鲜嫩，骨髓丰富", "切段", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa33"), 7, "肉多刺多", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜美", "提供蛋白质和胶原蛋白", "鱼头", "肉质鲜嫩，适合炖煮或蒸制", "切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa34"), 2, "咸味浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "咸香", "提供膳食纤维", "梅菜", "腌制蔬菜，咸香可口", "泡发,切碎", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa35"), 2, "需煮熟食用", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清香", "提供膳食纤维和蛋白质", "四季豆", "含植物蛋白，煮熟后食用", "切段,去筋", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa36"), 0, "脆嫩爽口", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜香", "提供蛋白质", "鸭肠", "脆嫩有弹性，口感独特", "清洗,切段", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa37"), 2, "酸味浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "酸爽", "提供益生菌和膳食纤维", "酸菜", "发酵蔬菜，酸爽开胃", "切段,挤干", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa38"), 6, "柔滑爽口", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "米香", "提供碳水化合物", "河粉", "宽扁米粉，口感滑爽", "焯水,炒", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa39"), 4, "香味独特", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清香", "提香,去腥", "香茅", "泰国料理常用香料", "切段,拍松", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa40"), 4, "香气浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清香", "提香,增味", "柠檬叶", "泰国料理常用香料，柑橘香气", "切片,整叶", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa41"), 2, "口感柔嫩", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清甜", "提供膳食纤维和维生素", "白菜", "常见蔬菜，可炒可煮可腌制", "切段,切片", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa42"), 2, "脆嫩多水", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "清爽", "提供膳食纤维和维生素", "生菜", "多水脆嫩，常用于沙拉", "撕片,整叶", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "极高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa43"), 0, "纤维较多,需炖煮", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "浓香", "提供蛋白质和胶原蛋白", "牛腩", "肉质紧实，需长时间炖煮", "切块", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa44"), 4, "浓稠鲜香", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜咸", "提鲜,增香", "蚝油", "浓稠酱料，增添鲜味", "调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa45"), 4, "辣味浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "辣咸", "增辣,提味", "剁椒", "湖南特色调味品，辣咸开胃", "调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa46"), 4, "香气独特", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "香辣", "增香,提味", "孜然", "西北风味调料，香气特殊", "研磨,撒面", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "极低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa47"), 4, "酸甜平衡", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "酸甜", "调味,提鲜", "寿司醋", "制作寿司的专用调味料", "调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "中" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa48"), 7, "薄脆", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "海鲜香", "包裹,装饰", "海苔", "日本料理常用食材", "切片,整片", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "高" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa49"), 1, "质地筋道", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "豆香", "提供植物蛋白", "腐竹", "富含植物蛋白，口感筋道", "泡发,切段", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "低" },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa50"), 8, "香气浓郁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "香浓", "增香,装饰", "芝麻", "增添香气和装饰效果", "炒香,研磨", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "极低" }
                });

            migrationBuilder.InsertData(
                table: "MealTimeDicts",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "BREAKFAST", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "上午7-9点食用，提供一天活力的开始", "早餐", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), "LUNCH", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "中午11-13点食用，提供一天主要能量来源", "午餐", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), "DINNER", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "晚上17-19点食用，提供睡前必要营养", "晚餐", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9"), "SNACK", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "两餐之间的少量食物补充", "加餐", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "Module", "PermissionCode", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e001"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "系统管理权限", "系统管理", "system.manage", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e002"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "创建基础数量菜式（20个）", "菜式管理", "recipe.create.basic", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e003"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "创建高级数量菜式（50个）", "菜式管理", "recipe.create.advanced", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e004"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "创建最近两周的菜谱", "菜谱管理", "recipe.timerange.twoweeks", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e005"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "创建最近两个月的菜谱", "菜谱管理", "recipe.timerange.twomonths", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e006"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "最多加入一个家庭", "家庭管理", "family.count.one", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66e007"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "最多加入五个家庭", "家庭管理", "family.count.five", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "RoleCode", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66d001"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "拥有所有权限，包括系统管理、用户管理、内容管理等", "ADMIN", "系统管理员", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66d002"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "基础权限：只能创建20个菜式，创建最近两周的菜谱，只能在一个家庭里面", "USER", "普通用户", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66d003"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "高级权限：能创建50个菜式，创建最近两个月的菜谱，可以在5个家庭里面", "VIP", "VIP用户", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TasteDicts",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "Name", "SortOrder", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff1"), "SWEET", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "以甜为主要口味", "甜味", 1, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff2"), "SALTY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "以咸为主要口味", "咸味", 2, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff3"), "SOUR", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "以酸为主要口味", "酸味", 3, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff4"), "BITTER", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "以苦为主要口味", "苦味", 4, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), "SPICY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "以辣为主要口味", "辣味", 5, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff6"), "SWEET_SOUR", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "酸甜搭配的口味", "酸甜", 6, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), "SALTY_FRESH", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "咸鲜搭配的口味", "咸鲜", 7, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff8"), "SPICY_HOT", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "麻辣搭配的口味", "麻辣", 8, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), "SOUR_SPICY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "酸辣搭配的口味", "酸辣", 9, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66affa"), "SALTY_SPICY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "咸辣搭配的口味", "咸辣", 10, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), "FRESH", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "以清淡为主要口味", "清淡", 11, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), "SWEET_SALTY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "甜咸搭配的口味", "甜咸", 12, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66affd"), "FRESH_SPICY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鲜辣搭配的口味", "鲜辣", 13, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66affe"), "LIGHT_SPICY", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "轻微辣味，口感温和", "微辣", 14, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CreatedAt", "Nickname", "Password", "Phone", "RefreshToken", "RefreshTokenExpireTime", "Status", "UpdatedAt", "UserCode", "Username" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66a001"), "/assets/images/avatars/admin.png", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "系统管理员", "21232f297a57a5a743894a0e4a801fc3", "13800000000", null, null, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADMIN001", "admin" });

            migrationBuilder.InsertData(
                table: "IngredientHumanGroups",
                columns: new[] { "Id", "CreatedAt", "Effect", "GroupId", "HumanGroupDictId", "IngredientId", "Notes", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ac01"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb1"), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), "优质蛋白质来源，适合孕期补充营养", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ac02"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb6"), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), "低脂肪高蛋白，适合糖尿病人食用", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ac03"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7"), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), "低钠高钙，适合高血压患者", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ac04"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb5"), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa03"), "部分老人可能不易消化青椒的皮", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ac05"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb8"), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), "含有膳食纤维，有助降低血脂", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ac06"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb1"), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), "富含铁质，有助预防孕期贫血", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "IngredientNutritions",
                columns: new[] { "Id", "Amount", "CreatedAt", "IngredientId", "NutrientId", "PerUnit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab01"), 113m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab02"), 23.3m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab03"), 1.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab04"), 76m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab05"), 8.1m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab06"), 20m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa03"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab07"), 1.4m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa03"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd5"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab08"), 284m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g干品", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab09"), 38.9m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd5"), "100g干品", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab10"), 125m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab11"), 22.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab12"), 3.8m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab13"), 3.0m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afe1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab14"), 143m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa10"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab15"), 18.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa10"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab16"), 8.0m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa10"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab17"), 395m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa11"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab18"), 12.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa11"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab19"), 37.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa11"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab20"), 106m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa14"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab21"), 20.1m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa14"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab22"), 2.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa14"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab23"), 95m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa15"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab24"), 20.3m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa15"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab25"), 1.1m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa15"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab26"), 24m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab27"), 5.7m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd4"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab28"), 2.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd5"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab29"), 81m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab30"), 19.1m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd4"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab31"), 27m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab32"), 18m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa20"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab33"), 14m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa20"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab34"), 15m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa19"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab35"), 0.8m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa19"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd5"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab36"), 144m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa23"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab37"), 12.8m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa23"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab38"), 10.3m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa23"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab39"), 116m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa24"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab40"), 25.9m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa24"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd4"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab41"), 138m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa25"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab42"), 28.7m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa25"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd4"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab43"), 34m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa28"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab44"), 2.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa28"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd5"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab45"), 34m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa29"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab46"), 89m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa29"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab47"), 20m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa30"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab48"), 35m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa30"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab49"), 74m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa31"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab50"), 17.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa31"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd4"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab51"), 213m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa32"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab52"), 16.9m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa32"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab53"), 15.2m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa32"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab54"), 12m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa41"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab55"), 27m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa41"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab56"), 15m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa42"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab57"), 9m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa42"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab58"), 252m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa43"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab59"), 19.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa43"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab60"), 18.7m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa43"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab61"), 27m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa21"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab62"), 27m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa21"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd7"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab63"), 203m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa12"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab64"), 18.8m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa12"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab65"), 14.5m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa12"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab66"), 240m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa13"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab67"), 16.2m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa13"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab68"), 19.7m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa13"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd3"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab69"), 33m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa35"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd1"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ab70"), 1.9m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa35"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afd2"), "100g", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "IngredientPreprocesses",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationSec", "ImageUrl", "IngredientId", "IngredientId1", "Method", "TemperatureDesc", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad01"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鸡胸肉洗净，切成细丝，便于快速烹饪", 120, "/assets/images/preprocess/chicken-slice.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), null, "切丝", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad02"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将切好的鸡胸肉加入盐、淀粉和料酒腌制入味", 600, "/assets/images/preprocess/chicken-marinate.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), null, "腌制", "冷藏", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad03"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将豆腐切成均匀的小方块", 60, "/assets/images/preprocess/tofu-cube.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), null, "切块", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad04"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将豆腐块放入沸水中焯烫30秒，捞出沥干水分", 30, "/assets/images/preprocess/tofu-blanch.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), null, "焯水", "沸水", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad05"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将青椒洗净，去蒂和籽，切成细丝", 60, "/assets/images/preprocess/pepper-slice.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa03"), null, "切丝", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad06"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将干木耳放入冷水中浸泡至完全泡发", 7200, "/assets/images/preprocess/black-fungus-soak.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), null, "泡发", "冷水", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad07"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将泡发后的木耳去除根部和硬质部分", 120, "/assets/images/preprocess/black-fungus-clean.jpg", new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), null, "去杂", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad08"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将姜去皮洗净后切成细末，便于爆香提味", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa04"), null, "切末", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad09"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将姜去皮洗净后切成薄片，适合用于煮汤或焖煮菜肴", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa04"), null, "切片", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad10"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将蒜去皮后切成细末，便于爆香增味", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa05"), null, "切末", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad11"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将蒜瓣用刀背拍碎，保留整体形状，适合烹饪大块食材", 30, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa05"), null, "拍碎", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad12"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "根据菜式需要与其他调料混合调配，如加入糖、料酒等", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa06"), null, "调配", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad13"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将牛肉逆着纹理切成薄片，适合快炒或火锅", 120, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), null, "切片", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad14"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将牛肉切成1-2厘米的小丁，适合红烧或炖煮", 90, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), null, "切丁", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad15"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将牛肉加入料酒、酱油、姜片等腌制入味", 300, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa09"), null, "腌制", "冷藏", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad16"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将猪肉切成细丝，适合炒菜", 90, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa10"), null, "切丝", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad17"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将猪肉剁成肉末，适合肉馅或肉沫炒菜", 120, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa10"), null, "剁末", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad18"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将五花肉切成薄片，适合煸炒或烤制", 90, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa11"), null, "切片", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad19"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将五花肉切成方块，适合红烧或炖煮", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa11"), null, "切块", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad20"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将茄子切成长条，适合炒菜或炸制", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), null, "切条", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad21"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将茄子切成方块，适合烧煮或炖汤", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), null, "切块", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad22"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将切好的茄子放入盐水中浸泡，减少吸油量", 600, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa17"), null, "盐水浸泡", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad23"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将土豆切成细丝，适合快炒或炸薯条", 90, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), null, "切丝", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad24"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将土豆切成方块，适合炖煮或烧菜", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), null, "切块", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad25"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将切好的土豆放入清水中浸泡，去除多余淀粉", 300, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa18"), null, "水浸泡", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad26"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将黄瓜切成圆片，适合凉拌或沙拉", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa19"), null, "切片", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad27"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将黄瓜切成细丝，适合凉拌或热炒", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa19"), null, "切丝", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad28"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将西红柿切成方块，适合炒菜或煮汤", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa20"), null, "切块", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad29"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将西红柿放入沸水中烫30秒，然后迅速放入冷水中，去皮", 120, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa20"), null, "去皮", "沸水", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad30"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鸡蛋打入碗中搅拌均匀，适合炒蛋或蒸蛋", 60, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa23"), null, "打散", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad31"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鸡蛋放入冷水中，煮沸后继续煮5-7分钟，煮熟", 420, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa23"), null, "煮熟", "沸水", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad32"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鱼肉处理后去除鱼刺，便于食用", 180, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa14"), null, "去刺", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad33"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鱼肉加入盐、料酒、姜片腌制，去除腥味", 600, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa14"), null, "腌制", "冷藏", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad34"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "去除虾壳、虾头和虾线，保留虾肉", 180, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa15"), null, "去壳", "室温", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ad35"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "用盐、料酒、姜片腌制虾肉，去腥增味", 300, null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa15"), null, "腌制", "冷藏", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PermissionMappings",
                columns: new[] { "Id", "CreatedAt", "ExpireTime", "ObjectId", "ObjectType", "PermissionId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f001"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d001"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e001"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f002"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d001"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e003"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f003"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d001"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e005"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f004"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d001"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e007"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f005"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d002"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e002"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f006"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d002"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e004"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f007"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d002"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e006"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f008"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d003"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e003"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f009"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d003"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e005"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f010"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66d003"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e007"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66f104"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3fa85f64-5717-4562-b3fc-2c963f66a001"), 1, new Guid("3fa85f64-5717-4562-b3fc-2c963f66e001"), true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookTime", "CookingMethodId", "CreatedAt", "CuisineId", "Description", "DifficultyLevel", "ImageUrl", "PrepTime", "RecipeName", "Recommended", "Servings", "Source", "SourceId", "Status", "TasteId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "鸡丝炒木耳是一道营养健康的家常菜，木耳的脆嫩与鸡丝的鲜香相得益彰，色香味俱全。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/jisi-muer.jpg", 10, "鸡丝炒木耳", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 20, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "麻婆豆腐是四川传统名菜，由豆腐、牛肉末和辣椒等烹制而成，麻辣鲜香，口感丰富。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/mapo-tofu.jpg", 15, "麻婆豆腐", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "清蒸鱼是一道广东名菜，保留了鱼的鲜美与营养，口感细嫩，清淡鲜香。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/steamed-fish.jpg", 20, "清蒸鱼", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba04"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "宫保鸡丁是川菜代表菜之一，鸡肉鲜嫩，花生香脆，辣味适中，口感丰富。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/kungpao-chicken.jpg", 25, "宫保鸡丁", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 90, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "红烧肉是中国特色传统名菜，五花肉经过焯水、煸炒、红烧等工序制作而成，肥而不腻，入口即化。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/braised-pork.jpg", 30, "红烧肉", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba06"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "鱼香肉丝是四川名菜，以猪肉丝、木耳、笋丝等为主料，调以鱼香味型调料烹制而成，酸甜辣香。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/yuxiang-pork.jpg", 25, "鱼香肉丝", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba07"), 0, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff9"), "蔬菜沙拉是一道健康低卡的素食料理，富含多种维生素和膳食纤维，清爽可口。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/vegetable-salad.jpg", 15, "蔬菜沙拉", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba08"), 40, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "糖醋排骨是一道传统汉族名菜，属于粤菜系。以猪排骨为主料，配以糖、醋等调料烹制而成，口味酸甜可口。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/sweet-sour-ribs.jpg", 20, "糖醋排骨", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba09"), 25, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "水煮鱼是四川传统名菜，以鲜嫩的鱼片配以麻辣的汤底，麻辣鲜香，味道浓郁。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/boiled-fish.jpg", 30, "水煮鱼", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba10"), 10, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "蒜蓉西兰花是一道营养丰富的素食菜肴，西兰花保持脆嫩，蒜香浓郁，口感清爽。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/garlic-broccoli.jpg", 10, "蒜蓉西兰花", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba11"), 20, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "酸辣汤是一道经典的中式汤品，酸辣可口，配料丰富，开胃爽口。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/hot-sour-soup.jpg", 15, "酸辣汤", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba12"), 10, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "西红柿炒鸡蛋是中国最常见的家常菜之一，酸甜可口，色泽鲜艳，营养丰富。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/tomato-egg.jpg", 5, "西红柿炒鸡蛋", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba13"), 20, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "干煸四季豆是一道经典川菜，四季豆经过油炸后与肉末一起干煸，干香脆嫩，风味独特。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/fried-green-beans.jpg", 15, "干煸四季豆", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affa"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba14"), 30, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "回锅肉是四川传统名菜，将煮熟的猪肉与青椒、蒜苗一起煸炒，肥而不腻，口感独特。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/twice-cooked-pork.jpg", 20, "回锅肉", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba15"), 5, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "蚝油生菜是粤菜的代表菜品之一，清淡爽口，健康营养，制作简单快捷。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/oyster-sauce-lettuce.jpg", 5, "蚝油生菜", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba16"), 150, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff5"), "东坡肉是江浙名菜，源于宋代文豪苏东坡，肉质软烂，色泽红亮，肥而不腻。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/dongpo-pork.jpg", 30, "东坡肉", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba17"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "葱爆羊肉是北方传统名菜，羊肉鲜嫩，葱香浓郁，风味独特。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/scallion-lamb.jpg", 20, "葱爆羊肉", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affd"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba18"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff4"), "鸡蛋羹是一道传统的家常蒸菜，口感嫩滑，营养丰富，适合各个年龄段的人食用。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/steamed-egg.jpg", 5, "鸡蛋羹", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba19"), 10, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff8"), "虎皮青椒是一道家常菜，青椒经过煎制后皮呈焦黄色，状如虎皮，味道鲜香可口。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/blistered-peppers.jpg", 5, "虎皮青椒", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affe"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba20"), 8, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "香菇油菜是一道简单健康的素食菜肴，香菇鲜香，油菜清脆，营养丰富。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/mushroom-bokchoy.jpg", 10, "香菇油菜", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba21"), 10, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "青椒土豆丝是一道家常炒菜，土豆丝脆嫩，青椒清香，简单美味。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/pepper-potato.jpg", 15, "青椒土豆丝", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affe"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba22"), 60, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff4"), "红烧狮子头是江浙名菜，大肉丸形似狮子头，肉质细嫩，味道鲜美。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/braised-meatballs.jpg", 30, "红烧狮子头", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba23"), 20, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "鱼香茄子是四川传统名菜，茄子软糯，鱼香味浓郁，酸甜辣香。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/yuxiang-eggplant.jpg", 15, "鱼香茄子", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba24"), 60, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "蒜泥白肉是四川名菜，将煮熟的猪肉切片，蘸以蒜泥调味汁食用，鲜香爽口。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/garlic-pork.jpg", 20, "蒜泥白肉", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affd"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba25"), 120, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff4"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "番茄牛腩是一道经典粤菜，牛腩炖至软烂，番茄酸甜，汤汁浓郁。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/tomato-beef-stew.jpg", 30, "番茄牛腩", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba26"), 10, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "韭菜炒鸡蛋是一道家常菜，韭菜鲜香，鸡蛋嫩滑，营养丰富。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/chive-eggs.jpg", 5, "韭菜炒鸡蛋", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba27"), 30, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cffa"), "寿司是日本传统料理，以醋饭配以鱼生、海鲜或蔬菜等食材制成，鲜美可口。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/sushi.jpg", 40, "日式寿司", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba28"), 25, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff9"), "意大利肉酱面是西餐中的经典料理，面条搭配番茄肉酱，风味浓郁。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/spaghetti.jpg", 15, "意大利肉酱面", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba29"), 30, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff9"), "冬阴功汤是泰国著名的酸辣汤，以香茅、柠檬叶等香料调味，酸辣鲜香。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/tom-yum-soup.jpg", 20, "泰式冬阴功汤", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba30"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bffa"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cffb"), "韩式泡菜是韩国传统发酵食品，酸辣爽口，可作为配菜或料理材料。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/kimchi.jpg", 60, "韩式泡菜", true, 6, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba31"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "葱油饼是中国传统面食，外脆内软，葱香四溢，是受欢迎的早餐或小吃。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/scallion-pancake.jpg", 20, "葱油饼", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba32"), 35, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "烤鱼是一道美味的烧烤类菜肴，鱼肉嫩滑，外皮酥脆，香辣可口。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/grilled-fish.jpg", 25, "烤鱼", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba33"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "木须肉是一道传统的家常菜，猪肉、鸡蛋、木耳、黄花菜等配料丰富，营养均衡。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/muxu-pork.jpg", 15, "木须肉", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba34"), 180, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff4"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff7"), "佛跳墙是福建闽菜的代表菜之一，由多种山珍海味炖制而成，香气扑鼻，味道鲜美。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/buddha-jump-wall.jpg", 120, "佛跳墙", true, 6, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba35"), 25, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "辣子鸡是四川传统名菜，鸡肉经油炸后与干辣椒一起爆炒，麻辣香脆。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/laziji.jpg", 30, "辣子鸡", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba36"), 10, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "蛋炒饭是一道简单美味的家常饭，米饭粒粒分明，鸡蛋香滑，营养美味。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/egg-fried-rice.jpg", 5, "蛋炒饭", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba37"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "拍黄瓜是一道清爽开胃的凉菜，黄瓜脆嫩，调味鲜美，制作简单。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/smashed-cucumber.jpg", 10, "拍黄瓜", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba38"), 20, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "清蒸螃蟹是一道鲜美的海鲜料理，保留了螃蟹的原汁原味，肉质鲜嫩。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/steamed-crab.jpg", 15, "清蒸螃蟹", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba39"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff9"), "烤羊肉串是新疆特色美食，羊肉鲜嫩多汁，孜然香气四溢，风味独特。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/lamb-skewers.jpg", 20, "烤羊肉串", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba40"), 5, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "凉拌豆腐是一道简单美味的凉菜，豆腐嫩滑，调味鲜香，清爽开胃。", 1, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/cold-tofu.jpg", 10, "凉拌豆腐", true, 2, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba41"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "酱爆鸭肠是一道特色川菜，鸭肠脆嫩，口感独特，酱香浓郁。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/duck-intestine.jpg", 25, "酱爆鸭肠", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba42"), 30, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff7"), "三杯鸡是台湾特色菜，以一杯酱油、一杯米酒、一杯麻油焖炖而成，鸡肉香嫩入味。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/three-cup-chicken.jpg", 20, "三杯鸡", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba43"), 45, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "白切鸡是广东名菜，整鸡煮熟后切块食用，肉质鲜嫩，皮滑肉香。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/white-cut-chicken.jpg", 15, "白切鸡", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba44"), 30, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff1"), "酸菜鱼是四川名菜，以鲜嫩的鱼片和酸爽的泡菜为主料，酸辣可口，汤鲜味美。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/sour-soup-fish.jpg", 25, "酸菜鱼", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff9"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba45"), 15, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff1"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "炒河粉是广东传统名菜，河粉滑爽，配料丰富，鲜香可口。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/fried-rice-noodles.jpg", 15, "炒河粉", true, 3, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff7"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba46"), 90, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff6"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff3"), "北京烤鸭是中国传统名菜，皮酥肉嫩，色泽红亮，香气四溢。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/peking-duck.jpg", 60, "北京烤鸭", true, 6, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba47"), 90, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff3"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "莲藕排骨汤是一道滋补汤品，排骨鲜香，莲藕甘甜，汤汁清澈，营养丰富。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/lotus-rib-soup.jpg", 20, "莲藕排骨汤", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affb"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba48"), 25, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff2"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff8"), "剁椒鱼头是湖南名菜，以鱼头和剁椒为主料，蒸制而成，鲜辣可口。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/chili-fish-head.jpg", 25, "剁椒鱼头", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66aff5"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba49"), 120, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff2"), "梅菜扣肉是客家传统名菜，肥肉软烂，梅菜咸香，肥而不腻，味道浓郁。", 3, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/mei-cai-kou-rou.jpg", 30, "梅菜扣肉", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba50"), 30, new Guid("3fa85f64-5717-4562-b3fc-2c963f66bff8"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66cff4"), "红烧鱼是一道家常菜，鱼肉鲜嫩，汤汁浓郁，色泽红亮，营养丰富。", 2, "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/braised-fish.jpg", 20, "红烧鱼", true, 4, 0, null, true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66affc"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "RoleId", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66a101"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66d001"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66a001") });

            migrationBuilder.InsertData(
                table: "RecipeCookingSteps",
                columns: new[] { "Id", "ActionType", "AiInstruction", "CreatedAt", "Description", "DurationSec", "ImageUrl", "IngredientRefs", "IsOptional", "RecipeId", "StepNumber", "TemperatureDesc", "Title", "UpdatedAt", "VideoUrl", "WaitTimeSec" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc01"), "切配", "注意鸡胸肉要顺着纹理切丝，更嫩滑。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鸡胸肉切成细丝，木耳泡发后撕成小块，青椒切丝，姜切末。", 300, null, "[1,2,3,4]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 1, "室温", "准备食材", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc02"), "腌制", "这一步可以让鸡肉更加鲜嫩多汁。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鸡胸肉加入少许盐、料酒和淀粉抓匀，腌制5分钟。", 60, null, "[1]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 2, "室温", "鸡肉入味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 300 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc03"), "爆香", "油温七成热时下姜末，香气更浓郁。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "锅中倒油烧热，加入姜末爆香。", 30, null, "[4]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 3, "大火", "爆香姜末", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc04"), "翻炒", "鸡丝变色即可，不要过度炒制以免老柴。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "放入腌制好的鸡丝，快速翻炒至变色。", 90, null, "[1]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 4, "大火", "炒鸡丝", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc05"), "翻炒", "木耳炒至有光泽即可，不要过久，保持脆嫩口感。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "放入泡发好的木耳，翻炒均匀。", 120, null, "[2]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 5, "大火", "加入木耳", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc06"), "翻炒", "青椒炒至断生即可，保持色泽翠绿。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "放入青椒丝，快速翻炒均匀。", 60, null, "[3]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 6, "大火", "加入青椒", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc07"), "调味", "根据个人口味调整咸淡，木耳本身有味道，注意少放盐。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "加入酱油和少许盐，翻炒均匀。", 30, null, "[5]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 7, "大火", "调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc08"), "装盘", "可以撒上少许香葱提香增色。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "装盘即可食用。", 30, null, "[]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), 8, null, "出锅", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc09"), "切配", "豆腐切成约2厘米见方的小块，方便入味。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "豆腐切成小方块，蒜切末。", 300, null, "[6,7]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 1, "室温", "准备食材", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc10"), "焯水", "焯水可以去除豆腐的生腥味，使豆腐更容易吸收调料的味道。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "锅中加水烧开，放入豆腐焯水30秒，捞出沥干水分。", 60, null, "[6]", true, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 2, "沸水", "焯水豆腐", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc11"), "爆香", "油温不要太高，避免蒜末炒糊。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "锅中倒油烧热，加入蒜末爆香。", 60, null, "[7]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 3, "中火", "炒香调料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc12"), "炒制", "慢火炒豆瓣酱，让香味充分释放出来。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "加入豆瓣酱炒出红油。", 90, null, "[]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 4, "小火", "炒豆瓣酱", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc13"), "焖煮", "动作要轻，避免把豆腐弄碎。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "倒入适量清水，然后放入豆腐块，小心翻动均匀。", 180, null, "[6]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 5, "中小火", "加入豆腐", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc14"), "勾芡", "水淀粉要边倒边搅拌，避免结块。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "加入少许盐调味，用水淀粉勾芡。", 60, null, "[8]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 6, "小火", "勾芡调味", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc15"), "装盘", "花椒粉增添麻味，是麻婆豆腐的灵魂。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "撒上花椒粉和葱花，装盘即可。", 30, null, "[]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), 7, null, "出锅装盘", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc20"), "清洗处理", "刀口不要太深，以免破坏鱼的整体性。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鱼清洗干净，去除内脏和鳞片，在鱼身两侧划几刀，便于入味。", 300, null, "[14]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 1, "室温", "鱼的处理", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc21"), "腌制", "料酒可以有效去除鱼的腥味，使鱼肉更加鲜美。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鱼均匀抹上盐和料酒，腌制10分钟去腥增鲜。", 60, null, "[14,7]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 2, "室温", "腌制鱼", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 600 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc22"), "切配", "姜丝最好切细一些，葱段和葱花分开备用。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "姜切丝，葱切段，部分葱切成葱花。", 180, null, "[4,24]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 3, "室温", "准备配料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc23"), "摆盘", "姜丝和葱段均匀分布在鱼身上，有助于去腥增香。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鱼放在蒸盘上，鱼身上铺上姜丝和一半的葱段。", 120, null, "[14,4,24]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 4, "室温", "摆盘准备", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc24"), "蒸", "蒸鱼时间不宜过长，以免鱼肉老化失去鲜嫩口感。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "将鱼放入蒸锅中，水烧开后蒸8-10分钟。", 600, null, "[14]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 5, "高温蒸汽", "蒸鱼", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc25"), "调味", "油温不要太高，防止酱油糊化。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "锅中倒入少许油烧热，加入酱油和少许白糖调味。", 60, null, "[6]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 6, "中火", "制作调味汁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc26"), "浇汁", "热油浇在葱花上可以激发出葱的香气，增添菜品风味。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "鱼蒸好后，去除姜丝和葱段，撒上葱花，浇上热油和调味汁。", 60, null, "[14,24,6]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba03"), 7, "热油", "最终处理", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc30"), "切配", "牛肉要切成大小均匀的块，便于均匀入味和烹饪。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "牛肉切成2-3厘米的方块，姜切片，蒜切末，葱切段。", 300, null, "[9,4,5,24]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 1, "室温", "准备食材", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc31"), "焯水", "焯水可以去除牛肉中的血水和异味，使最终成菜更加鲜美。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "锅中加水烧开，放入牛肉块焯水3分钟，去除血水和杂质。", 180, null, "[9]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 2, "沸水", "焯水", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc32"), "爆香", "爆香料头是红烧菜品的关键步骤，可以激发出香料的风味。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "锅中倒油烧热，放入姜片、蒜末、葱段爆香。", 90, null, "[4,5,24]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 3, "中火", "爆香料头", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc33"), "煸炒", "煸炒牛肉可以封住肉汁，使牛肉更加鲜嫩。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "放入焯好水的牛肉块，翻炒至表面微微变色。", 180, null, "[9]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 4, "大火", "煸炒牛肉", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc34"), "调味", "酱油提供咸味和色泽，白糖可以中和酱油的咸味并增加光泽。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "加入酱油、白糖、料酒和适量清水，没过牛肉。", 60, null, "[6]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 5, "大火", "加入调料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc35"), "炖煮", "耐心炖煮是红烧牛肉的关键，时间足够长才能使牛肉变得酥烂入味。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "大火烧开后转小火，盖上锅盖慢炖1.5-2小时，直至牛肉酥烂。", 7200, null, "[9]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 6, "小火", "炖煮", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bc36"), "收汁", "收汁时要注意控制火候，避免炒糊。", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "牛肉炖烂后，开大火收汁至浓稠。", 300, null, "[9]", false, new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba05"), 7, "大火", "收汁", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "CreatedAt", "IngredientId", "IngredientId1", "IngredientWeight", "IsKeyIngredient", "Notes", "PostProcessImage", "ProcessMethod", "RecipeId", "RoleType", "UpdatedAt", "UsageMethod", "UsageOrder" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb01"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa01"), null, "200g", true, "鸡胸肉要切成细丝，更容易入味且口感好", null, "切丝", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), "主料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "先炒", 1 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb02"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa08"), null, "100g", true, "木耳要提前泡发，去除硬根", null, "泡发,撕小块", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), "主料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "后炒", 2 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb03"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa03"), null, "1个", false, "青椒提香增色，可以根据个人喜好增减", null, "切丝", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), "辅料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "最后炒", 3 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb04"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa04"), null, "适量", false, "姜末用于去腥提香", null, "切末", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), "调料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "爆香", 0 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb05"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa06"), null, "1勺", false, "提鲜上色", null, "原样", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba01"), "调料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "调味", 4 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb06"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa02"), null, "500g", true, "选用嫩豆腐，口感更好", null, "切块", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), "主料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "煮", 1 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb07"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa05"), null, "适量", false, "蒜末增香提味", null, "切末", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), "调料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "爆香", 0 },
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66bb08"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66aa07"), null, "少许", false, "根据个人口味添加", null, "原样", new Guid("3fa85f64-5717-4562-b3fc-2c963f66ba02"), "调料", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "调味", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethodDicts_Code",
                table: "CookingMethodDicts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethodDicts_Name",
                table: "CookingMethodDicts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethodDicts_SortOrder",
                table: "CookingMethodDicts",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethodDicts_Status",
                table: "CookingMethodDicts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineDicts_Code",
                table: "CuisineDicts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuisineDicts_Name",
                table: "CuisineDicts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineDicts_SortOrder",
                table: "CuisineDicts",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineDicts_Status",
                table: "CuisineDicts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Families_FamilyCode",
                table: "Families",
                column: "FamilyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Families_FamilyName",
                table: "Families",
                column: "FamilyName");

            migrationBuilder.CreateIndex(
                name: "IX_Families_OwnerUserId",
                table: "Families",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_FamilyId",
                table: "FamilyMembers",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_FamilyId_UserId",
                table: "FamilyMembers",
                columns: new[] { "FamilyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_MemberRole",
                table: "FamilyMembers",
                column: "MemberRole");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_UserId",
                table: "FamilyMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HumanGroupDicts_Name",
                table: "HumanGroupDicts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientHumanGroups_Effect",
                table: "IngredientHumanGroups",
                column: "Effect");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientHumanGroups_GroupId",
                table: "IngredientHumanGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientHumanGroups_HumanGroupDictId",
                table: "IngredientHumanGroups",
                column: "HumanGroupDictId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientHumanGroups_IngredientId",
                table: "IngredientHumanGroups",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientHumanGroups_IngredientId_GroupId",
                table: "IngredientHumanGroups",
                columns: new[] { "IngredientId", "GroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutritionDicts_Name",
                table: "IngredientNutritionDicts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutritions_IngredientId",
                table: "IngredientNutritions",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutritions_IngredientId_NutrientId",
                table: "IngredientNutritions",
                columns: new[] { "IngredientId", "NutrientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientNutritions_NutrientId",
                table: "IngredientNutritions",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPreprocesses_IngredientId",
                table: "IngredientPreprocesses",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPreprocesses_IngredientId1",
                table: "IngredientPreprocesses",
                column: "IngredientId1");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPreprocesses_Method",
                table: "IngredientPreprocesses",
                column: "Method");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Category",
                table: "Ingredients",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FlavorProfile",
                table: "Ingredients",
                column: "FlavorProfile");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDetails_MealPlanId",
                table: "MealPlanDetails",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDetails_MealPlanId_WeekDay_MealTimeId",
                table: "MealPlanDetails",
                columns: new[] { "MealPlanId", "WeekDay", "MealTimeId" });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDetails_MealTimeId",
                table: "MealPlanDetails",
                column: "MealTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDetails_RecipeId",
                table: "MealPlanDetails",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDetails_WeekDay",
                table: "MealPlanDetails",
                column: "WeekDay");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanNutritions_IngredientNutritionDictId",
                table: "MealPlanNutritions",
                column: "IngredientNutritionDictId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanNutritions_MealPlanId",
                table: "MealPlanNutritions",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanNutritions_MealPlanId_NutrientId",
                table: "MealPlanNutritions",
                columns: new[] { "MealPlanId", "NutrientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanNutritions_NutrientId",
                table: "MealPlanNutritions",
                column: "NutrientId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanOrders_MealPlanId",
                table: "MealPlanOrders",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanOrders_MealPlanId_UserId_RecipeId",
                table: "MealPlanOrders",
                columns: new[] { "MealPlanId", "UserId", "RecipeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanOrders_RecipeId",
                table: "MealPlanOrders",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanOrders_Status",
                table: "MealPlanOrders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanOrders_UserId",
                table: "MealPlanOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanOrders_UserId1",
                table: "MealPlanOrders",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MealTimeDicts_Code",
                table: "MealTimeDicts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealTimeDicts_Name",
                table: "MealTimeDicts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMappings_ObjectId",
                table: "PermissionMappings",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMappings_ObjectType_ObjectId_PermissionId",
                table: "PermissionMappings",
                columns: new[] { "ObjectType", "ObjectId", "PermissionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMappings_PermissionId",
                table: "PermissionMappings",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Module",
                table: "Permissions",
                column: "Module");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionCode",
                table: "Permissions",
                column: "PermissionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCookingSteps_RecipeId",
                table: "RecipeCookingSteps",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCookingSteps_RecipeId_StepNumber",
                table: "RecipeCookingSteps",
                columns: new[] { "RecipeId", "StepNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId1",
                table: "RecipeIngredients",
                column: "IngredientId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId_IngredientId",
                table: "RecipeIngredients",
                columns: new[] { "RecipeId", "IngredientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RoleType",
                table: "RecipeIngredients",
                column: "RoleType");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookingMethodId",
                table: "Recipes",
                column: "CookingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CuisineId",
                table: "Recipes",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DifficultyLevel",
                table: "Recipes",
                column: "DifficultyLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeName",
                table: "Recipes",
                column: "RecipeName");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Source",
                table: "Recipes",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_SourceId",
                table: "Recipes",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Status",
                table: "Recipes",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TasteId",
                table: "Recipes",
                column: "TasteId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleCode",
                table: "Roles",
                column: "RoleCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasteDicts_Code",
                table: "TasteDicts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasteDicts_Name",
                table: "TasteDicts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_TasteDicts_SortOrder",
                table: "TasteDicts",
                column: "SortOrder");

            migrationBuilder.CreateIndex(
                name: "IX_TasteDicts_Status",
                table: "TasteDicts",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_UserHumanGroups_GroupId",
                table: "UserHumanGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHumanGroups_Source",
                table: "UserHumanGroups",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_UserHumanGroups_UserId",
                table: "UserHumanGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHumanGroups_UserId_GroupId",
                table: "UserHumanGroups",
                columns: new[] { "UserId", "GroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_PreferenceType",
                table: "UserPreferences",
                column: "PreferenceType");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_TargetId",
                table: "UserPreferences",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_TargetType",
                table: "UserPreferences",
                column: "TargetType");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId_TargetType_TargetId_PreferenceType",
                table: "UserPreferences",
                columns: new[] { "UserId", "TargetType", "TargetId", "PreferenceType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RefreshToken",
                table: "Users",
                column: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Status",
                table: "Users",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCode",
                table: "Users",
                column: "UserCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_CreatorUserId",
                table: "WeeklyMealPlans",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_EndDate",
                table: "WeeklyMealPlans",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_FamilyId",
                table: "WeeklyMealPlans",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_FamilyId1",
                table: "WeeklyMealPlans",
                column: "FamilyId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_PlanCode",
                table: "WeeklyMealPlans",
                column: "PlanCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_StartDate",
                table: "WeeklyMealPlans",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_Status",
                table: "WeeklyMealPlans",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_UserId",
                table: "WeeklyMealPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_UserId1",
                table: "WeeklyMealPlans",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_UserId2",
                table: "WeeklyMealPlans",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMealPlans_Year_WeekNumber",
                table: "WeeklyMealPlans",
                columns: new[] { "Year", "WeekNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "IngredientHumanGroups");

            migrationBuilder.DropTable(
                name: "IngredientNutritions");

            migrationBuilder.DropTable(
                name: "IngredientPreprocesses");

            migrationBuilder.DropTable(
                name: "MealPlanDetails");

            migrationBuilder.DropTable(
                name: "MealPlanNutritions");

            migrationBuilder.DropTable(
                name: "MealPlanOrders");

            migrationBuilder.DropTable(
                name: "PermissionMappings");

            migrationBuilder.DropTable(
                name: "RecipeCookingSteps");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "UserHumanGroups");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "MealTimeDicts");

            migrationBuilder.DropTable(
                name: "IngredientNutritionDicts");

            migrationBuilder.DropTable(
                name: "WeeklyMealPlans");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "HumanGroupDicts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "CookingMethodDicts");

            migrationBuilder.DropTable(
                name: "CuisineDicts");

            migrationBuilder.DropTable(
                name: "TasteDicts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
