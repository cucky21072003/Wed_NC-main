namespace IVYmodaONLINE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_ProductImage", "Image", c => c.String(maxLength: 550));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_ProductImage", "Image", c => c.String());
        }
    }
}
