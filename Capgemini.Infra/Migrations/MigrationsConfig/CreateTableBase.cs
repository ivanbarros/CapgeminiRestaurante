using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Capgemini.Infra.Migrations.MigrationsConfig
{
    public static class CreateTableBase
    {
        public static ICreateTableWithColumnSyntax CreateBase(this ICreateTableWithColumnSyntax create, bool userFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey();

            if (userFK)
                create
                    .WithColumn("IdUsuario")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("Usuario", "Id");

            return create;
        }
        public static ICreateTableWithColumnSyntax CreateBaseNoActive(this ICreateTableWithColumnSyntax create, bool userFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey()
                .WithColumn("CreateDate")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(SystemMethods.CurrentDateTime);

            if (userFK)
                create
                    .WithColumn("IdUsuario")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey("Usuario", "Id");

            return create;
        }

        public static ICreateTableWithColumnSyntax CreateBaseNotNullable(this ICreateTableWithColumnSyntax create, bool tablerFK = true)
        {
            create
                .WithColumn("Id")
                    .AsInt32()
                    .NotNullable()
                    .Identity()
                    .PrimaryKey()
                .WithColumn("CreateDate")
                    .AsDateTime()
                    .NotNullable()
                    .WithDefaultValue(SystemMethods.CurrentDateTime);

            if (tablerFK)
                create
                    .WithColumn("IdTable")
                    .AsInt32()
                    .Nullable()
                    .ForeignKey("Table", "Id");

            return create;
        }
    }
}