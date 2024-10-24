using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CocomoBackend.Migrations
{
    /// <inheritdoc />
    public partial class InicialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CocomoRequeriments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCocomoVersion = table.Column<int>(type: "int", nullable: false),
                    IdTypeProyect = table.Column<int>(type: "int", nullable: false),
                    ProyectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD = table.Column<int>(type: "int", nullable: false),
                    DD = table.Column<int>(type: "int", nullable: false),
                    PP = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    CP = table.Column<int>(type: "int", nullable: false),
                    DT = table.Column<int>(type: "int", nullable: false),
                    DF = table.Column<int>(type: "int", nullable: false),
                    DB = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoRequeriments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CocomoStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CocomoStatesVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoStatesVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formulas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformObjectTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformInitial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectInitial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectDecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeInitial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeDecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplexityObjectInitial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplexityObjectDecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplexityChangeInitial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplexityChangeDecription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformObjectTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeComplexities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTypeRequirement = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComplexities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProyects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AD = table.Column<int>(type: "int", nullable: false),
                    DD = table.Column<int>(type: "int", nullable: false),
                    PP = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    CP = table.Column<int>(type: "int", nullable: false),
                    DT = table.Column<int>(type: "int", nullable: false),
                    DF = table.Column<int>(type: "int", nullable: false),
                    DB = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Editable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProyects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verticals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verticals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CocomoDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCocomoVersion = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocomoDetails_PlatformObjectTimes_ItemId",
                        column: x => x.ItemId,
                        principalTable: "PlatformObjectTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocomoFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCocomoVersion = table.Column<int>(type: "int", nullable: false),
                    TypeFactorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocomoFactors_TypeFactors_TypeFactorId",
                        column: x => x.TypeFactorId,
                        principalTable: "TypeFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeFactorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTypeFactor = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<int>(type: "int", nullable: false),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeFactorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFactorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeFactorDetails_TypeFactors_TypeFactorId",
                        column: x => x.TypeFactorId,
                        principalTable: "TypeFactors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CocomoHeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdTypeRequirement = table.Column<int>(type: "int", nullable: false),
                    IdTypeComplexity = table.Column<int>(type: "int", nullable: false),
                    IdCocomostate = table.Column<int>(type: "int", nullable: false),
                    EstimationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimationObservations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdModule = table.Column<int>(type: "int", nullable: false),
                    IdVertical = table.Column<int>(type: "int", nullable: false),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    IdRevisor = table.Column<int>(type: "int", nullable: false),
                    ActiveEstimation = table.Column<bool>(type: "bit", nullable: false),
                    ActiveCaim = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocomoHeads_CocomoStates_IdCocomostate",
                        column: x => x.IdCocomostate,
                        principalTable: "CocomoStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocomoHeads_Customers_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocomoHeads_Modules_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocomoHeads_TypeComplexities_IdTypeComplexity",
                        column: x => x.IdTypeComplexity,
                        principalTable: "TypeComplexities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocomoHeads_TypeRequirements_IdTypeRequirement",
                        column: x => x.IdTypeRequirement,
                        principalTable: "TypeRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocomoHeads_Verticals_IdVertical",
                        column: x => x.IdVertical,
                        principalTable: "Verticals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocomoVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCocomoHead = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCocomostateversion = table.Column<int>(type: "int", nullable: false),
                    CocomostateversionId = table.Column<int>(type: "int", nullable: false),
                    IdCocomoRequeriment = table.Column<int>(type: "int", nullable: false),
                    IdCocomoFactor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocomoVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocomoVersions_CocomoHeads_IdCocomoHead",
                        column: x => x.IdCocomoHead,
                        principalTable: "CocomoHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocomoVersions_CocomoStatesVersions_CocomostateversionId",
                        column: x => x.CocomostateversionId,
                        principalTable: "CocomoStatesVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CocomoDetails_ItemId",
                table: "CocomoDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoFactors_TypeFactorId",
                table: "CocomoFactors",
                column: "TypeFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_Code",
                table: "CocomoHeads",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_IdCocomostate",
                table: "CocomoHeads",
                column: "IdCocomostate");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_IdCustomer",
                table: "CocomoHeads",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_IdModule",
                table: "CocomoHeads",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_IdTypeComplexity",
                table: "CocomoHeads",
                column: "IdTypeComplexity");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_IdTypeRequirement",
                table: "CocomoHeads",
                column: "IdTypeRequirement");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoHeads_IdVertical",
                table: "CocomoHeads",
                column: "IdVertical");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoVersions_CocomostateversionId",
                table: "CocomoVersions",
                column: "CocomostateversionId");

            migrationBuilder.CreateIndex(
                name: "IX_CocomoVersions_IdCocomoHead",
                table: "CocomoVersions",
                column: "IdCocomoHead");

            migrationBuilder.CreateIndex(
                name: "IX_TypeFactorDetails_TypeFactorId",
                table: "TypeFactorDetails",
                column: "TypeFactorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CocomoDetails");

            migrationBuilder.DropTable(
                name: "CocomoFactors");

            migrationBuilder.DropTable(
                name: "CocomoRequeriments");

            migrationBuilder.DropTable(
                name: "CocomoVersions");

            migrationBuilder.DropTable(
                name: "Formulas");

            migrationBuilder.DropTable(
                name: "TypeFactorDetails");

            migrationBuilder.DropTable(
                name: "TypeProyects");

            migrationBuilder.DropTable(
                name: "PlatformObjectTimes");

            migrationBuilder.DropTable(
                name: "CocomoHeads");

            migrationBuilder.DropTable(
                name: "CocomoStatesVersions");

            migrationBuilder.DropTable(
                name: "TypeFactors");

            migrationBuilder.DropTable(
                name: "CocomoStates");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "TypeComplexities");

            migrationBuilder.DropTable(
                name: "TypeRequirements");

            migrationBuilder.DropTable(
                name: "Verticals");
        }
    }
}
