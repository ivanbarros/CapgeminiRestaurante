﻿using Capgemini.Infra.Migrations.MigrationsConfig;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Infra.Migrations
{
    [Migration(16051933)]
    public class Waiter : Migration
    {
        public override void Down()
        {
            Delete.Table("Waiter");
        }

        public override void Up()
        {
            Create.Table("Waiter")
            .CreateBase(false)
            .WithColumn("Name")
            .AsString(55)
            .NotNullable();
        }
    }
}
