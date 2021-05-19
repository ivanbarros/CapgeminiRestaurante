using Capgemini.Infra.Migrations.MigrationsConfig;
using FluentMigrator;

namespace Capgemini.Infra.Migrations
{
    [Migration(16051915)]
    public class Food : Migration
    {
        public override void Down()
        {
            Delete.Table("food");
        }

        public override void Up()
        {
            Create.Table("food")
            .CreateBase(false)
            .WithColumn("Name")
            .AsString(255)
            .NotNullable()
            
            .WithColumn("Price")
            .AsDecimal()
            .NotNullable()
            
            .WithColumn("Type")
            .AsString(30)
            .NotNullable()
            
            .WithColumn("Taste")
            .AsString(20)
            .Nullable()
            
            .WithColumn("Temperature")
            .AsString(30)
            .NotNullable();
        }
    }
}
