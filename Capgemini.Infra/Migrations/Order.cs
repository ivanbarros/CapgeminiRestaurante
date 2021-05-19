using Capgemini.Infra.Migrations.MigrationsConfig;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Infra.Migrations
{
    [Migration(16051941)]
    public class Order : Migration
    {
        public override void Down()
        {
            Delete.Table("order");
        }

        public override void Up()
        {
            Create.Table("order")
            .CreateBase(false)

            .WithColumn("tableNumber")
            .AsInt32()
            .NotNullable()

            .WithColumn("idFood")
            .AsInt32()
            .NotNullable()
            .ForeignKey("food", "Id")

            .WithColumn("orderTime")
            .AsDateTime()
            .NotNullable()

            .WithColumn("SteakDone")
            .AsString(30)
            .NotNullable()

            .WithColumn("quantity")
            .AsInt32()
            .NotNullable()

            .WithColumn("TotalPrice")
            .AsDecimal()
            .NotNullable()

            .WithColumn("idWaiter")
            .AsInt32()
            .NotNullable()
            .ForeignKey("Waiter", "Id")

            .WithColumn("closeOrder")
            .AsDateTime()
            .Nullable();
        }
    }
}
