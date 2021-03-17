using FluentMigrator;
using System.Data;

namespace OnlineShop.Migration.Migrations
{
    [Migration(202103160824)]
    public class _202103160824_SchemaInitialized : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("ProductCategories")
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                 .WithColumn("Title").AsString(100).NotNullable();

            Create.Table("Products")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("ProductCategoryId").AsInt32().NotNullable()
               .ForeignKey("FK_Products_ProductCategories", "ProductCategories", "Id")
               .OnDelete(Rule.None)
               .WithColumn("Title").AsString(100).NotNullable()
               .WithColumn("Code").AsString(10).NotNullable()
               .WithColumn("MinimumStack").AsInt32().NotNullable();

            Create.Table("ParchaseInvoices")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_Products_ParchaseInvoices", "Products", "Id")
                .WithColumn("Number").AsString(20).NotNullable()
                .WithColumn("ProductCount").AsInt32().NotNullable()
                .WithColumn("DateRegistration").AsDateTime().NotNullable();

            Create.Table("StoreRooms")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_Products_StoreRooms", "Products", "Id")
                .WithColumn("Stock").AsInt32().NotNullable();

            Create.Table("SaleInvoices")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Number").AsString(20).NotNullable()
                .WithColumn("CustomerName").AsString(100).NotNullable()
                .WithColumn("DateRegistration").AsDateTime().NotNullable();

            Create.Table("SaleInvoiceItems")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("SaleInvoiceId").AsInt32().NotNullable()
                .ForeignKey("FK_SaleInvoiceItems_SaleInvoices", "SaleInvoices", "Id")
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_products_SaleInvoiceItems", "Products", "Id")
                .WithColumn("ProductCount").AsInt32().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();

            Create.Table("AccuntingDocuments")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("SaleInvoiceId").AsInt32().NotNullable()
               .ForeignKey("FK_AccuntingDocuments_SaleInvoices", "SaleInvoices", "Id")
               .WithColumn("SaleInvoiceNumber").AsString(20).NotNullable()
               .WithColumn("DateRegistration").AsDateTime().NotNullable()
               .WithColumn("TotalAmount").AsDecimal().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("ProductCategories");
            Delete.Table("Products");
            Delete.Table("ParchaseInvoices");
            Delete.Table("StoreRooms");
            Delete.Table("SaleInvoices");
            Delete.Table("SaleInvoiceItems");
            Delete.Table("AccuntingDocuments");
        }
    }
}
