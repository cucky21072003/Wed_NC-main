﻿namespace IVYmodaONLINE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Category", "Seotitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoDescription", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Category", "SeoKeyWords", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "SeoKeyWords", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Category", "SeoDescription", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Category", "Seotitle", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Category", "Title", c => c.String());
        }
    }
}
