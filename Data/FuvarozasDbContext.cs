using Microsoft.EntityFrameworkCore;
using System;
using WebDiszpecser.Models;

namespace WebDiszpecser.Data
{
    public class FuvarozasDbContext : DbContext
    {
        public DbSet<Sofor> Soforok { get; set; }
        public DbSet<Fuvar> Fuvarok { get; set; }
        public DbSet<Telephely> Telephelyek { get; set; }
        public DbSet<Gepjarmu> Gepjarmuvek { get; set; }

        public FuvarozasDbContext(DbContextOptions<FuvarozasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sofor>().HasData(
                new Sofor {
                    SoforID = 1,
                    Csaladnev = "Gulyás",
                    Keresztnev = "János",
                    SzulIdo = DateTime.Parse("1985-05-14"),
                    JogositvanySzam = "1234EA",
                    Kategoria = Kategoria.B,
                    Ervenyesseg = DateTime.Parse("2025-03-12")
                },
                new Sofor {
                    SoforID = 2,
                    Csaladnev = "Csukás",
                    Keresztnev = "Géza",
                    SzulIdo = DateTime.Parse("1975-04-25"),
                    JogositvanySzam = "2143SD",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2023-10-05")
                },
                new Sofor {
                    SoforID = 3,
                    Csaladnev = "Borsfalvy",
                    Keresztnev = "Győző",
                    SzulIdo = DateTime.Parse("1984-01-02"),
                    JogositvanySzam = "5476VC",
                    Kategoria = Kategoria.D,
                    Ervenyesseg = DateTime.Parse("2024-05-06")
                },
                new Sofor {
                    SoforID = 4,
                    Csaladnev = "Kiss",
                    Keresztnev = "Márton",
                    SzulIdo = DateTime.Parse("1983-03-02"),
                    JogositvanySzam = "5786VL",
                    Kategoria = Kategoria.E,
                    Ervenyesseg = DateTime.Parse("2024-07-06")
                },
                new Sofor {
                    SoforID = 5,
                    Csaladnev = "Nagy",
                    Keresztnev = "Béla",
                    SzulIdo = DateTime.Parse("1973-03-02"),
                    JogositvanySzam = "6586BL",
                    Kategoria = Kategoria.B,
                    Ervenyesseg = DateTime.Parse("2025-07-06")
                },
                new Sofor {
                    SoforID = 6,
                    Csaladnev = "Boros",
                    Keresztnev = "Béla",
                    SzulIdo = DateTime.Parse("1987-03-21"),
                    JogositvanySzam = "6126FL",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2025-04-06")
                },
                new Sofor {
                    SoforID = 7,
                    Csaladnev = "Mézga",
                    Keresztnev = "Géza",
                    SzulIdo = DateTime.Parse("1980-11-21"),
                    JogositvanySzam = "3698FL",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2024-10-06")
                },
                new Sofor {
                    SoforID = 8,
                    Csaladnev = "Mézga",
                    Keresztnev = "Aladár",
                    SzulIdo = DateTime.Parse("1989-12-06"),
                    JogositvanySzam = "3789GL",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2024-10-14")
                },
                new Sofor {
                    SoforID = 9,
                    Csaladnev = "Sziráki",
                    Keresztnev = "József",
                    SzulIdo = DateTime.Parse("1989-08-06"),
                    JogositvanySzam = "3129GL",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2024-10-14")
                },
                new Sofor {
                    SoforID = 10,
                    Csaladnev = "Döbrögi",
                    Keresztnev = "József",
                    SzulIdo = DateTime.Parse("1978-08-06"),
                    JogositvanySzam = "3544GL",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2024-06-14")
                },
                new Sofor {
                    SoforID = 11,
                    Csaladnev = "Ludas",
                    Keresztnev = "Mátyás",
                    SzulIdo = DateTime.Parse("1978-08-13"),
                    JogositvanySzam = "3544GL",
                    Kategoria = Kategoria.B,
                    Ervenyesseg = DateTime.Parse("2021-06-14")
                },
                new Sofor {
                    SoforID = 12,
                    Csaladnev = "Martonyi",
                    Keresztnev = "István",
                    SzulIdo = DateTime.Parse("1976-08-13"),
                    JogositvanySzam = "8844KL",
                    Kategoria = Kategoria.B,
                    Ervenyesseg = DateTime.Parse("2021-06-24")
                },
                new Sofor {
                    SoforID = 13,
                    Csaladnev = "Békési",
                    Keresztnev = "Bertold",
                    SzulIdo = DateTime.Parse("1979-06-13"),
                    JogositvanySzam = "8844KL",
                    Kategoria = Kategoria.E,
                    Ervenyesseg = DateTime.Parse("2021-05-24")
                },
                new Sofor {
                    SoforID = 14,
                    Csaladnev = "Márkus",
                    Keresztnev = "Iván",
                    SzulIdo = DateTime.Parse("1979-06-02"),
                    JogositvanySzam = "8845GH",
                    Kategoria = Kategoria.E,
                    Ervenyesseg = DateTime.Parse("2021-04-24")
                },
                new Sofor {
                    SoforID = 15,
                    Csaladnev = "Meggyesi",
                    Keresztnev = "Ödön",
                    SzulIdo = DateTime.Parse("1979-08-02"),
                    JogositvanySzam = "3445GH",
                    Kategoria = Kategoria.E,
                    Ervenyesseg = DateTime.Parse("2020-04-24")
                },
                new Sofor {
                    SoforID = 16,
                    Csaladnev = "Bajai",
                    Keresztnev = "Zoltán",
                    SzulIdo = DateTime.Parse("1981-08-02"),
                    JogositvanySzam = "2045GH",
                    Kategoria = Kategoria.E,
                    Ervenyesseg = DateTime.Parse("2022-03-24")
                },
                new Sofor {
                    SoforID = 17,
                    Csaladnev = "Mészöly",
                    Keresztnev = "Tibor",
                    SzulIdo = DateTime.Parse("1981-08-15"),
                    JogositvanySzam = "2885GH",
                    Kategoria = Kategoria.E,
                    Ervenyesseg = DateTime.Parse("2022-03-25")
                },
                new Sofor {
                    SoforID = 18,
                    Csaladnev = "Vágó",
                    Keresztnev = "Botond",
                    SzulIdo = DateTime.Parse("1987-08-15"),
                    JogositvanySzam = "9985GH",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2022-02-25")
                },
                new Sofor {
                    SoforID = 19,
                    Csaladnev = "Borkodi",
                    Keresztnev = "Olivér",
                    SzulIdo = DateTime.Parse("1988-08-15"),
                    JogositvanySzam = "9977GH",
                    Kategoria = Kategoria.B,
                    Ervenyesseg = DateTime.Parse("2023-02-25")
                },
                new Sofor {
                    SoforID = 20,
                    Csaladnev = "Vörös",
                    Keresztnev = "Dávid",
                    SzulIdo = DateTime.Parse("1990-08-15"),
                    JogositvanySzam = "9117GH",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2026-02-25")
                },
                new Sofor
                {
                    SoforID = 21,
                    Csaladnev = "Várkonyi",
                    Keresztnev = "Emil",
                    SzulIdo = DateTime.Parse("1991-01-15"),
                    JogositvanySzam = "9447GH",
                    Kategoria = Kategoria.C,
                    Ervenyesseg = DateTime.Parse("2021-01-25")
                });

            modelBuilder.Entity<Gepjarmu>().HasData(
                new Gepjarmu {
                    GepjarmuID = 1,
                    Tipus = "MB1017",
                    Rendszam = "FGH345",
                    Kategoria = Kategoria.C,
                    FutottKm = 120000,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2019-01-03"),
                    TelephelyID = 1
                },
                new Gepjarmu {
                    GepjarmuID = 2,
                    Tipus = "MB1017",
                    Rendszam = "MNB123",
                    Kategoria = Kategoria.C,
                    FutottKm = 124070,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2019-04-03"),
                    TelephelyID = 2
                },
                new Gepjarmu {
                    GepjarmuID = 3,
                    Tipus = "Rába H14",
                    Rendszam = "GKT786",
                    Kategoria = Kategoria.C,
                    FutottKm = 65120,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2018-04-03"),
                    TelephelyID = 3
                },
                new Gepjarmu {
                    GepjarmuID = 4,
                    Tipus = "Rába H14",
                    Rendszam = "GKJ786",
                    Kategoria = Kategoria.C,
                    FutottKm = 67120,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2018-05-03"),
                    TelephelyID = 1
                },
                new Gepjarmu {
                    GepjarmuID = 5,
                    Tipus = "Ikarusz 452",
                    Rendszam = "HBJ786",
                    Kategoria = Kategoria.D,
                    FutottKm = 260120,
                    SzervizCiklus = 50000,
                    UtolsoSzerviz = DateTime.Parse("2019-07-03"),
                    TelephelyID = 2
                },
                new Gepjarmu {
                    GepjarmuID = 6,
                    Tipus = "Mercedes Sprinter",
                    Rendszam = "GKZ667",
                    Kategoria = Kategoria.B,
                    FutottKm = 100450,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2019-09-03"),
                    TelephelyID = 3
                },
                new Gepjarmu {
                    GepjarmuID = 7,
                    Tipus = "Mercedes Sprinter",
                    Rendszam = "GKZ657",
                    Kategoria = Kategoria.B,
                    FutottKm = 104450,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2018-09-03"),
                    TelephelyID = 1
                },
                new Gepjarmu {
                    GepjarmuID = 8,
                    Tipus = "MAN 3220",
                    Rendszam = "GTZ457",
                    Kategoria = Kategoria.E,
                    FutottKm = 570450,
                    SzervizCiklus = 50000,
                    UtolsoSzerviz = DateTime.Parse("2018-12-03"),
                    TelephelyID = 2
                },
                new Gepjarmu {
                    GepjarmuID = 9,
                    Tipus = "DAF 20",
                    Rendszam = "RTU345",
                    Kategoria = Kategoria.E,
                    FutottKm = 570580,
                    SzervizCiklus = 50000,
                    UtolsoSzerviz = DateTime.Parse("2017-12-03"),
                    TelephelyID = 3
                },
                new Gepjarmu {
                    GepjarmuID = 10,
                    Tipus = "DAF 20",
                    Rendszam = "RTU785",
                    Kategoria = Kategoria.E,
                    FutottKm = 540580,
                    SzervizCiklus = 50000,
                    UtolsoSzerviz = DateTime.Parse("2018-02-03"),
                    TelephelyID = 1
                },
                new Gepjarmu {
                    GepjarmuID = 11,
                    Tipus = "VW T6",
                    Rendszam = "GHU785",
                    Kategoria = Kategoria.B,
                    FutottKm = 54580,
                    SzervizCiklus = 15000,
                    UtolsoSzerviz = DateTime.Parse("2018-06-03"),
                    TelephelyID = 2
                },
                new Gepjarmu {
                    GepjarmuID = 12,
                    Tipus = "VW T6",
                    Rendszam = "GJU785",
                    Kategoria = Kategoria.B,
                    FutottKm = 60580,
                    SzervizCiklus = 15000,
                    UtolsoSzerviz = DateTime.Parse("2019-06-03"),
                    TelephelyID = 3
                },
                new Gepjarmu {
                    GepjarmuID = 13,
                    Tipus = "VW LT-4",
                    Rendszam = "DFU965",
                    Kategoria = Kategoria.B,
                    FutottKm = 280580,
                    SzervizCiklus = 15000,
                    UtolsoSzerviz = DateTime.Parse("2019-07-03"),
                    TelephelyID = 1
                },
                new Gepjarmu {
                    GepjarmuID = 14,
                    Tipus = "VW Golf Variant",
                    Rendszam = "LFU965",
                    Kategoria = Kategoria.B,
                    FutottKm = 10580,
                    SzervizCiklus = 30000,
                    UtolsoSzerviz = DateTime.Parse("2019-10-03"),
                    TelephelyID = 2
                },
                new Gepjarmu {
                    GepjarmuID = 15,
                    Tipus = "Renault Jumper",
                    Rendszam = "HJU895",
                    Kategoria = Kategoria.B,
                    FutottKm = 150580,
                    SzervizCiklus = 15000,
                    UtolsoSzerviz = DateTime.Parse("2018-11-03"),
                    TelephelyID = 3
                });

            modelBuilder.Entity<Telephely>().HasData(
                new Telephely {
                    TelephelyID = 1,
                    TelephelyCim = "6726 Szeged, Bécsi körút 21."
                },
                new Telephely {
                    TelephelyID = 2,
                    TelephelyCim = "5000 Szolnok, Ady Endre utca 156."
                },
                new Telephely {
                    TelephelyID = 3,
                    TelephelyCim = "7100 Szekszárd, Keselyűsi út 22."
                });

            modelBuilder.Entity<Fuvar>().HasData(
                new Fuvar {
                    FuvarID = 1,
                    Feladat = "Bútorszállítás",
                    BerakoCim = "5000 Szolnok, Kossuth utca 48.",
                    KirakoCim = "6726 Szeged, Szapolyai utca 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-21"),
                    GepjarmuID = 1,
                    SoforID = 2
                },
                new Fuvar {
                    FuvarID = 2,
                    Feladat = "Hulladékszállítás",
                    BerakoCim = "5000 Szolnok, Szapáry utca 48.",
                    KirakoCim = "5000 Szolnok, Tulipán utca 48.",
                    IndulasIdeje = DateTime.Parse("2019-10-23"),
                    GepjarmuID = 2,
                    SoforID = 6
                },
                new Fuvar {
                    FuvarID = 3,
                    Feladat = "Áruszállítás",
                    BerakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    KirakoCim = "7100 Szekszárd, Alisca utca 22.",
                    IndulasIdeje = DateTime.Parse("2019-10-14"),
                    GepjarmuID = 3,
                    SoforID = 2
                },
                new Fuvar {
                    FuvarID = 4,
                    Feladat = "Áruszállítás",
                    BerakoCim = "6726 Szeged, Szentesi utca 37.",
                    KirakoCim = "6726 Szeged, Várkonyi tér 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-16"),
                    GepjarmuID = 4,
                    SoforID = 6
                },
                new Fuvar {
                    FuvarID = 5,
                    Feladat = "Személyszállítás",
                    BerakoCim = "5000 Szolnok, Szapáry utca 48.",
                    KirakoCim = "6726 Szeged, Várkonyi tér 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-28"),
                    GepjarmuID = 5,
                    SoforID = 3
                },
                new Fuvar {
                    FuvarID = 6,
                    Feladat = "Csomagszállítás",
                    BerakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    KirakoCim = "6726 Szeged, Várkonyi tér 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-28"),
                    GepjarmuID = 6,
                    SoforID = 19
                },
                new Fuvar {
                    FuvarID = 7,
                    Feladat = "Csomagszállítás",
                    BerakoCim = "5000 Szolnok, Ady Endre utca 156.",
                    KirakoCim = "6726 Szeged, Várkonyi tér 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-29"),
                    GepjarmuID = 7,
                    SoforID = 11
                },
                new Fuvar {
                    FuvarID = 8,
                    Feladat = "Áruszállítás",
                    BerakoCim = "6726 Szeged, Várkonyi tér 37.",
                    KirakoCim = "5000 Szolnok, Kilián út 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-19"),
                    GepjarmuID = 8,
                    SoforID = 17
                },
                new Fuvar {
                    FuvarID = 9,
                    Feladat = "Áruszállítás",
                    BerakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    KirakoCim = "5000 Szolnok, Kilián út 37.",
                    IndulasIdeje = DateTime.Parse("2019-10-17"),
                    GepjarmuID = 9,
                    SoforID = 15
                },
                new Fuvar {
                    FuvarID = 10,
                    Feladat = "Áruszállítás",
                    BerakoCim = "5000 Szolnok, Kilián út 37.",
                    KirakoCim = "5000 Szolnok, Nagy József út 37.",
                    IndulasIdeje = DateTime.Parse("2019-11-12"),
                    GepjarmuID = 10,
                    SoforID = 16
                },
                new Fuvar {
                    FuvarID = 11,
                    Feladat = "Személyszállítás",
                    BerakoCim = "6726 Szeged, Várkonyi tér 37.",
                    KirakoCim = "5000 Szolnok, Nagy József út 37.",
                    IndulasIdeje = DateTime.Parse("2019-11-05"),
                    GepjarmuID = 11,
                    SoforID = 21
                },
                new Fuvar {
                    FuvarID = 12,
                    Feladat = "Személyszállítás",
                    BerakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    KirakoCim = "6726 Szeged, Várkonyi tér 37.",
                    IndulasIdeje = DateTime.Parse("2019-11-03"),
                    GepjarmuID = 12,
                    SoforID = 1
                },
                new Fuvar {
                    FuvarID = 13,
                    Feladat = "Személyszállítás",
                    BerakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    KirakoCim = "6726 Szeged, Várkonyi tér 37.",
                    IndulasIdeje = DateTime.Parse("2019-11-14"),
                    GepjarmuID = 13,
                    SoforID = 3
                },
                new Fuvar {
                    FuvarID = 14,
                    Feladat = "Személyszállítás",
                    BerakoCim = "5000 Szolnok, Nagy József út 37.",
                    KirakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    IndulasIdeje = DateTime.Parse("2019-11-13"),
                    GepjarmuID = 14,
                    SoforID = 19
                },
                new Fuvar {
                    FuvarID = 15,
                    Feladat = "Csomagszállítás",
                    BerakoCim = "6726 Szeged, Várkonyi tér 37.",
                    KirakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    IndulasIdeje = DateTime.Parse("2019-11-17"),
                    GepjarmuID = 15,
                    SoforID = 19
                },
                new Fuvar {
                    FuvarID = 16,
                    Feladat = "Áruszállítás",
                    BerakoCim = "6726 Szeged, Várkonyi tér 37.",
                    KirakoCim = "7100 Szekszárd, Keselyűsi út 22.",
                    IndulasIdeje = DateTime.Parse("2019-11-19"),
                    GepjarmuID = 4,
                    SoforID = 18
                },
                new Fuvar {
                    FuvarID = 17,
                    Feladat = "Személyszállítás",
                    BerakoCim = "6726 Szeged, Várkonyi tér 37.",
                    KirakoCim = "5000 Szolnok, Nagy József út 37.",
                    IndulasIdeje = DateTime.Parse("2019-11-20"),
                    GepjarmuID = 5,
                    SoforID = 3
                });
        }
    }
}
