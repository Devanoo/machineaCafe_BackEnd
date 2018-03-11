namespace MachineàCafe_BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_create : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boissons", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boissons", "Name", c => c.String(nullable: false));
        }
    }
}
