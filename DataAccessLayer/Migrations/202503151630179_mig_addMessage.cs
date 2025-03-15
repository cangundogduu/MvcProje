namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
