namespace GuiltyPleasures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Exercise", "Carbs");
            DropColumn("dbo.Exercise", "Fat");
            DropColumn("dbo.Exercise", "Protein");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercise", "Protein", c => c.Double(nullable: false));
            AddColumn("dbo.Exercise", "Fat", c => c.Double(nullable: false));
            AddColumn("dbo.Exercise", "Carbs", c => c.Double(nullable: false));
        }
    }
}
