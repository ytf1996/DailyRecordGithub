using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNetCore.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Application = table.Column<string>(maxLength: 50, nullable: true),
                    Logged = table.Column<DateTime>(nullable: true),
                    Level = table.Column<string>(maxLength: 255, nullable: true),
                    Message = table.Column<string>(maxLength: 4000, nullable: true),
                    Logger = table.Column<string>(maxLength: 4000, nullable: true),
                    CallSite = table.Column<string>(maxLength: 255, nullable: true),
                    Exception = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToolModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecordCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    LineManageId = table.Column<int>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    PassWord = table.Column<string>(maxLength: 512, nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(maxLength: 30, nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    WeChatCorpId = table.Column<string>(maxLength: 255, nullable: true),
                    WeChatUserId = table.Column<string>(maxLength: 50, nullable: true),
                    WeChatOpenidForMiniProgram = table.Column<string>(maxLength: 255, nullable: true),
                    WeChatUnionId = table.Column<string>(maxLength: 255, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    ChannelIds = table.Column<string>(nullable: true),
                    TerritoryProfilesId = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    HeadImage = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CurrentUserId = table.Column<int>(nullable: true),
                    EffectDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessToken_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessToken_Users_CurrentUserId",
                        column: x => x.CurrentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessToken_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    SuffixName = table.Column<string>(maxLength: 10, nullable: true),
                    IsPicture = table.Column<bool>(nullable: false),
                    Path = table.Column<string>(maxLength: 255, nullable: true),
                    ContentType = table.Column<string>(maxLength: 50, nullable: true),
                    Size = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachment_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BabyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    TimeOfBirth = table.Column<DateTime>(nullable: false),
                    BirthWeight = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyInfo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BabyInfo_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Channel_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Channel_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(maxLength: 1000, nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatRoom_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobClassificationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ClassificationName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobClassificationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobClassificationInfo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobClassificationInfo_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LatLngHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Lat = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatLngHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LatLngHistory_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LatLngHistory_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 4000, nullable: true),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    NoticeManId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    QYWechatUserName = table.Column<string>(maxLength: 50, nullable: true),
                    PreSentTime = table.Column<DateTime>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 255, nullable: true),
                    EntityFullName = table.Column<string>(maxLength: 255, nullable: true),
                    RecordId = table.Column<int>(nullable: false),
                    IsSendSuccess = table.Column<bool>(nullable: false),
                    SendCount = table.Column<int>(nullable: false),
                    SendFailReason = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notice_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notice_Users_NoticeManId",
                        column: x => x.NoticeManId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notice_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemParam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ParamType = table.Column<string>(maxLength: 50, nullable: true),
                    ParamValue = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemParam_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemParam_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    CycleType = table.Column<int>(nullable: false),
                    CycleTypeValue = table.Column<int>(nullable: false),
                    TimingType = table.Column<int>(nullable: false),
                    PlanRunDate = table.Column<int>(nullable: false),
                    PlanRunTime = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    LastRunTime = table.Column<DateTime>(nullable: true),
                    NextRunTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    SourseFromUrl = table.Column<string>(maxLength: 255, nullable: true),
                    ErrorMessage = table.Column<string>(maxLength: 255, nullable: true),
                    ReTryTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskModel_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskModel_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Territory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TheOrder = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    ParentTerrId = table.Column<int>(nullable: true),
                    RangeEnd = table.Column<int>(nullable: false),
                    NextRangeStart = table.Column<int>(nullable: false),
                    RangeIncrement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Territory_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Territory_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerritoryProfiles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TerritoryProfiles_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    WorkflowEntityName = table.Column<string>(maxLength: 255, nullable: true),
                    Remark = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkDiaryInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeOfBirth = table.Column<DateTime>(nullable: false),
                    WhatDay = table.Column<int>(nullable: false),
                    WhetherOnBusinessTrip = table.Column<bool>(nullable: false),
                    TravelSite = table.Column<string>(maxLength: 50, nullable: true),
                    JobClassificationInfoId = table.Column<int>(nullable: false),
                    JobContent = table.Column<string>(maxLength: 4000, nullable: true),
                    BegWorkTime = table.Column<DateTime>(nullable: false),
                    EndWorkTime = table.Column<DateTime>(nullable: false),
                    NormalWorkHour = table.Column<decimal>(nullable: false),
                    ExtraWorkHour = table.Column<decimal>(nullable: true),
                    SubtotalWorkHour = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDiaryInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkDiaryInfo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkDiaryInfo_JobClassificationInfo_JobClassificationInfoId",
                        column: x => x.JobClassificationInfoId,
                        principalTable: "JobClassificationInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkDiaryInfo_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    TaskModelId = table.Column<int>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false),
                    ErrorMsg = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskHistory_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskHistory_TaskModel_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "TaskModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskHistory_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PurviewType = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    TerritoryProfilesId = table.Column<int>(nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    CanSelect = table.Column<bool>(nullable: false),
                    CanInsert = table.Column<bool>(nullable: false),
                    CanUpdate = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false),
                    OtherTerritoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purview_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purview_TerritoryProfiles_TerritoryProfilesId",
                        column: x => x.TerritoryProfilesId,
                        principalTable: "TerritoryProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purview_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    WorkflowId = table.Column<int>(nullable: false),
                    LevelPath = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowStep_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowButton",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    WorkflowId = table.Column<int>(nullable: false),
                    LastWorkflowStepId = table.Column<int>(nullable: false),
                    NextWorkflowStepId = table.Column<int>(nullable: false),
                    OnlyViewForCreatedBy = table.Column<bool>(nullable: false),
                    OnlyViewForLineManager = table.Column<bool>(nullable: false),
                    ChannelIds = table.Column<string>(maxLength: 255, nullable: true),
                    UserIds = table.Column<string>(maxLength: 255, nullable: true),
                    CanViewCondition = table.Column<string>(maxLength: 255, nullable: true),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowButton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowButton_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowButton_WorkflowStep_LastWorkflowStepId",
                        column: x => x.LastWorkflowStepId,
                        principalTable: "WorkflowStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowButton_WorkflowStep_NextWorkflowStepId",
                        column: x => x.NextWorkflowStepId,
                        principalTable: "WorkflowStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowButton_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowButton_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowInstance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    WorkflowId = table.Column<int>(nullable: true),
                    WorkflowStepId = table.Column<int>(nullable: true),
                    DealUsersIds = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowInstance_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstance_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstance_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowInstance_WorkflowStep_WorkflowStepId",
                        column: x => x.WorkflowStepId,
                        principalTable: "WorkflowStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    WorkflowId = table.Column<int>(nullable: false),
                    WorkflowButtonId = table.Column<int>(nullable: false),
                    WorkflowActionType = table.Column<int>(nullable: false),
                    EditColumnName = table.Column<string>(maxLength: 50, nullable: true),
                    EditColumnValue = table.Column<string>(maxLength: 255, nullable: true),
                    NoticeChannelIds = table.Column<string>(maxLength: 255, nullable: true),
                    NoticeUserIds = table.Column<string>(maxLength: 255, nullable: true),
                    NoticeContent = table.Column<string>(maxLength: 255, nullable: true),
                    RunSqlText = table.Column<string>(maxLength: 255, nullable: true),
                    OrderNum = table.Column<int>(nullable: false),
                    NoticeLineManager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowAction_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowAction_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowAction_WorkflowButton_WorkflowButtonId",
                        column: x => x.WorkflowButtonId,
                        principalTable: "WorkflowButton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowAction_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowProgressBabyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    WorkflowButtonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowProgressBabyInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowProgressBabyInfo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowProgressBabyInfo_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowProgressBabyInfo_WorkflowButton_WorkflowButtonId",
                        column: x => x.WorkflowButtonId,
                        principalTable: "WorkflowButton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowProgressDemo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    WorkflowButtonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowProgressDemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowProgressDemo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowProgressDemo_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowProgressDemo_WorkflowButton_WorkflowButtonId",
                        column: x => x.WorkflowButtonId,
                        principalTable: "WorkflowButton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BabyInfoDaliy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    WorkflowInstanceId = table.Column<int>(nullable: true),
                    BusinessDate = table.Column<DateTime>(nullable: false),
                    BabyInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyInfoDaliy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BabyInfoDaliy_BabyInfo_BabyInfoId",
                        column: x => x.BabyInfoId,
                        principalTable: "BabyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BabyInfoDaliy_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BabyInfoDaliy_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BabyInfoDaliy_WorkflowInstance_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowDemo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryId = table.Column<int>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    WorkflowInstanceId = table.Column<int>(nullable: true),
                    OrderNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowDemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowDemo_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowDemo_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowDemo_WorkflowInstance_WorkflowInstanceId",
                        column: x => x.WorkflowInstanceId,
                        principalTable: "WorkflowInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_CreatedById",
                table: "AccessToken",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_CurrentUserId",
                table: "AccessToken",
                column: "CurrentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_UpdatedById",
                table: "AccessToken",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_CreatedById",
                table: "Attachment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_UpdatedById",
                table: "Attachment",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_CreatedById",
                table: "BabyInfo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfo_UpdatedById",
                table: "BabyInfo",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfoDaliy_BabyInfoId",
                table: "BabyInfoDaliy",
                column: "BabyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfoDaliy_CreatedById",
                table: "BabyInfoDaliy",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfoDaliy_UpdatedById",
                table: "BabyInfoDaliy",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BabyInfoDaliy_WorkflowInstanceId",
                table: "BabyInfoDaliy",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Channel_CreatedById",
                table: "Channel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Channel_UpdatedById",
                table: "Channel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_CreatedById",
                table: "ChatRoom",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_UpdatedById",
                table: "ChatRoom",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobClassificationInfo_CreatedById",
                table: "JobClassificationInfo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobClassificationInfo_UpdatedById",
                table: "JobClassificationInfo",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LatLngHistory_CreatedById",
                table: "LatLngHistory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LatLngHistory_UpdatedById",
                table: "LatLngHistory",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Note_CreatedById",
                table: "Note",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Note_UpdatedById",
                table: "Note",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notice_CreatedById",
                table: "Notice",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notice_NoticeManId",
                table: "Notice",
                column: "NoticeManId");

            migrationBuilder.CreateIndex(
                name: "IX_Notice_UpdatedById",
                table: "Notice",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Purview_CreatedById",
                table: "Purview",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Purview_TerritoryProfilesId",
                table: "Purview",
                column: "TerritoryProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purview_UpdatedById",
                table: "Purview",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParam_CreatedById",
                table: "SystemParam",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SystemParam_UpdatedById",
                table: "SystemParam",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistory_CreatedById",
                table: "TaskHistory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistory_TaskModelId",
                table: "TaskHistory",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistory_UpdatedById",
                table: "TaskHistory",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_CreatedById",
                table: "TaskModel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_UpdatedById",
                table: "TaskModel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Territory_CreatedById",
                table: "Territory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Territory_UpdatedById",
                table: "Territory",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryProfiles_CreatedById",
                table: "TerritoryProfiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TerritoryProfiles_UpdatedById",
                table: "TerritoryProfiles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDiaryInfo_CreatedById",
                table: "WorkDiaryInfo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDiaryInfo_JobClassificationInfoId",
                table: "WorkDiaryInfo",
                column: "JobClassificationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDiaryInfo_UpdatedById",
                table: "WorkDiaryInfo",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_CreatedById",
                table: "Workflow",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_UpdatedById",
                table: "Workflow",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_CreatedById",
                table: "WorkflowAction",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_UpdatedById",
                table: "WorkflowAction",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_WorkflowButtonId",
                table: "WorkflowAction",
                column: "WorkflowButtonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowAction_WorkflowId",
                table: "WorkflowAction",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowButton_CreatedById",
                table: "WorkflowButton",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowButton_LastWorkflowStepId",
                table: "WorkflowButton",
                column: "LastWorkflowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowButton_NextWorkflowStepId",
                table: "WorkflowButton",
                column: "NextWorkflowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowButton_UpdatedById",
                table: "WorkflowButton",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowButton_WorkflowId",
                table: "WorkflowButton",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowDemo_CreatedById",
                table: "WorkflowDemo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowDemo_UpdatedById",
                table: "WorkflowDemo",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowDemo_WorkflowInstanceId",
                table: "WorkflowDemo",
                column: "WorkflowInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_CreatedById",
                table: "WorkflowInstance",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_UpdatedById",
                table: "WorkflowInstance",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_WorkflowId",
                table: "WorkflowInstance",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowInstance_WorkflowStepId",
                table: "WorkflowInstance",
                column: "WorkflowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProgressBabyInfo_CreatedById",
                table: "WorkflowProgressBabyInfo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProgressBabyInfo_UpdatedById",
                table: "WorkflowProgressBabyInfo",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProgressBabyInfo_WorkflowButtonId",
                table: "WorkflowProgressBabyInfo",
                column: "WorkflowButtonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProgressDemo_CreatedById",
                table: "WorkflowProgressDemo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProgressDemo_UpdatedById",
                table: "WorkflowProgressDemo",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProgressDemo_WorkflowButtonId",
                table: "WorkflowProgressDemo",
                column: "WorkflowButtonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_CreatedById",
                table: "WorkflowStep",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_UpdatedById",
                table: "WorkflowStep",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStep_WorkflowId",
                table: "WorkflowStep",
                column: "WorkflowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "BabyInfoDaliy");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "LatLngHistory");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Notice");

            migrationBuilder.DropTable(
                name: "Purview");

            migrationBuilder.DropTable(
                name: "SystemParam");

            migrationBuilder.DropTable(
                name: "TaskHistory");

            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropTable(
                name: "ToolModel");

            migrationBuilder.DropTable(
                name: "WorkDiaryInfo");

            migrationBuilder.DropTable(
                name: "WorkflowAction");

            migrationBuilder.DropTable(
                name: "WorkflowDemo");

            migrationBuilder.DropTable(
                name: "WorkflowProgressBabyInfo");

            migrationBuilder.DropTable(
                name: "WorkflowProgressDemo");

            migrationBuilder.DropTable(
                name: "BabyInfo");

            migrationBuilder.DropTable(
                name: "TerritoryProfiles");

            migrationBuilder.DropTable(
                name: "TaskModel");

            migrationBuilder.DropTable(
                name: "JobClassificationInfo");

            migrationBuilder.DropTable(
                name: "WorkflowInstance");

            migrationBuilder.DropTable(
                name: "WorkflowButton");

            migrationBuilder.DropTable(
                name: "WorkflowStep");

            migrationBuilder.DropTable(
                name: "Workflow");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
