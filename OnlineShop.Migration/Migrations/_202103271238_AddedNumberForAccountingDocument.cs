using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Migrations.Migrations
{
    [Migration(202103271238)]
    public class _202103271238_AddedNumberForAccountingDocument : FluentMigrator.Migration
    {
        public override void Up()
        {
            Alter.Table("AccuntingDocuments")
                .AddColumn("Number").AsString(20).NotNullable();
        }
        public override void Down()
        {
            Delete.Column("Number").FromTable("AccuntingDocuments");
        }

        
    }
}
