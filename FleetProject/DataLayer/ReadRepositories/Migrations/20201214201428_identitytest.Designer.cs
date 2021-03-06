// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadRepositories;

namespace Repositories.Migrations
{
    [DbContext(typeof(AllphiFleetContext))]
    [Migration("20201214201428_identitytest")]
    partial class identitytest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Aanvraag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumAanvraag")
                        .HasColumnType("datetime2");

                    b.Property<string>("GewensteData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusAanvraag")
                        .HasColumnType("int");

                    b.Property<int>("TypeAanvraag")
                        .HasColumnType("int");

                    b.Property<long>("VoertuigId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Aanvraag");
                });

            modelBuilder.Entity("Models.Adres", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.Property<int>("Postcode")
                        .HasColumnType("int");

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adressen");
                });

            modelBuilder.Entity("Models.Auth.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Models.Chauffeur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Actief")
                        .HasColumnType("bit");

                    b.Property<long>("AdresId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RijksRegisterNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TankkaartId")
                        .HasColumnType("bigint");

                    b.Property<int>("TypeRijbewijs")
                        .HasColumnType("int");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("TankkaartId");

                    b.ToTable("Chauffeurs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Actief = true,
                            AdresId = 1L,
                            GeboorteDatum = new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Bob",
                            RijksRegisterNummer = "999-888-7777",
                            TankkaartId = 1L,
                            TypeRijbewijs = 2,
                            Voornaam = "Uncle"
                        },
                        new
                        {
                            Id = 2L,
                            Actief = true,
                            AdresId = 2L,
                            GeboorteDatum = new DateTime(1989, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Breem",
                            RijksRegisterNummer = "999-888-1111",
                            TankkaartId = 2L,
                            TypeRijbewijs = 1,
                            Voornaam = "Rik"
                        });
                });

            modelBuilder.Entity("Models.Factuur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("NaamGefactureerde")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factuur");
                });

            modelBuilder.Entity("Models.Herstelling", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumHerstelling")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documenten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fotos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchadeOmschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VerzekeringsMaatschappijId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VerzekeringsMaatschappijId");

                    b.ToTable("Herstelling");
                });

            modelBuilder.Entity("Models.Nummerplaat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("NummerPlaatTekens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VoertuigId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Nummerplaat");
                });

            modelBuilder.Entity("Models.Onderhoud", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DatumOnderhoud")
                        .HasColumnType("datetime2");

                    b.Property<long>("FactuurId")
                        .HasColumnType("bigint");

                    b.Property<string>("Garage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("VoertuigId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FactuurId");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Onderhoud");
                });

            modelBuilder.Entity("Models.Tankkaart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("AuthType")
                        .HasColumnType("int");

                    b.Property<DateTime>("GeldigheidsDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Kaartnummer")
                        .HasColumnType("int");

                    b.Property<string>("Opties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tankkaarten");
                });

            modelBuilder.Entity("Models.VerzekeringsMaatschappij", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("ReferentieNrVerzekeringsMaatschappij")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VerzekeringsMaatschappij");
                });

            modelBuilder.Entity("Models.Voertuig", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ChassisNr")
                        .HasColumnType("bigint");

                    b.Property<int>("KilometerStand")
                        .HasColumnType("int");

                    b.Property<int>("TypeBrandStof")
                        .HasColumnType("int");

                    b.Property<int>("TypeWagen")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Voertuig");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Aanvraag", b =>
                {
                    b.HasOne("Models.Voertuig", "Voertuig")
                        .WithMany("Aanvragen")
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("Models.Chauffeur", b =>
                {
                    b.HasOne("Models.Adres", "Adres")
                        .WithMany("Chauffeurs")
                        .HasForeignKey("AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Tankkaart", "Tankkaart")
                        .WithMany("Chauffeurs")
                        .HasForeignKey("TankkaartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");

                    b.Navigation("Tankkaart");
                });

            modelBuilder.Entity("Models.Herstelling", b =>
                {
                    b.HasOne("Models.VerzekeringsMaatschappij", "VerzekeringsMaatschappij")
                        .WithMany("Herstellingen")
                        .HasForeignKey("VerzekeringsMaatschappijId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VerzekeringsMaatschappij");
                });

            modelBuilder.Entity("Models.Nummerplaat", b =>
                {
                    b.HasOne("Models.Voertuig", "Voertuig")
                        .WithMany("Nummerplaten")
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("Models.Onderhoud", b =>
                {
                    b.HasOne("Models.Factuur", "Factuur")
                        .WithMany("OnderhoudenOpFactuur")
                        .HasForeignKey("FactuurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Voertuig", "Voertuig")
                        .WithMany("OnderhoudsBeurten")
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factuur");

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("Models.Adres", b =>
                {
                    b.Navigation("Chauffeurs");
                });

            modelBuilder.Entity("Models.Factuur", b =>
                {
                    b.Navigation("OnderhoudenOpFactuur");
                });

            modelBuilder.Entity("Models.Tankkaart", b =>
                {
                    b.Navigation("Chauffeurs");
                });

            modelBuilder.Entity("Models.VerzekeringsMaatschappij", b =>
                {
                    b.Navigation("Herstellingen");
                });

            modelBuilder.Entity("Models.Voertuig", b =>
                {
                    b.Navigation("Aanvragen");

                    b.Navigation("Nummerplaten");

                    b.Navigation("OnderhoudsBeurten");
                });
#pragma warning restore 612, 618
        }
    }
}
