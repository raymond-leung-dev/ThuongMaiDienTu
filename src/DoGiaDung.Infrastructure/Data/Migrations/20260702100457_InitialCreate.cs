using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoGiaDung.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "CATALOG",
                columns: table => new
                {
                    catalog_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catalog_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATALOG", x => x.catalog_id);
                });

            migrationBuilder.CreateTable(
                name: "SLIDE",
                columns: table => new
                {
                    slide_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    image = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    slide_order = table.Column<int>(type: "int", nullable: true),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLIDE", x => x.slide_id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_DICTIONARY",
                columns: table => new
                {
                    dic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lng_tp = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    col_cd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    col_cd_tp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "0"),
                    sort_seq = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    col_cd_tp_nm = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    reg_dt = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    cls_dt = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    work_mn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    work_dt = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    work_ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cnfm_seq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cnfm_user = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cnfm_dt = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    cnfm_ip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vsd_tp = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_DICTIONARY", x => x.dic_id);
                });

            migrationBuilder.CreateTable(
                name: "TAG",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tag_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    user_address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    resetPasswordCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "NEW",
                columns: table => new
                {
                    new_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tittle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    new_image = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    new_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    new_created_by = table.Column<int>(type: "int", nullable: true),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEW", x => x.new_id);
                    table.ForeignKey(
                        name: "FK_NEW_ADMIN_new_created_by",
                        column: x => x.new_created_by,
                        principalTable: "ADMIN",
                        principalColumn: "admin_id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    image_link = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    product_status = table.Column<int>(type: "int", nullable: true),
                    vat_rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0.21m),
                    catalog_id = table.Column<int>(type: "int", nullable: true),
                    tag_id = table.Column<int>(type: "int", nullable: true),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATALOG_catalog_id",
                        column: x => x.catalog_id,
                        principalTable: "CATALOG",
                        principalColumn: "catalog_id");
                    table.ForeignKey(
                        name: "FK_PRODUCT_TAG_tag_id",
                        column: x => x.tag_id,
                        principalTable: "TAG",
                        principalColumn: "tag_id");
                });

            migrationBuilder.CreateTable(
                name: "FEEDBACK",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    feedback_conten = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEEDBACK", x => x.feedback_id);
                    table.ForeignKey(
                        name: "FK_FEEDBACK_USER_user_id",
                        column: x => x.user_id,
                        principalTable: "USER",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    transaction_status = table.Column<int>(type: "int", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    user_address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    user_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    transaction_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment = table.Column<int>(type: "int", nullable: false),
                    payment_info = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    security = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    updated_dt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_USER_user_id",
                        column: x => x.user_id,
                        principalTable: "USER",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    amout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    order_status = table.Column<int>(type: "int", nullable: false),
                    del_yn = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, defaultValue: "N")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_ORDER_PRODUCT_product_id",
                        column: x => x.product_id,
                        principalTable: "PRODUCT",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_TRANSACTION_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "TRANSACTION",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_user_id",
                table: "FEEDBACK",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_NEW_new_created_by",
                table: "NEW",
                column: "new_created_by");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_product_id",
                table: "ORDER",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_transaction_id",
                table: "ORDER",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_catalog_id",
                table: "PRODUCT",
                column: "catalog_id");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_tag_id",
                table: "PRODUCT",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_dic_lng_col",
                table: "SYS_DICTIONARY",
                columns: new[] { "lng_tp", "col_cd", "col_cd_tp" });

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_user_id",
                table: "TRANSACTION",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FEEDBACK");

            migrationBuilder.DropTable(
                name: "NEW");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "SLIDE");

            migrationBuilder.DropTable(
                name: "SYS_DICTIONARY");

            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "TRANSACTION");

            migrationBuilder.DropTable(
                name: "CATALOG");

            migrationBuilder.DropTable(
                name: "TAG");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
