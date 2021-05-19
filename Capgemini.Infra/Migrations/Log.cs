using Capgemini.Infra.Migrations.MigrationsConfig;
using FluentMigrator;
using System;

namespace Capgemini.Infra.Migrations
{
    [Migration(16051956)]
    public class Log : Migration
    {
        public override void Down()
        {
            Delete.Table("log");
        }
       
        public override void Up()
        {
            Create.Table("log")
            .CreateBase(false)
            .WithColumn("Method_Name")
            .AsString()
            .NotNullable()
            
            .WithColumn("ErrorMessage")
            .AsString()
            .NotNullable()
            
            .WithColumn("ErrorDay")
            .AsDate()
            .NotNullable();
        }
    }
}
