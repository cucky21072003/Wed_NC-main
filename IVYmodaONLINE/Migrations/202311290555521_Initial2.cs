namespace IVYmodaONLINE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_ProductCategory", "SeoDescription", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_ProductCategory", "SeoDescription", c => c.String(maxLength: 500));
        }
    }
}
