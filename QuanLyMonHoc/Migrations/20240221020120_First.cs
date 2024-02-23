using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyMonHoc.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lop",
                columns: table => new
                {
                    malop = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    tenlop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lop", x => x.malop);
                });

            migrationBuilder.CreateTable(
                name: "monhoc",
                columns: table => new
                {
                    msmh = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    tenmh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sotiet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monhoc", x => x.msmh);
                });

            migrationBuilder.CreateTable(
                name: "lylich",
                columns: table => new
                {
                    mshv = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    tenhv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    phai = table.Column<bool>(type: "bit", nullable: true),
                    malop = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lylich", x => x.mshv);
                    table.ForeignKey(
                        name: "FK_lylich_lop",
                        column: x => x.malop,
                        principalTable: "lop",
                        principalColumn: "malop");
                });

            migrationBuilder.CreateTable(
                name: "diemthi",
                columns: table => new
                {
                    mshv = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    msmh = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    diem = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diemthi", x => new { x.mshv, x.msmh });
                    table.ForeignKey(
                        name: "FK_diemthi_lylich",
                        column: x => x.mshv,
                        principalTable: "lylich",
                        principalColumn: "mshv");
                    table.ForeignKey(
                        name: "FK_diemthi_monhoc",
                        column: x => x.msmh,
                        principalTable: "monhoc",
                        principalColumn: "msmh");
                });

            migrationBuilder.CreateIndex(
                name: "IX_diemthi_msmh",
                table: "diemthi",
                column: "msmh");

            migrationBuilder.CreateIndex(
                name: "IX_lylich_malop",
                table: "lylich",
                column: "malop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diemthi");

            migrationBuilder.DropTable(
                name: "lylich");

            migrationBuilder.DropTable(
                name: "monhoc");

            migrationBuilder.DropTable(
                name: "lop");
        }
    }
}
