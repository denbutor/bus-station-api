using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarType = table.Column<string>(type: "TEXT", nullable: false),
                    CarNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengersCount = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WeekDay = table.Column<string>(type: "TEXT", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketCost = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DriverPib = table.Column<string>(type: "TEXT", nullable: false),
                    DriverPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false),
                    CarId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketCost = table.Column<float>(type: "REAL", nullable: false),
                    RouteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Start = table.Column<string>(type: "TEXT", nullable: false),
                    Finish = table.Column<string>(type: "TEXT", nullable: false),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FlightId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PassengersName = table.Column<string>(type: "TEXT", nullable: false),
                    OnlineTicket = table.Column<string>(type: "TEXT", nullable: false),
                    SaleStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlightId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CarId",
                table: "Drivers",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ScheduleId",
                table: "Flights",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TicketId",
                table: "Flights",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_FlightId",
                table: "Routes",
                column: "FlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Ticket_TicketId",
                table: "Flights",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Schedules_ScheduleId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Ticket_TicketId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
