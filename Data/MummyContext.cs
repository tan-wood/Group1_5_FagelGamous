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
        public virtual DbSet<AnalysisTextile> AnalysisTextiles { get; set; } = null!;
        public virtual DbSet<Bodyanalysischart> Bodyanalysischarts { get; set; } = null!;
        public virtual DbSet<BurialmainTextile> BurialmainTextiles { get; set; } = null!;
        public virtual DbSet<Burialmain> Burialmains { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<ColorTextile> ColorTextiles { get; set; } = null!;
        public virtual DbSet<Decoration> Decorations { get; set; } = null!;
        public virtual DbSet<DecorationTextile> DecorationTextiles { get; set; } = null!;
        public virtual DbSet<Dimension> Dimensions { get; set; } = null!;
        public virtual DbSet<DimensionTextile> DimensionTextiles { get; set; } = null!;
        public virtual DbSet<PhotodataTextile> PhotodataTextiles { get; set; } = null!;
        public virtual DbSet<Photodatum> Photodata { get; set; } = null!;
        public virtual DbSet<Photoform> Photoforms { get; set; } = null!;
        public virtual DbSet<Structure> Structures { get; set; } = null!;
        public virtual DbSet<StructureTextile> StructureTextiles { get; set; } = null!;
        public virtual DbSet<Teammember> Teammembers { get; set; } = null!;
        public virtual DbSet<Textile> Textiles { get; set; } = null!;
        public virtual DbSet<Textilefunction> Textilefunctions { get; set; } = null!;
        public virtual DbSet<TextilefunctionTextile> TextilefunctionTextiles { get; set; } = null!;
        public virtual DbSet<Yarnmanipulation> Yarnmanipulations { get; set; } = null!;
        public virtual DbSet<YarnmanipulationTextile> YarnmanipulationTextiles { get; set; } = null!;

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
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Analysisid).HasColumnName("analysisid");

                entity.Property(e => e.Analysistype).HasColumnName("analysistype");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");

                entity.Property(e => e.Doneby)
                    .HasMaxLength(100)
                    .HasColumnName("doneby");
            });

            modelBuilder.Entity<AnalysisTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainAnalysisid, e.MainTextileid })
                    .HasName("main$analysis_textile_pkey");

                entity.ToTable("analysis_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainAnalysisid }, "idx_main$analysis_textile_main$textile_main$analysis");

                entity.Property(e => e.MainAnalysisid).HasColumnName("main$analysisid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });
            modelBuilder.Entity<BurialmainTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainBurialmainid, e.MainTextileid })
                    .HasName("main$burialmain_textile_pkey");

                entity.ToTable("burialmain_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainBurialmainid }, "idx_main$burialmain_textile_main$textile_main$burialmain");

                entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Bodyanalysischart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bodyanalysischart");

                entity.Property(e => e.Area)
                    .HasColumnType("character varying")
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("character varying")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("burialnumber");

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasColumnType("character varying")
                    .HasColumnName("caries_periodontal_disease");

                entity.Property(e => e.Dateofexamination).HasColumnName("dateofexamination");

                entity.Property(e => e.Dorsalpitting)
                    .HasColumnType("character varying")
                    .HasColumnName("dorsalpitting");

                entity.Property(e => e.Eastwest)
                    .HasColumnType("character varying")
                    .HasColumnName("eastwest");

                entity.Property(e => e.Estimatestature).HasColumnName("estimatestature");

                entity.Property(e => e.Femidurlength).HasColumnName("femidurlength");

                entity.Property(e => e.Femur)
                    .HasColumnType("character varying")
                    .HasColumnName("femur");

                entity.Property(e => e.Femurheaddiameter).HasColumnName("femurheaddiameter");

                entity.Property(e => e.Gonion)
                    .HasColumnType("character varying")
                    .HasColumnName("gonion");

                entity.Property(e => e.Haircolor)
                    .HasColumnType("character varying")
                    .HasColumnName("haircolor");

                entity.Property(e => e.Humerus)
                    .HasColumnType("character varying")
                    .HasColumnName("humerus");

                entity.Property(e => e.Humerusheaddiameter).HasColumnName("humerusheaddiameter");

                entity.Property(e => e.Humeruslength).HasColumnName("humeruslength");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lamboidsuture)
                    .HasColumnType("character varying")
                    .HasColumnName("lamboidsuture");

                entity.Property(e => e.MedialIpRamus)
                    .HasColumnType("character varying")
                    .HasColumnName("medial_ip_ramus");

                entity.Property(e => e.Northsouth)
                    .HasColumnType("character varying")
                    .HasColumnName("northsouth");

                entity.Property(e => e.Notes)
                    .HasColumnType("character varying")
                    .HasColumnName("notes");

                entity.Property(e => e.Nuchalcrest)
                    .HasColumnType("character varying")
                    .HasColumnName("nuchalcrest");

                entity.Property(e => e.Observations)
                    .HasColumnType("character varying")
                    .HasColumnName("observations");

                entity.Property(e => e.Orbitedge)
                    .HasColumnType("character varying")
                    .HasColumnName("orbitedge");

                entity.Property(e => e.Osteophytosis)
                    .HasColumnType("character varying")
                    .HasColumnName("osteophytosis");

                entity.Property(e => e.Parietalbossing)
                    .HasColumnType("character varying")
                    .HasColumnName("parietalbossing");

                entity.Property(e => e.Preauricularsulcus)
                    .HasColumnType("character varying")
                    .HasColumnName("preauricularsulcus");

                entity.Property(e => e.Preservationindex).HasColumnName("preservationindex");

                entity.Property(e => e.Pubicbone)
                    .HasColumnType("character varying")
                    .HasColumnName("pubicbone");

                entity.Property(e => e.Robust)
                    .HasColumnType("character varying")
                    .HasColumnName("robust");

                entity.Property(e => e.Sciaticnotch)
                    .HasColumnType("character varying")
                    .HasColumnName("sciaticnotch");

                entity.Property(e => e.Sphenooccipitalsynchrondrosis)
                    .HasColumnType("character varying")
                    .HasColumnName("sphenooccipitalsynchrondrosis");

                entity.Property(e => e.Squamossuture)
                    .HasColumnType("character varying")
                    .HasColumnName("squamossuture");

                entity.Property(e => e.Squareeastwest)
                    .HasColumnType("character varying")
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasColumnType("character varying")
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.Subpubicangle)
                    .HasColumnType("character varying")
                    .HasColumnName("subpubicangle");

                entity.Property(e => e.Supraorbitalridges)
                    .HasColumnType("character varying")
                    .HasColumnName("supraorbitalridges");

                entity.Property(e => e.Tibia).HasColumnName("tibia");

                entity.Property(e => e.Toothattrition)
                    .HasColumnType("character varying")
                    .HasColumnName("toothattrition");

                entity.Property(e => e.Tootheruption)
                    .HasColumnType("character varying")
                    .HasColumnName("tootheruption");

                entity.Property(e => e.Tootheruptionageestimate)
                    .HasColumnType("character varying")
                    .HasColumnName("tootheruptionageestimate");

                entity.Property(e => e.Ventralarc)
                    .HasColumnType("character varying")
                    .HasColumnName("ventralarc");

                entity.Property(e => e.Zygomaticcrest)
                    .HasColumnType("character varying")
                    .HasColumnName("zygomaticcrest");
            });

            modelBuilder.Entity<Burialmain>(entity =>
            {
                entity.ToTable("burialmain");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Colorid).HasColumnName("colorid");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<ColorTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainColorid, e.MainTextileid })
                    .HasName("main$color_textile_pkey");

                entity.ToTable("color_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainColorid }, "idx_main$color_textile_main$textile_main$color");

                entity.Property(e => e.MainColorid).HasColumnName("main$colorid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Decoration>(entity =>
            {
                entity.ToTable("decoration");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Decorationid).HasColumnName("decorationid");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DecorationTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainDecorationid, e.MainTextileid })
                    .HasName("main$decoration_textile_pkey");

                entity.ToTable("decoration_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainDecorationid }, "idx_main$decoration_textile_main$textile_main$decoration");

                entity.Property(e => e.MainDecorationid).HasColumnName("main$decorationid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.ToTable("dimension");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Dimensionid).HasColumnName("dimensionid");

                entity.Property(e => e.Dimensiontype)
                    .HasMaxLength(500)
                    .HasColumnName("dimensiontype");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DimensionTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainDimensionid, e.MainTextileid })
                    .HasName("main$dimension_textile_pkey");

                entity.ToTable("dimension_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainDimensionid }, "idx_main$dimension_textile_main$textile_main$dimension");

                entity.Property(e => e.MainDimensionid).HasColumnName("main$dimensionid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<PhotodataTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainPhotodataid, e.MainTextileid })
                    .HasName("main$photodata_textile_pkey");

                entity.ToTable("photodata_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainPhotodataid }, "idx_main$photodata_textile_main$textile_main$photodata");

                entity.Property(e => e.MainPhotodataid).HasColumnName("main$photodataid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Photodatum>(entity =>
            {
                entity.ToTable("photodata");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.ToTable("structure");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Structureid).HasColumnName("structureid");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<StructureTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainStructureid, e.MainTextileid })
                    .HasName("main$structure_textile_pkey");

                entity.ToTable("structure_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainStructureid }, "idx_main$structure_textile_main$textile_main$structure");

                entity.Property(e => e.MainStructureid).HasColumnName("main$structureid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
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
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Textilefunctionid).HasColumnName("textilefunctionid");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<TextilefunctionTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainTextilefunctionid, e.MainTextileid })
                    .HasName("main$textilefunction_textile_pkey");

                entity.ToTable("textilefunction_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainTextilefunctionid }, "idx_main$textilefunction_textile");

                entity.Property(e => e.MainTextilefunctionid).HasColumnName("main$textilefunctionid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Yarnmanipulation>(entity =>
            {
                entity.ToTable("yarnmanipulation");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
            });

            modelBuilder.Entity<YarnmanipulationTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainYarnmanipulationid, e.MainTextileid })
                    .HasName("main$yarnmanipulation_textile_pkey");

                entity.ToTable("yarnmanipulation_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainYarnmanipulationid }, "idx_main$yarnmanipulation_textile");

                entity.Property(e => e.MainYarnmanipulationid).HasColumnName("main$yarnmanipulationid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.HasSequence("excelimporter$template_nr_mxseq");

            modelBuilder.HasSequence("system$filedocument_fileid_mxseq");

            modelBuilder.HasSequence("system$queuedtask_sequence_mxseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
