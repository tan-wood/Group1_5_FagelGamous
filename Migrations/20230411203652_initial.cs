using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group1_5_FagelGamous.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "excelimporter$template_nr_mxseq");

            migrationBuilder.CreateSequence(
                name: "system$filedocument_fileid_mxseq");

            migrationBuilder.CreateSequence(
                name: "system$queuedtask_sequence_mxseq");

            migrationBuilder.CreateTable(
                name: "analysis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    analysistype = table.Column<int>(type: "integer", nullable: true),
                    doneby = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    analysisid = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bodyanalysischart",
                columns: table => new
                {
                    squarenorthsouth = table.Column<string>(type: "character varying", nullable: true),
                    northsouth = table.Column<string>(type: "character varying", nullable: true),
                    squareeastwest = table.Column<string>(type: "character varying", nullable: true),
                    eastwest = table.Column<string>(type: "character varying", nullable: true),
                    area = table.Column<string>(type: "character varying", nullable: true),
                    dateofexamination = table.Column<DateOnly>(type: "date", nullable: true),
                    preservationindex = table.Column<double>(type: "double precision", nullable: true),
                    haircolor = table.Column<string>(type: "character varying", nullable: true),
                    observations = table.Column<string>(type: "character varying", nullable: true),
                    robust = table.Column<string>(type: "character varying", nullable: true),
                    supraorbitalridges = table.Column<string>(type: "character varying", nullable: true),
                    orbitedge = table.Column<string>(type: "character varying", nullable: true),
                    parietalbossing = table.Column<string>(type: "character varying", nullable: true),
                    gonion = table.Column<string>(type: "character varying", nullable: true),
                    nuchalcrest = table.Column<string>(type: "character varying", nullable: true),
                    zygomaticcrest = table.Column<string>(type: "character varying", nullable: true),
                    sphenooccipitalsynchrondrosis = table.Column<string>(type: "character varying", nullable: true),
                    lamboidsuture = table.Column<string>(type: "character varying", nullable: true),
                    squamossuture = table.Column<string>(type: "character varying", nullable: true),
                    toothattrition = table.Column<string>(type: "character varying", nullable: true),
                    tootheruption = table.Column<string>(type: "character varying", nullable: true),
                    tootheruptionageestimate = table.Column<string>(type: "character varying", nullable: true),
                    ventralarc = table.Column<string>(type: "character varying", nullable: true),
                    subpubicangle = table.Column<string>(type: "character varying", nullable: true),
                    sciaticnotch = table.Column<string>(type: "character varying", nullable: true),
                    pubicbone = table.Column<string>(type: "character varying", nullable: true),
                    preauricularsulcus = table.Column<string>(type: "character varying", nullable: true),
                    medial_ip_ramus = table.Column<string>(type: "character varying", nullable: true),
                    dorsalpitting = table.Column<string>(type: "character varying", nullable: true),
                    femur = table.Column<string>(type: "character varying", nullable: true),
                    humerus = table.Column<string>(type: "character varying", nullable: true),
                    femurheaddiameter = table.Column<double>(type: "double precision", nullable: true),
                    humerusheaddiameter = table.Column<double>(type: "double precision", nullable: true),
                    femidurlength = table.Column<double>(type: "double precision", nullable: true),
                    humeruslength = table.Column<double>(type: "double precision", nullable: true),
                    estimatestature = table.Column<double>(type: "double precision", nullable: true),
                    osteophytosis = table.Column<string>(type: "character varying", nullable: true),
                    caries_periodontal_disease = table.Column<string>(type: "character varying", nullable: true),
                    notes = table.Column<string>(type: "character varying", nullable: true),
                    burialnumber = table.Column<string>(type: "character varying", nullable: true),
                    tibia = table.Column<double>(type: "double precision", nullable: true),
                    burialid = table.Column<string>(type: "character varying", nullable: true),
                    id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "burialmain",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    squarenorthsouth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    headdirection = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sex = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    northsouth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    depth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    eastwest = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    adultsubadult = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    facebundles = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    southtohead = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    preservation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    fieldbookpage = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    squareeastwest = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    goods = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    text = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    wrapping = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    haircolor = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    westtohead = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    samplescollected = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    area = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    burialid = table.Column<string>(type: "text", nullable: true),
                    length = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    burialnumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    dataexpertinitials = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    westtofeet = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ageatdeath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    southtofeet = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    excavationrecorder = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    photos = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    hair = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    burialmaterials = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    dateofexcavation = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fieldbookexcavationyear = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    clusternumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    shaftnumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burialmain", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    colorid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "decoration",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    decorationid = table.Column<int>(type: "integer", nullable: true),
                    value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_decoration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dimension",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    dimensiontype = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    value = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    dimensionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dimension", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "photodata",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    filename = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    photodataid = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photodata", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "photoform",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    area = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    squarenorthsouth = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    tableassociation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    filename = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    photographer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    burialnumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    squareeastwest = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    eastwest = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    northsouth = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    photodate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photoform", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structure",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    structureid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_structure", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teammember",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    bio = table.Column<string>(type: "character varying", nullable: true),
                    membername = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teammember", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "textile",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    locale = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    textileid = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    burialnumber = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    estimatedperiod = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    sampledate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    photographeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    direction = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "textilefunction",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    textilefunctionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textilefunction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "yarnmanipulation",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    thickness = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    angle = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    manipulation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    material = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    count = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    component = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ply = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    yarnmanipulationid = table.Column<int>(type: "integer", nullable: true),
                    direction = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yarnmanipulation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "analysis_textile",
                columns: table => new
                {
                    mainanalysisid = table.Column<long>(name: "main$analysisid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    AnalysisId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$analysis_textile_pkey", x => new { x.mainanalysisid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_analysis_textile_analysis_AnalysisId",
                        column: x => x.AnalysisId,
                        principalTable: "analysis",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_analysis_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "burialmain_textile",
                columns: table => new
                {
                    mainburialmainid = table.Column<long>(name: "main$burialmainid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    BurialMainId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$burialmain_textile_pkey", x => new { x.mainburialmainid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_burialmain_textile_burialmain_BurialMainId",
                        column: x => x.BurialMainId,
                        principalTable: "burialmain",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_burialmain_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "color_textile",
                columns: table => new
                {
                    maincolorid = table.Column<long>(name: "main$colorid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    ColorsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$color_textile_pkey", x => new { x.maincolorid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_color_textile_color_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "color",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_color_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "decoration_textile",
                columns: table => new
                {
                    maindecorationid = table.Column<long>(name: "main$decorationid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    DecorationsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$decoration_textile_pkey", x => new { x.maindecorationid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_decoration_textile_decoration_DecorationsId",
                        column: x => x.DecorationsId,
                        principalTable: "decoration",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_decoration_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "dimension_textile",
                columns: table => new
                {
                    maindimensionid = table.Column<long>(name: "main$dimensionid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    DimensionsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$dimension_textile_pkey", x => new { x.maindimensionid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_dimension_textile_dimension_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "dimension",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_dimension_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "photodata_textile",
                columns: table => new
                {
                    mainphotodataid = table.Column<long>(name: "main$photodataid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    PhotoDataId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$photodata_textile_pkey", x => new { x.mainphotodataid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_photodata_textile_photodata_PhotoDataId",
                        column: x => x.PhotoDataId,
                        principalTable: "photodata",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_photodata_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "structure_textile",
                columns: table => new
                {
                    mainstructureid = table.Column<long>(name: "main$structureid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    StructuresId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$structure_textile_pkey", x => new { x.mainstructureid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_structure_textile_structure_StructuresId",
                        column: x => x.StructuresId,
                        principalTable: "structure",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_structure_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "textilefunction_textile",
                columns: table => new
                {
                    maintextilefunctionid = table.Column<long>(name: "main$textilefunctionid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    TextileFunctionsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$textilefunction_textile_pkey", x => new { x.maintextilefunctionid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_textilefunction_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_textilefunction_textile_textilefunction_TextileFunctionsId",
                        column: x => x.TextileFunctionsId,
                        principalTable: "textilefunction",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "yarnmanipulation_textile",
                columns: table => new
                {
                    mainyarnmanipulationid = table.Column<long>(name: "main$yarnmanipulationid", type: "bigint", nullable: false),
                    maintextileid = table.Column<long>(name: "main$textileid", type: "bigint", nullable: false),
                    TextilesId = table.Column<long>(type: "bigint", nullable: true),
                    YarnmanipulationsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("main$yarnmanipulation_textile_pkey", x => new { x.mainyarnmanipulationid, x.maintextileid });
                    table.ForeignKey(
                        name: "FK_yarnmanipulation_textile_textile_TextilesId",
                        column: x => x.TextilesId,
                        principalTable: "textile",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_yarnmanipulation_textile_yarnmanipulation_Yarnmanipulations~",
                        column: x => x.YarnmanipulationsId,
                        principalTable: "yarnmanipulation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_main$analysis_textile_main$textile_main$analysis",
                table: "analysis_textile",
                columns: new[] { "main$textileid", "main$analysisid" });

            migrationBuilder.CreateIndex(
                name: "IX_analysis_textile_AnalysisId",
                table: "analysis_textile",
                column: "AnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_analysis_textile_TextilesId",
                table: "analysis_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$burialmain_textile_main$textile_main$burialmain",
                table: "burialmain_textile",
                columns: new[] { "main$textileid", "main$burialmainid" });

            migrationBuilder.CreateIndex(
                name: "IX_burialmain_textile_BurialMainId",
                table: "burialmain_textile",
                column: "BurialMainId");

            migrationBuilder.CreateIndex(
                name: "IX_burialmain_textile_TextilesId",
                table: "burialmain_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$color_textile_main$textile_main$color",
                table: "color_textile",
                columns: new[] { "main$textileid", "main$colorid" });

            migrationBuilder.CreateIndex(
                name: "IX_color_textile_ColorsId",
                table: "color_textile",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_color_textile_TextilesId",
                table: "color_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$decoration_textile_main$textile_main$decoration",
                table: "decoration_textile",
                columns: new[] { "main$textileid", "main$decorationid" });

            migrationBuilder.CreateIndex(
                name: "IX_decoration_textile_DecorationsId",
                table: "decoration_textile",
                column: "DecorationsId");

            migrationBuilder.CreateIndex(
                name: "IX_decoration_textile_TextilesId",
                table: "decoration_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$dimension_textile_main$textile_main$dimension",
                table: "dimension_textile",
                columns: new[] { "main$textileid", "main$dimensionid" });

            migrationBuilder.CreateIndex(
                name: "IX_dimension_textile_DimensionsId",
                table: "dimension_textile",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_dimension_textile_TextilesId",
                table: "dimension_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$photodata_textile_main$textile_main$photodata",
                table: "photodata_textile",
                columns: new[] { "main$textileid", "main$photodataid" });

            migrationBuilder.CreateIndex(
                name: "IX_photodata_textile_PhotoDataId",
                table: "photodata_textile",
                column: "PhotoDataId");

            migrationBuilder.CreateIndex(
                name: "IX_photodata_textile_TextilesId",
                table: "photodata_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$structure_textile_main$textile_main$structure",
                table: "structure_textile",
                columns: new[] { "main$textileid", "main$structureid" });

            migrationBuilder.CreateIndex(
                name: "IX_structure_textile_StructuresId",
                table: "structure_textile",
                column: "StructuresId");

            migrationBuilder.CreateIndex(
                name: "IX_structure_textile_TextilesId",
                table: "structure_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$textilefunction_textile",
                table: "textilefunction_textile",
                columns: new[] { "main$textileid", "main$textilefunctionid" });

            migrationBuilder.CreateIndex(
                name: "IX_textilefunction_textile_TextileFunctionsId",
                table: "textilefunction_textile",
                column: "TextileFunctionsId");

            migrationBuilder.CreateIndex(
                name: "IX_textilefunction_textile_TextilesId",
                table: "textilefunction_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "idx_main$yarnmanipulation_textile",
                table: "yarnmanipulation_textile",
                columns: new[] { "main$textileid", "main$yarnmanipulationid" });

            migrationBuilder.CreateIndex(
                name: "IX_yarnmanipulation_textile_TextilesId",
                table: "yarnmanipulation_textile",
                column: "TextilesId");

            migrationBuilder.CreateIndex(
                name: "IX_yarnmanipulation_textile_YarnmanipulationsId",
                table: "yarnmanipulation_textile",
                column: "YarnmanipulationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analysis_textile");

            migrationBuilder.DropTable(
                name: "bodyanalysischart");

            migrationBuilder.DropTable(
                name: "burialmain_textile");

            migrationBuilder.DropTable(
                name: "color_textile");

            migrationBuilder.DropTable(
                name: "decoration_textile");

            migrationBuilder.DropTable(
                name: "dimension_textile");

            migrationBuilder.DropTable(
                name: "photodata_textile");

            migrationBuilder.DropTable(
                name: "photoform");

            migrationBuilder.DropTable(
                name: "structure_textile");

            migrationBuilder.DropTable(
                name: "teammember");

            migrationBuilder.DropTable(
                name: "textilefunction_textile");

            migrationBuilder.DropTable(
                name: "yarnmanipulation_textile");

            migrationBuilder.DropTable(
                name: "analysis");

            migrationBuilder.DropTable(
                name: "burialmain");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "decoration");

            migrationBuilder.DropTable(
                name: "dimension");

            migrationBuilder.DropTable(
                name: "photodata");

            migrationBuilder.DropTable(
                name: "structure");

            migrationBuilder.DropTable(
                name: "textilefunction");

            migrationBuilder.DropTable(
                name: "textile");

            migrationBuilder.DropTable(
                name: "yarnmanipulation");

            migrationBuilder.DropSequence(
                name: "excelimporter$template_nr_mxseq");

            migrationBuilder.DropSequence(
                name: "system$filedocument_fileid_mxseq");

            migrationBuilder.DropSequence(
                name: "system$queuedtask_sequence_mxseq");
        }
    }
}
