using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RegistrationWizard.Dal.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "configuration");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "configuration",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "configuration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", maxLength: 255, nullable: false),
                    IsAgreeToWorkForFood = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "configuration",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                schema: "configuration",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProvinceId",
                schema: "configuration",
                table: "Users",
                column: "ProvinceId");
                
            
            migrationBuilder.Sql(@"insert into ""configuration"".""Countries""(""Name"") 
                (select 'Russia' as ""Name""
                union 
                select 'USA' as ""Name""
                union
                select 'Ukraine' as ""Name"")");

            migrationBuilder.Sql(@"insert into ""configuration"".""Provinces""(""Name"", ""CountryId"") 
                (select 'Province 1' as ""Name"", 1 as ""CountryId""
                union  
                select  'Province 2' as ""Name"", 1 as ""CountryId""
                union
                select 'Province 3' as ""Name"", 1 as ""CountryId""
                union  
                select  'Province 4' as ""Name"", 2 as ""CountryId""
                union
                select 'Province 5' as ""Name"", 2 as ""CountryId""
                union  
                select  'Province 6' as ""Name"", 2 as ""CountryId""
                union
                select 'Province 7' as ""Name"", 2 as ""CountryId""
                union  
                select  'Province 8' as ""Name"", 3 as ""CountryId""
                union
                select 'Province 9' as ""Name"", 3 as ""CountryId""
                union  
                select  'Province 10' as ""Name"", 3 as ""CountryId""
                union
                select  'Province 11' as ""Name"", 3 as ""CountryId""
                union
                select  'Province 12' as ""Name"", 3 as ""CountryId"")");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "configuration");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "configuration");
        }
    }
}
