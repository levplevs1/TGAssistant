using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramBot.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TelegramBot_Migration_DataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    id_education = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text_of_request = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.id_education);
                });

            migrationBuilder.CreateTable(
                name: "Healthcare",
                columns: table => new
                {
                    id_healthcare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text_of_request = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Healthcare", x => x.id_healthcare);
                });

            migrationBuilder.CreateTable(
                name: "Housing_And_Communal_Services",
                columns: table => new
                {
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text_of_request = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housing_And_Communal_Services", x => x.id_housing_and_communal_services);
                });

            migrationBuilder.CreateTable(
                name: "Meter_Type",
                columns: table => new
                {
                    id_meter_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meter_type_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter_Type", x => x.id_meter_type);
                });

            migrationBuilder.CreateTable(
                name: "Payments_Method",
                columns: table => new
                {
                    id_payments_method = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payments_method_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments_Method", x => x.id_payments_method);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    id_transport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text_of_request = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.id_transport);
                });

            migrationBuilder.CreateTable(
                name: "Unit_Of_Tariffs",
                columns: table => new
                {
                    id_unit_of_tariffs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_of_tariffs_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit_Of_Tariffs", x => x.id_unit_of_tariffs);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_users = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_telegram = table.Column<double>(type: "float", nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_users);
                });

            migrationBuilder.CreateTable(
                name: "Quick_Answers_Education",
                columns: table => new
                {
                    id_quick_answer_education = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quick_answer_education_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_education = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quick_Answers_Education", x => x.id_quick_answer_education);
                    table.ForeignKey(
                        name: "FK_Quick_Answers_Education_Education_id_education",
                        column: x => x.id_education,
                        principalTable: "Education",
                        principalColumn: "id_education");
                });

            migrationBuilder.CreateTable(
                name: "Quick_Answers_Healthcare",
                columns: table => new
                {
                    id_quick_answer_healthcare = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quick_answer_healthcare_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_healthcare = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quick_Answers_Healthcare", x => x.id_quick_answer_healthcare);
                    table.ForeignKey(
                        name: "FK_Quick_Answers_Healthcare_Healthcare_id_healthcare",
                        column: x => x.id_healthcare,
                        principalTable: "Healthcare",
                        principalColumn: "id_healthcare");
                });

            migrationBuilder.CreateTable(
                name: "Articles_Housing_Code",
                columns: table => new
                {
                    id_articles_housing_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articles_housing_code_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    articles_housing_code_content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles_Housing_Code", x => x.id_articles_housing_code);
                    table.ForeignKey(
                        name: "FK_Articles_Housing_Code_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                });

            migrationBuilder.CreateTable(
                name: "Quick_Answers_hcs",
                columns: table => new
                {
                    id_quick_answers_hcs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quick_answers_hcs_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    quick_answers_hcs_content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quick_Answers_hcs", x => x.id_quick_answers_hcs);
                    table.ForeignKey(
                        name: "FK_Quick_Answers_hcs_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                });

            migrationBuilder.CreateTable(
                name: "Service_Type",
                columns: table => new
                {
                    id_service_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_type_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Type", x => x.id_service_type);
                    table.ForeignKey(
                        name: "FK_Service_Type_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                });

            migrationBuilder.CreateTable(
                name: "Quick_Answers_Transport",
                columns: table => new
                {
                    id_quick_answer_transport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quick_answer_transport_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_transport = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quick_Answers_Transport", x => x.id_quick_answer_transport);
                    table.ForeignKey(
                        name: "FK_Quick_Answers_Transport_Transport_id_transport",
                        column: x => x.id_transport,
                        principalTable: "Transport",
                        principalColumn: "id_transport");
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Requests",
                columns: table => new
                {
                    id_type_of_requests = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true),
                    id_healthcare = table.Column<int>(type: "int", nullable: true),
                    id_transport = table.Column<int>(type: "int", nullable: true),
                    id_education = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Of_Requests", x => x.id_type_of_requests);
                    table.ForeignKey(
                        name: "FK_Type_Of_Requests_Education_id_education",
                        column: x => x.id_education,
                        principalTable: "Education",
                        principalColumn: "id_education");
                    table.ForeignKey(
                        name: "FK_Type_Of_Requests_Healthcare_id_healthcare",
                        column: x => x.id_healthcare,
                        principalTable: "Healthcare",
                        principalColumn: "id_healthcare");
                    table.ForeignKey(
                        name: "FK_Type_Of_Requests_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                    table.ForeignKey(
                        name: "FK_Type_Of_Requests_Transport_id_transport",
                        column: x => x.id_transport,
                        principalTable: "Transport",
                        principalColumn: "id_transport");
                });

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    id_meters = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instalition_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_reading_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_meter_type = table.Column<int>(type: "int", nullable: true),
                    id_users = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.id_meters);
                    table.ForeignKey(
                        name: "FK_Meters_Meter_Type_id_meter_type",
                        column: x => x.id_meter_type,
                        principalTable: "Meter_Type",
                        principalColumn: "id_meter_type");
                    table.ForeignKey(
                        name: "FK_Meters_Users_id_users",
                        column: x => x.id_users,
                        principalTable: "Users",
                        principalColumn: "id_users");
                });

            migrationBuilder.CreateTable(
                name: "User_Memory",
                columns: table => new
                {
                    id_user_memory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content_memory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_users = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Memory", x => x.id_user_memory);
                    table.ForeignKey(
                        name: "FK_User_Memory_Users_id_users",
                        column: x => x.id_users,
                        principalTable: "Users",
                        principalColumn: "id_users");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id_payments = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payments_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    id_users = table.Column<int>(type: "int", nullable: true),
                    id_payments_method = table.Column<int>(type: "int", nullable: true),
                    id_service_type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id_payments);
                    table.ForeignKey(
                        name: "FK_Payments_Payments_Method_id_payments_method",
                        column: x => x.id_payments_method,
                        principalTable: "Payments_Method",
                        principalColumn: "id_payments_method");
                    table.ForeignKey(
                        name: "FK_Payments_Service_Type_id_service_type",
                        column: x => x.id_service_type,
                        principalTable: "Service_Type",
                        principalColumn: "id_service_type");
                    table.ForeignKey(
                        name: "FK_Payments_Users_id_users",
                        column: x => x.id_users,
                        principalTable: "Users",
                        principalColumn: "id_users");
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    id_tariffs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    effective_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tariff_value = table.Column<double>(type: "float", nullable: true),
                    id_unit_of_tariffs = table.Column<int>(type: "int", nullable: true),
                    id_service_type = table.Column<int>(type: "int", nullable: true),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.id_tariffs);
                    table.ForeignKey(
                        name: "FK_Tariffs_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                    table.ForeignKey(
                        name: "FK_Tariffs_Service_Type_id_service_type",
                        column: x => x.id_service_type,
                        principalTable: "Service_Type",
                        principalColumn: "id_service_type");
                    table.ForeignKey(
                        name: "FK_Tariffs_Unit_Of_Tariffs_id_unit_of_tariffs",
                        column: x => x.id_unit_of_tariffs,
                        principalTable: "Unit_Of_Tariffs",
                        principalColumn: "id_unit_of_tariffs");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    id_requests = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    response = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_type_of_requests = table.Column<int>(type: "int", nullable: true),
                    id_users = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.id_requests);
                    table.ForeignKey(
                        name: "FK_Requests_Type_Of_Requests_id_type_of_requests",
                        column: x => x.id_type_of_requests,
                        principalTable: "Type_Of_Requests",
                        principalColumn: "id_type_of_requests");
                    table.ForeignKey(
                        name: "FK_Requests_Users_id_users",
                        column: x => x.id_users,
                        principalTable: "Users",
                        principalColumn: "id_users");
                });

            migrationBuilder.CreateTable(
                name: "Meter_Readings",
                columns: table => new
                {
                    id_meter_readings = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    readings_value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    previos_readings_value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    readings_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_meters = table.Column<int>(type: "int", nullable: true),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter_Readings", x => x.id_meter_readings);
                    table.ForeignKey(
                        name: "FK_Meter_Readings_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                    table.ForeignKey(
                        name: "FK_Meter_Readings_Meters_id_meters",
                        column: x => x.id_meters,
                        principalTable: "Meters",
                        principalColumn: "id_meters");
                });

            migrationBuilder.CreateTable(
                name: "Reading_History",
                columns: table => new
                {
                    id_reading_history = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reading_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reading_value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    id_meters = table.Column<int>(type: "int", nullable: true),
                    id_housing_and_communal_services = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading_History", x => x.id_reading_history);
                    table.ForeignKey(
                        name: "FK_Reading_History_Housing_And_Communal_Services_id_housing_and_communal_services",
                        column: x => x.id_housing_and_communal_services,
                        principalTable: "Housing_And_Communal_Services",
                        principalColumn: "id_housing_and_communal_services");
                    table.ForeignKey(
                        name: "FK_Reading_History_Meters_id_meters",
                        column: x => x.id_meters,
                        principalTable: "Meters",
                        principalColumn: "id_meters");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Housing_Code_id_articles_housing_code",
                table: "Articles_Housing_Code",
                column: "id_articles_housing_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Housing_Code_id_housing_and_communal_services",
                table: "Articles_Housing_Code",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Education_id_education",
                table: "Education",
                column: "id_education",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Healthcare_id_healthcare",
                table: "Healthcare",
                column: "id_healthcare",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Housing_And_Communal_Services_id_housing_and_communal_services",
                table: "Housing_And_Communal_Services",
                column: "id_housing_and_communal_services",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meter_Readings_id_housing_and_communal_services",
                table: "Meter_Readings",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_Readings_id_meter_readings",
                table: "Meter_Readings",
                column: "id_meter_readings",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meter_Readings_id_meters",
                table: "Meter_Readings",
                column: "id_meters");

            migrationBuilder.CreateIndex(
                name: "IX_Meter_Type_id_meter_type",
                table: "Meter_Type",
                column: "id_meter_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meters_id_meter_type",
                table: "Meters",
                column: "id_meter_type");

            migrationBuilder.CreateIndex(
                name: "IX_Meters_id_meters",
                table: "Meters",
                column: "id_meters",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meters_id_users",
                table: "Meters",
                column: "id_users");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_payments",
                table: "Payments",
                column: "id_payments",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_payments_method",
                table: "Payments",
                column: "id_payments_method");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_service_type",
                table: "Payments",
                column: "id_service_type");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_id_users",
                table: "Payments",
                column: "id_users");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Method_id_payments_method",
                table: "Payments_Method",
                column: "id_payments_method",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_Education_id_education",
                table: "Quick_Answers_Education",
                column: "id_education");

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_Education_id_quick_answer_education",
                table: "Quick_Answers_Education",
                column: "id_quick_answer_education",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_hcs_id_housing_and_communal_services",
                table: "Quick_Answers_hcs",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_hcs_id_quick_answers_hcs",
                table: "Quick_Answers_hcs",
                column: "id_quick_answers_hcs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_Healthcare_id_healthcare",
                table: "Quick_Answers_Healthcare",
                column: "id_healthcare");

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_Healthcare_id_quick_answer_healthcare",
                table: "Quick_Answers_Healthcare",
                column: "id_quick_answer_healthcare",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_Transport_id_quick_answer_transport",
                table: "Quick_Answers_Transport",
                column: "id_quick_answer_transport",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quick_Answers_Transport_id_transport",
                table: "Quick_Answers_Transport",
                column: "id_transport");

            migrationBuilder.CreateIndex(
                name: "IX_Reading_History_id_housing_and_communal_services",
                table: "Reading_History",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Reading_History_id_meters",
                table: "Reading_History",
                column: "id_meters");

            migrationBuilder.CreateIndex(
                name: "IX_Reading_History_id_reading_history",
                table: "Reading_History",
                column: "id_reading_history",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_id_requests",
                table: "Requests",
                column: "id_requests",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_id_type_of_requests",
                table: "Requests",
                column: "id_type_of_requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_id_users",
                table: "Requests",
                column: "id_users");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Type_id_housing_and_communal_services",
                table: "Service_Type",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Type_id_service_type",
                table: "Service_Type",
                column: "id_service_type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_id_housing_and_communal_services",
                table: "Tariffs",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_id_service_type",
                table: "Tariffs",
                column: "id_service_type");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_id_tariffs",
                table: "Tariffs",
                column: "id_tariffs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_id_unit_of_tariffs",
                table: "Tariffs",
                column: "id_unit_of_tariffs");

            migrationBuilder.CreateIndex(
                name: "IX_Transport_id_transport",
                table: "Transport",
                column: "id_transport",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Requests_id_education",
                table: "Type_Of_Requests",
                column: "id_education");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Requests_id_healthcare",
                table: "Type_Of_Requests",
                column: "id_healthcare");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Requests_id_housing_and_communal_services",
                table: "Type_Of_Requests",
                column: "id_housing_and_communal_services");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Requests_id_transport",
                table: "Type_Of_Requests",
                column: "id_transport");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Of_Requests_id_type_of_requests",
                table: "Type_Of_Requests",
                column: "id_type_of_requests",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unit_Of_Tariffs_id_unit_of_tariffs",
                table: "Unit_Of_Tariffs",
                column: "id_unit_of_tariffs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Memory_id_user_memory",
                table: "User_Memory",
                column: "id_user_memory",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Memory_id_users",
                table: "User_Memory",
                column: "id_users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_users",
                table: "Users",
                column: "id_users",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles_Housing_Code");

            migrationBuilder.DropTable(
                name: "Meter_Readings");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Quick_Answers_Education");

            migrationBuilder.DropTable(
                name: "Quick_Answers_hcs");

            migrationBuilder.DropTable(
                name: "Quick_Answers_Healthcare");

            migrationBuilder.DropTable(
                name: "Quick_Answers_Transport");

            migrationBuilder.DropTable(
                name: "Reading_History");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "User_Memory");

            migrationBuilder.DropTable(
                name: "Payments_Method");

            migrationBuilder.DropTable(
                name: "Meters");

            migrationBuilder.DropTable(
                name: "Type_Of_Requests");

            migrationBuilder.DropTable(
                name: "Service_Type");

            migrationBuilder.DropTable(
                name: "Unit_Of_Tariffs");

            migrationBuilder.DropTable(
                name: "Meter_Type");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Healthcare");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Housing_And_Communal_Services");
        }
    }
}
