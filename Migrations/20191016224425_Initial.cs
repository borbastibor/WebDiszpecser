using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDiszpecser.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Soforok",
                columns: table => new
                {
                    SoforID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Csaladnev = table.Column<string>(nullable: false),
                    Keresztnev = table.Column<string>(nullable: false),
                    SzulIdo = table.Column<DateTime>(nullable: false),
                    JogositvanySzam = table.Column<string>(nullable: false),
                    Ervenyesseg = table.Column<DateTime>(nullable: false),
                    Kategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soforok", x => x.SoforID);
                });

            migrationBuilder.CreateTable(
                name: "Telephelyek",
                columns: table => new
                {
                    TelephelyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TelephelyCim = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephelyek", x => x.TelephelyID);
                });

            migrationBuilder.CreateTable(
                name: "Gepjarmuvek",
                columns: table => new
                {
                    GepjarmuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipus = table.Column<string>(nullable: false),
                    Rendszam = table.Column<string>(nullable: false),
                    FutottKm = table.Column<int>(nullable: false),
                    SzervizCiklus = table.Column<int>(nullable: false),
                    UtolsoSzerviz = table.Column<DateTime>(nullable: false),
                    Kategoria = table.Column<int>(nullable: false),
                    TelephelyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gepjarmuvek", x => x.GepjarmuID);
                    table.ForeignKey(
                        name: "FK_Gepjarmuvek_Telephelyek_TelephelyID",
                        column: x => x.TelephelyID,
                        principalTable: "Telephelyek",
                        principalColumn: "TelephelyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fuvarok",
                columns: table => new
                {
                    FuvarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Feladat = table.Column<string>(nullable: false),
                    IndulasIdeje = table.Column<DateTime>(nullable: false),
                    BerakoCim = table.Column<string>(nullable: false),
                    KirakoCim = table.Column<string>(nullable: false),
                    GepjarmuID = table.Column<int>(nullable: false),
                    SoforID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuvarok", x => x.FuvarID);
                    table.ForeignKey(
                        name: "FK_Fuvarok_Gepjarmuvek_GepjarmuID",
                        column: x => x.GepjarmuID,
                        principalTable: "Gepjarmuvek",
                        principalColumn: "GepjarmuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fuvarok_Soforok_SoforID",
                        column: x => x.SoforID,
                        principalTable: "Soforok",
                        principalColumn: "SoforID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Soforok",
                columns: new[] { "SoforID", "Csaladnev", "Ervenyesseg", "JogositvanySzam", "Kategoria", "Keresztnev", "SzulIdo" },
                values: new object[,]
                {
                    { 1, "Gulyás", new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234EA", 0, "János", new DateTime(1985, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Várkonyi", new DateTime(2021, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "9447GH", 1, "Emil", new DateTime(1991, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Vörös", new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "9117GH", 1, "Dávid", new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Borkodi", new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "9977GH", 0, "Olivér", new DateTime(1988, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Vágó", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "9985GH", 1, "Botond", new DateTime(1987, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Mészöly", new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "2885GH", 3, "Tibor", new DateTime(1981, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Bajai", new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "2045GH", 3, "Zoltán", new DateTime(1981, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Meggyesi", new DateTime(2020, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "3445GH", 3, "Ödön", new DateTime(1979, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Márkus", new DateTime(2021, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "8845GH", 3, "Iván", new DateTime(1979, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Békési", new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "8844KL", 3, "Bertold", new DateTime(1979, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Martonyi", new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "8844KL", 0, "István", new DateTime(1976, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Döbrögi", new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "3544GL", 1, "József", new DateTime(1978, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Sziráki", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "3129GL", 1, "József", new DateTime(1989, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Mézga", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "3789GL", 1, "Aladár", new DateTime(1989, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Mézga", new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "3698FL", 1, "Géza", new DateTime(1980, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Boros", new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "6126FL", 1, "Béla", new DateTime(1987, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Nagy", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "6586BL", 0, "Béla", new DateTime(1973, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Kiss", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "5786VL", 3, "Márton", new DateTime(1983, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Borsfalvy", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "5476VC", 2, "Győző", new DateTime(1984, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Csukás", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2143SD", 1, "Géza", new DateTime(1975, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Ludas", new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "3544GL", 0, "Mátyás", new DateTime(1978, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Telephelyek",
                columns: new[] { "TelephelyID", "TelephelyCim" },
                values: new object[,]
                {
                    { 2, "5000 Szolnok, Ady Endre utca 156." },
                    { 1, "6726 Szeged, Bécsi körút 21." },
                    { 3, "7100 Szekszárd, Keselyűsi út 22." }
                });

            migrationBuilder.InsertData(
                table: "Gepjarmuvek",
                columns: new[] { "GepjarmuID", "FutottKm", "Kategoria", "Rendszam", "SzervizCiklus", "TelephelyID", "Tipus", "UtolsoSzerviz" },
                values: new object[,]
                {
                    { 1, 120000, 1, "FGH345", 30000, 1, "MB1017", new DateTime(2019, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 67120, 1, "GKJ786", 30000, 1, "Rába H14", new DateTime(2018, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 104450, 0, "GKZ657", 30000, 1, "Mercedes Sprinter", new DateTime(2018, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 540580, 3, "RTU785", 50000, 1, "DAF 20", new DateTime(2018, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 280580, 0, "DFU965", 15000, 1, "VW LT-4", new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 124070, 1, "MNB123", 30000, 2, "MB1017", new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 260120, 2, "HBJ786", 50000, 2, "Ikarusz 452", new DateTime(2019, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 570450, 3, "GTZ457", 50000, 2, "MAN 3220", new DateTime(2018, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 54580, 0, "GHU785", 15000, 2, "VW T6", new DateTime(2018, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 10580, 0, "LFU965", 30000, 2, "VW Golf Variant", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 65120, 1, "GKT786", 30000, 3, "Rába H14", new DateTime(2018, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 100450, 0, "GKZ667", 30000, 3, "Mercedes Sprinter", new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 570580, 3, "RTU345", 50000, 3, "DAF 20", new DateTime(2017, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 60580, 0, "GJU785", 15000, 3, "VW T6", new DateTime(2019, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 150580, 0, "HJU895", 15000, 3, "Renault Jumper", new DateTime(2018, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Fuvarok",
                columns: new[] { "FuvarID", "BerakoCim", "Feladat", "GepjarmuID", "IndulasIdeje", "KirakoCim", "SoforID" },
                values: new object[,]
                {
                    { 1, "5000 Szolnok, Kossuth utca 48.", "Bútorszállítás", 1, new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Szapolyai utca 37.", 2 },
                    { 9, "7100 Szekszárd, Keselyűsi út 22.", "Áruszállítás", 9, new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Szolnok, Kilián út 37.", 15 },
                    { 6, "7100 Szekszárd, Keselyűsi út 22.", "Csomagszállítás", 6, new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Várkonyi tér 37.", 19 },
                    { 3, "7100 Szekszárd, Keselyűsi út 22.", "Áruszállítás", 3, new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "7100 Szekszárd, Alisca utca 22.", 2 },
                    { 14, "5000 Szolnok, Nagy József út 37.", "Személyszállítás", 14, new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "7100 Szekszárd, Keselyűsi út 22.", 19 },
                    { 11, "6726 Szeged, Várkonyi tér 37.", "Személyszállítás", 11, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Szolnok, Nagy József út 37.", 21 },
                    { 8, "6726 Szeged, Várkonyi tér 37.", "Áruszállítás", 8, new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Szolnok, Kilián út 37.", 17 },
                    { 12, "7100 Szekszárd, Keselyűsi út 22.", "Személyszállítás", 12, new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Várkonyi tér 37.", 1 },
                    { 17, "6726 Szeged, Várkonyi tér 37.", "Személyszállítás", 5, new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Szolnok, Nagy József út 37.", 3 },
                    { 2, "5000 Szolnok, Szapáry utca 48.", "Hulladékszállítás", 2, new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Szolnok, Tulipán utca 48.", 6 },
                    { 13, "7100 Szekszárd, Keselyűsi út 22.", "Személyszállítás", 13, new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Várkonyi tér 37.", 3 },
                    { 10, "5000 Szolnok, Kilián út 37.", "Áruszállítás", 10, new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Szolnok, Nagy József út 37.", 16 },
                    { 7, "5000 Szolnok, Ady Endre utca 156.", "Csomagszállítás", 7, new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Várkonyi tér 37.", 11 },
                    { 16, "6726 Szeged, Várkonyi tér 37.", "Áruszállítás", 4, new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "7100 Szekszárd, Keselyűsi út 22.", 18 },
                    { 4, "6726 Szeged, Szentesi utca 37.", "Áruszállítás", 4, new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Várkonyi tér 37.", 6 },
                    { 5, "5000 Szolnok, Szapáry utca 48.", "Személyszállítás", 5, new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "6726 Szeged, Várkonyi tér 37.", 3 },
                    { 15, "6726 Szeged, Várkonyi tér 37.", "Csomagszállítás", 15, new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "7100 Szekszárd, Keselyűsi út 22.", 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fuvarok_GepjarmuID",
                table: "Fuvarok",
                column: "GepjarmuID");

            migrationBuilder.CreateIndex(
                name: "IX_Fuvarok_SoforID",
                table: "Fuvarok",
                column: "SoforID");

            migrationBuilder.CreateIndex(
                name: "IX_Gepjarmuvek_TelephelyID",
                table: "Gepjarmuvek",
                column: "TelephelyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fuvarok");

            migrationBuilder.DropTable(
                name: "Gepjarmuvek");

            migrationBuilder.DropTable(
                name: "Soforok");

            migrationBuilder.DropTable(
                name: "Telephelyek");
        }
    }
}
