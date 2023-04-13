using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Group1_5_FagelGamous.Data.Entities;

namespace Group1_5_FagelGamous.Data
{
    public partial class MummyContext : DbContext
    {
        public MummyContext()
        {
        }

        public MummyContext(DbContextOptions<MummyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analysis> Analyses { get; set; } = null!;
        public virtual DbSet<Burialmain> Burialmains { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Decoration> Decorations { get; set; } = null!;
        public virtual DbSet<Dimension> Dimensions { get; set; } = null!;
        public virtual DbSet<Photodatum> Photodata { get; set; } = null!;
        public virtual DbSet<Photoform> Photoforms { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Structure> Structures { get; set; } = null!;
        public virtual DbSet<Teammember> Teammembers { get; set; } = null!;
        public virtual DbSet<Textile> Textiles { get; set; } = null!;
        public virtual DbSet<Textilefunction> Textilefunctions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Yarnmanipulation> Yarnmanipulations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionStrings:MyMummyDbConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.ToTable("analysis");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(1000L);

                entity.Property(e => e.Analysisid).HasColumnName("analysisid");

                entity.Property(e => e.Analysistype).HasColumnName("analysistype");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");

                entity.Property(e => e.Doneby)
                    .HasMaxLength(100)
                    .HasColumnName("doneby");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainAnalyses)
                    .UsingEntity<Dictionary<string, object>>(
                        "AnalysisTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("fk_textile"),
                        r => r.HasOne<Analysis>().WithMany().HasForeignKey("MainAnalysisid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("Fk_analysis"),
                        j =>
                        {
                            j.HasKey("MainAnalysisid", "MainTextileid").HasName("main$analysis_textile_pkey");

                            j.ToTable("analysis_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainAnalysisid" }, "idx_main$analysis_textile_main$textile_main$analysis");

                            j.IndexerProperty<int>("MainAnalysisid").HasColumnName("main$analysisid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Burialmain>(entity =>
            {
                entity.ToTable("burialmain");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(2200L);

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid).HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.Text)
                    .HasMaxLength(2000)
                    .HasColumnName("text");

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainBurialmains)
                    .UsingEntity<Dictionary<string, object>>(
                        "BurialmainTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("Fk_textile"),
                        r => r.HasOne<Burialmain>().WithMany().HasForeignKey("MainBurialmainid").HasConstraintName("Fk_burial"),
                        j =>
                        {
                            j.HasKey("MainBurialmainid", "MainTextileid").HasName("main$burialmain_textile_pkey");

                            j.ToTable("burialmain_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainBurialmainid" }, "idx_main$burialmain_textile_main$textile_main$burialmain");

                            j.IndexerProperty<int>("MainBurialmainid").HasColumnName("main$burialmainid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(110L);

                entity.Property(e => e.Colorid).HasColumnName("colorid");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainColors)
                    .UsingEntity<Dictionary<string, object>>(
                        "ColorTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("Fk_textile"),
                        r => r.HasOne<Color>().WithMany().HasForeignKey("MainColorid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("Fk_color"),
                        j =>
                        {
                            j.HasKey("MainColorid", "MainTextileid").HasName("main$color_textile_pkey");

                            j.ToTable("color_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainColorid" }, "idx_main$color_textile_main$textile_main$color");

                            j.IndexerProperty<int>("MainColorid").HasColumnName("main$colorid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Decoration>(entity =>
            {
                entity.ToTable("decoration");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(35L);

                entity.Property(e => e.Decorationid).HasColumnName("decorationid");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainDecorations)
                    .UsingEntity<Dictionary<string, object>>(
                        "DecorationTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("Fk_textile"),
                        r => r.HasOne<Decoration>().WithMany().HasForeignKey("MainDecorationid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("Fk_decoration"),
                        j =>
                        {
                            j.HasKey("MainDecorationid", "MainTextileid").HasName("main$decoration_textile_pkey");

                            j.ToTable("decoration_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainDecorationid" }, "idx_main$decoration_textile_main$textile_main$decoration");

                            j.IndexerProperty<int>("MainDecorationid").HasColumnName("main$decorationid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.ToTable("dimension");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(500L);

                entity.Property(e => e.Dimensionid).HasColumnName("dimensionid");

                entity.Property(e => e.Dimensiontype)
                    .HasMaxLength(500)
                    .HasColumnName("dimensiontype");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainDimensions)
                    .UsingEntity<Dictionary<string, object>>(
                        "DimensionTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("Fk_textile"),
                        r => r.HasOne<Dimension>().WithMany().HasForeignKey("MainDimensionid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("Fk_dimension"),
                        j =>
                        {
                            j.HasKey("MainDimensionid", "MainTextileid").HasName("main$dimension_textile_pkey");

                            j.ToTable("dimension_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainDimensionid" }, "idx_main$dimension_textile_main$textile_main$dimension");

                            j.IndexerProperty<int>("MainDimensionid").HasColumnName("main$dimensionid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Photodatum>(entity =>
            {
                entity.ToTable("photodata");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(960L);

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Filename)
                    .HasMaxLength(200)
                    .HasColumnName("filename");

                entity.Property(e => e.Photodataid).HasColumnName("photodataid");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("url");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainPhotodata)
                    .UsingEntity<Dictionary<string, object>>(
                        "PhotodataTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("fk_textile"),
                        r => r.HasOne<Photodatum>().WithMany().HasForeignKey("MainPhotodataid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("fk_photodata"),
                        j =>
                        {
                            j.HasKey("MainPhotodataid", "MainTextileid").HasName("main$photodata_textile_pkey");

                            j.ToTable("photodata_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainPhotodataid" }, "idx_main$photodata_textile_main$textile_main$photodata");

                            j.IndexerProperty<int>("MainPhotodataid").HasColumnName("main$photodataid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Photoform>(entity =>
            {
                entity.ToTable("photoform");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .HasColumnName("area");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(10)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(1)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Filename)
                    .HasMaxLength(200)
                    .HasColumnName("filename");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(1)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Photodate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("photodate");

                entity.Property(e => e.Photographer)
                    .HasMaxLength(100)
                    .HasColumnName("photographer");

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(100)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(5)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.Tableassociation)
                    .HasMaxLength(10)
                    .HasColumnName("tableassociation");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.ToTable("structure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(140L);

                entity.Property(e => e.Structureid).HasColumnName("structureid");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainStructures)
                    .UsingEntity<Dictionary<string, object>>(
                        "StructureTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("fk_textile"),
                        r => r.HasOne<Structure>().WithMany().HasForeignKey("MainStructureid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("fk_structure"),
                        j =>
                        {
                            j.HasKey("MainStructureid", "MainTextileid").HasName("main$structure_textile_pkey");

                            j.ToTable("structure_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainStructureid" }, "idx_main$structure_textile_main$textile_main$structure");

                            j.IndexerProperty<int>("MainStructureid").HasColumnName("main$structureid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<Teammember>(entity =>
            {
                entity.ToTable("teammember");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Bio)
                    .HasColumnType("character varying")
                    .HasColumnName("bio");

                entity.Property(e => e.Membername)
                    .HasMaxLength(200)
                    .HasColumnName("membername");
            });

            modelBuilder.Entity<Textile>(entity =>
            {
                entity.ToTable("textile");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(1200L);

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .HasMaxLength(200)
                    .HasColumnName("direction");

                entity.Property(e => e.Estimatedperiod)
                    .HasMaxLength(200)
                    .HasColumnName("estimatedperiod");

                entity.Property(e => e.Locale)
                    .HasMaxLength(200)
                    .HasColumnName("locale");

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Sampledate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("sampledate");

                entity.Property(e => e.Textileid).HasColumnName("textileid");
            });

            modelBuilder.Entity<Textilefunction>(entity =>
            {
                entity.ToTable("textilefunction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(1150L);

                entity.Property(e => e.Textilefunctionid).HasColumnName("textilefunctionid");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainTextilefunctions)
                    .UsingEntity<Dictionary<string, object>>(
                        "TextilefunctionTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("fk_textile"),
                        r => r.HasOne<Textilefunction>().WithMany().HasForeignKey("MainTextilefunctionid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("fk_textilefunction"),
                        j =>
                        {
                            j.HasKey("MainTextilefunctionid", "MainTextileid").HasName("main$textilefunction_textile_pkey");

                            j.ToTable("textilefunction_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainTextilefunctionid" }, "idx_main$textilefunction_textile");

                            j.IndexerProperty<int>("MainTextilefunctionid").HasColumnName("main$textilefunctionid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "unique_email")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_roles");
            });

            modelBuilder.Entity<Yarnmanipulation>(entity =>
            {
                entity.ToTable("yarnmanipulation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(1250L);

                entity.Property(e => e.Angle)
                    .HasMaxLength(20)
                    .HasColumnName("angle");

                entity.Property(e => e.Component)
                    .HasMaxLength(200)
                    .HasColumnName("component");

                entity.Property(e => e.Count)
                    .HasMaxLength(100)
                    .HasColumnName("count");

                entity.Property(e => e.Direction)
                    .HasMaxLength(20)
                    .HasColumnName("direction");

                entity.Property(e => e.Manipulation)
                    .HasMaxLength(100)
                    .HasColumnName("manipulation");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .HasColumnName("material");

                entity.Property(e => e.Ply)
                    .HasMaxLength(20)
                    .HasColumnName("ply");

                entity.Property(e => e.Thickness)
                    .HasMaxLength(20)
                    .HasColumnName("thickness");

                entity.Property(e => e.Yarnmanipulationid).HasColumnName("yarnmanipulationid");

                entity.HasMany(d => d.MainTextiles)
                    .WithMany(p => p.MainYarnmanipulations)
                    .UsingEntity<Dictionary<string, object>>(
                        "YarnmanipulationTextile",
                        l => l.HasOne<Textile>().WithMany().HasForeignKey("MainTextileid").HasConstraintName("fk_textile"),
                        r => r.HasOne<Yarnmanipulation>().WithMany().HasForeignKey("MainYarnmanipulationid").OnDelete(DeleteBehavior.SetNull).HasConstraintName("fk_yarnmanipulation"),
                        j =>
                        {
                            j.HasKey("MainYarnmanipulationid", "MainTextileid").HasName("main$yarnmanipulation_textile_pkey");

                            j.ToTable("yarnmanipulation_textile");

                            j.HasIndex(new[] { "MainTextileid", "MainYarnmanipulationid" }, "idx_main$yarnmanipulation_textile");

                            j.IndexerProperty<int>("MainYarnmanipulationid").HasColumnName("main$yarnmanipulationid");

                            j.IndexerProperty<int>("MainTextileid").HasColumnName("main$textileid");
                        });
            });

            modelBuilder.HasSequence("excelimporter$template_nr_mxseq");

            modelBuilder.HasSequence("system$filedocument_fileid_mxseq");

            modelBuilder.HasSequence("system$queuedtask_sequence_mxseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
