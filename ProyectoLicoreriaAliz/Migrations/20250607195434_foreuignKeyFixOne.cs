using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLicoreriaAliz.Migrations
{
    /// <inheritdoc />
    public partial class foreuignKeyFixOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Productos_Providers_Providerid",
                table: "Entradas_Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Detalle_Producto_Productos_Productoid",
                table: "Provider_Detalle_Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Detalle_Producto_Providers_Providerid",
                table: "Provider_Detalle_Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Detail_Purchases_Purchaseid",
                table: "Purchase_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Refunds_Refundid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_Roleid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "client_id",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "Purchase_Detail");

            migrationBuilder.DropColumn(
                name: "producto_id",
                table: "Provider_Detalle_Producto");

            migrationBuilder.DropColumn(
                name: "provider_id",
                table: "Provider_Detalle_Producto");

            migrationBuilder.DropColumn(
                name: "provider_id",
                table: "Entradas_Productos");

            migrationBuilder.RenameColumn(
                name: "Roleid",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Roleid",
                table: "Users",
                newName: "IX_Users_roleId");

            migrationBuilder.RenameColumn(
                name: "Refundid",
                table: "Purchases",
                newName: "refundId");

            migrationBuilder.RenameColumn(
                name: "refund_id",
                table: "Purchases",
                newName: "clientId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_Refundid",
                table: "Purchases",
                newName: "IX_Purchases_refundId");

            migrationBuilder.RenameColumn(
                name: "Purchaseid",
                table: "Purchase_Detail",
                newName: "purchaseId");

            migrationBuilder.RenameColumn(
                name: "purchase_id",
                table: "Purchase_Detail",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_Detail_Purchaseid",
                table: "Purchase_Detail",
                newName: "IX_Purchase_Detail_purchaseId");

            migrationBuilder.RenameColumn(
                name: "Providerid",
                table: "Provider_Detalle_Producto",
                newName: "providerId");

            migrationBuilder.RenameColumn(
                name: "Productoid",
                table: "Provider_Detalle_Producto",
                newName: "productoId");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_Detalle_Producto_Providerid",
                table: "Provider_Detalle_Producto",
                newName: "IX_Provider_Detalle_Producto_providerId");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_Detalle_Producto_Productoid",
                table: "Provider_Detalle_Producto",
                newName: "IX_Provider_Detalle_Producto_productoId");

            migrationBuilder.RenameColumn(
                name: "Providerid",
                table: "Entradas_Productos",
                newName: "providerId");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_Productos_Providerid",
                table: "Entradas_Productos",
                newName: "IX_Entradas_Productos_providerId");

            migrationBuilder.RenameColumn(
                name: "entrada_producto_id",
                table: "Detalle_Entradas",
                newName: "entradaProductoId");

            migrationBuilder.AlterColumn<int>(
                name: "refundId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Productos_Providers_providerId",
                table: "Entradas_Productos",
                column: "providerId",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Detalle_Producto_Productos_productoId",
                table: "Provider_Detalle_Producto",
                column: "productoId",
                principalTable: "Productos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Detalle_Producto_Providers_providerId",
                table: "Provider_Detalle_Producto",
                column: "providerId",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Detail_Purchases_purchaseId",
                table: "Purchase_Detail",
                column: "purchaseId",
                principalTable: "Purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Refunds_refundId",
                table: "Purchases",
                column: "refundId",
                principalTable: "Refunds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Productos_Providers_providerId",
                table: "Entradas_Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Detalle_Producto_Productos_productoId",
                table: "Provider_Detalle_Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Detalle_Producto_Providers_providerId",
                table: "Provider_Detalle_Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Detail_Purchases_purchaseId",
                table: "Purchase_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Refunds_refundId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_roleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "Roleid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleId",
                table: "Users",
                newName: "IX_Users_Roleid");

            migrationBuilder.RenameColumn(
                name: "refundId",
                table: "Purchases",
                newName: "Refundid");

            migrationBuilder.RenameColumn(
                name: "clientId",
                table: "Purchases",
                newName: "refund_id");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_refundId",
                table: "Purchases",
                newName: "IX_Purchases_Refundid");

            migrationBuilder.RenameColumn(
                name: "purchaseId",
                table: "Purchase_Detail",
                newName: "Purchaseid");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Purchase_Detail",
                newName: "purchase_id");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_Detail_purchaseId",
                table: "Purchase_Detail",
                newName: "IX_Purchase_Detail_Purchaseid");

            migrationBuilder.RenameColumn(
                name: "providerId",
                table: "Provider_Detalle_Producto",
                newName: "Providerid");

            migrationBuilder.RenameColumn(
                name: "productoId",
                table: "Provider_Detalle_Producto",
                newName: "Productoid");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_Detalle_Producto_providerId",
                table: "Provider_Detalle_Producto",
                newName: "IX_Provider_Detalle_Producto_Providerid");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_Detalle_Producto_productoId",
                table: "Provider_Detalle_Producto",
                newName: "IX_Provider_Detalle_Producto_Productoid");

            migrationBuilder.RenameColumn(
                name: "providerId",
                table: "Entradas_Productos",
                newName: "Providerid");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_Productos_providerId",
                table: "Entradas_Productos",
                newName: "IX_Entradas_Productos_Providerid");

            migrationBuilder.RenameColumn(
                name: "entradaProductoId",
                table: "Detalle_Entradas",
                newName: "entrada_producto_id");

            migrationBuilder.AddColumn<int>(
                name: "role_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Refundid",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "client_id",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "Purchase_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "producto_id",
                table: "Provider_Detalle_Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "provider_id",
                table: "Provider_Detalle_Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "provider_id",
                table: "Entradas_Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Productos_Providers_Providerid",
                table: "Entradas_Productos",
                column: "Providerid",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Detalle_Producto_Productos_Productoid",
                table: "Provider_Detalle_Producto",
                column: "Productoid",
                principalTable: "Productos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Detalle_Producto_Providers_Providerid",
                table: "Provider_Detalle_Producto",
                column: "Providerid",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Detail_Purchases_Purchaseid",
                table: "Purchase_Detail",
                column: "Purchaseid",
                principalTable: "Purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Refunds_Refundid",
                table: "Purchases",
                column: "Refundid",
                principalTable: "Refunds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_Roleid",
                table: "Users",
                column: "Roleid",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
