namespace PALMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientInfoes",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        City = c.String(),
                        Comment = c.String(),
                        JoinDate = c.DateTime(),
                        TicketId = c.Int(nullable: false),
                        NoteId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.InvoiceTemplates", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.NoteTemplates", t => t.NoteId, cascadeDelete: true)
                .ForeignKey("dbo.TicketTemplates", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.TicketId)
                .Index(t => t.NoteId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        ShortName = c.String(),
                        Color = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.DeliveryNotes",
                c => new
                    {
                        DNoteId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        NoteStatusId = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Comments = c.String(),
                        ReceivingNoteId = c.Int(),
                        ReturnOrderId = c.Int(),
                        DeliveryTypeId = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DNoteId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.DepartmentLists", t => new { t.ClientId, t.DepartmentID }, cascadeDelete: true)
                .ForeignKey("dbo.DeliveryTypes", t => t.DeliveryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ReceivingNotes", t => t.ReceivingNoteId)
                .ForeignKey("dbo.ReturnOrders", t => t.ReturnOrderId)
                .Index(t => t.ClientId)
                .Index(t => new { t.ClientId, t.DepartmentID })
                .Index(t => t.ReceivingNoteId)
                .Index(t => t.ReturnOrderId)
                .Index(t => t.DeliveryTypeId);
            
            CreateTable(
                "dbo.DeliveryNoteDetails",
                c => new
                    {
                        DeliveryNoteId = c.Int(nullable: false),
                        ExpressCharge = c.Int(nullable: false),
                        WeightCharge = c.Single(nullable: false),
                        MonthlyCharge = c.Int(nullable: false),
                        ExtraCharge = c.Int(nullable: false),
                        DeliveryTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryNoteId)
                .ForeignKey("dbo.DeliveryNotes", t => t.DeliveryNoteId)
                .ForeignKey("dbo.DeliveryTypes", t => t.DeliveryTypeId, cascadeDelete: true)
                .Index(t => t.DeliveryNoteId)
                .Index(t => t.DeliveryTypeId);
            
            CreateTable(
                "dbo.DeliveryTypes",
                c => new
                    {
                        DeliveryTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DeliveryTypeId);
            
            CreateTable(
                "dbo.DeliveryNoteRows",
                c => new
                    {
                        DeliveryNoteId = c.Int(nullable: false),
                        LinenId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        LinenWeight = c.Int(),
                        LinenPrice = c.Single(),
                        RFIDPrice = c.Int(),
                    })
                .PrimaryKey(t => new { t.DeliveryNoteId, t.LinenId })
                .ForeignKey("dbo.DeliveryNotes", t => t.DeliveryNoteId, cascadeDelete: true)
                .ForeignKey("dbo.MasterLinens", t => t.LinenId, cascadeDelete: true)
                .Index(t => t.DeliveryNoteId)
                .Index(t => t.LinenId);
            
            CreateTable(
                "dbo.MasterLinens",
                c => new
                    {
                        LinenId = c.Int(nullable: false),
                        Nomination = c.String(),
                        TypeId = c.Int(nullable: false),
                        FamilyId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LinenId)
                .ForeignKey("dbo.FamilyLinens", t => t.FamilyId, cascadeDelete: true)
                .ForeignKey("dbo.GroupLinens", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.TypeLinens", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.FamilyId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.FamilyLinens",
                c => new
                    {
                        FamilyId = c.Int(nullable: false, identity: true),
                        FamilyName = c.String(),
                    })
                .PrimaryKey(t => t.FamilyId);
            
            CreateTable(
                "dbo.GroupLinens",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.LinenLists",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        LinenId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Weight = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        RFID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.LinenId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.MasterLinens", t => t.LinenId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.LinenId);
            
            CreateTable(
                "dbo.ReceivingNoteRows",
                c => new
                    {
                        ReceivingNoteId = c.Int(nullable: false),
                        LinenId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReceivingNoteId, t.LinenId })
                .ForeignKey("dbo.MasterLinens", t => t.LinenId, cascadeDelete: true)
                .ForeignKey("dbo.ReceivingNotes", t => t.ReceivingNoteId, cascadeDelete: true)
                .Index(t => t.ReceivingNoteId)
                .Index(t => t.LinenId);
            
            CreateTable(
                "dbo.ReceivingNotes",
                c => new
                    {
                        ReceivingNoteId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ReceivingDate = c.DateTime(nullable: false),
                        NoteStatusId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceivingNoteId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.DepartmentLists", t => new { t.ClientId, t.DepartmentId }, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => new { t.ClientId, t.DepartmentId });
            
            CreateTable(
                "dbo.DepartmentLists",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.DepartmentId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .Index(t => t.ClientId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.ReturnOrderRows",
                c => new
                    {
                        ReturnOrderId = c.Int(nullable: false),
                        LinenId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ReturnReasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReturnOrderId, t.LinenId })
                .ForeignKey("dbo.MasterLinens", t => t.LinenId, cascadeDelete: true)
                .ForeignKey("dbo.ReturnOrders", t => t.ReturnOrderId, cascadeDelete: true)
                .ForeignKey("dbo.ReturnReasons", t => t.ReturnReasonId, cascadeDelete: true)
                .Index(t => t.ReturnOrderId)
                .Index(t => t.LinenId)
                .Index(t => t.ReturnReasonId);
            
            CreateTable(
                "dbo.ReturnOrders",
                c => new
                    {
                        ReturnOrderId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ReceivingDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReturnOrderId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ReturnReasons",
                c => new
                    {
                        ReturnReasonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReturnReasonId);
            
            CreateTable(
                "dbo.TypeLinens",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.InvoiceRows",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false),
                        DeliveryNoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceId, t.DeliveryNoteId })
                .ForeignKey("dbo.DeliveryNotes", t => t.DeliveryNoteId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.DeliveryNoteId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        MonthlyCharge = c.Int(),
                        WeightCharge = c.Single(),
                        ExtraCharge = c.Int(),
                        VAT = c.Int(),
                        ExtraWeight = c.Single(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: false)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                        MonthlyCharge = c.Single(nullable: false),
                        WeightCharge = c.Single(nullable: false),
                        ExpressCharge = c.Int(nullable: false),
                        ExtraCharge = c.Single(nullable: false),
                        StartDate = c.Int(nullable: false),
                        EndDate = c.Int(nullable: false),
                        VAT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.InvoiceTemplates",
                c => new
                    {
                        InvoiciID = c.Int(nullable: false, identity: true),
                        InvoiceName = c.String(),
                    })
                .PrimaryKey(t => t.InvoiciID);
            
            CreateTable(
                "dbo.NoteTemplates",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        NoteName = c.String(),
                    })
                .PrimaryKey(t => t.NoteId);
            
            CreateTable(
                "dbo.TicketTemplates",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        TicketName = c.String(),
                    })
                .PrimaryKey(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientInfoes", "TicketId", "dbo.TicketTemplates");
            DropForeignKey("dbo.ClientInfoes", "NoteId", "dbo.NoteTemplates");
            DropForeignKey("dbo.ClientInfoes", "InvoiceId", "dbo.InvoiceTemplates");
            DropForeignKey("dbo.ClientInfoes", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.InvoiceDetails", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.InvoiceDetails", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.DeliveryNotes", "ReturnOrderId", "dbo.ReturnOrders");
            DropForeignKey("dbo.DeliveryNotes", "ReceivingNoteId", "dbo.ReceivingNotes");
            DropForeignKey("dbo.InvoiceRows", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.InvoiceRows", "DeliveryNoteId", "dbo.DeliveryNotes");
            DropForeignKey("dbo.DeliveryNotes", "DeliveryTypeId", "dbo.DeliveryTypes");
            DropForeignKey("dbo.DeliveryNoteRows", "LinenId", "dbo.MasterLinens");
            DropForeignKey("dbo.MasterLinens", "TypeId", "dbo.TypeLinens");
            DropForeignKey("dbo.ReturnOrderRows", "ReturnReasonId", "dbo.ReturnReasons");
            DropForeignKey("dbo.ReturnOrderRows", "ReturnOrderId", "dbo.ReturnOrders");
            DropForeignKey("dbo.ReturnOrders", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ReturnOrderRows", "LinenId", "dbo.MasterLinens");
            DropForeignKey("dbo.ReceivingNoteRows", "ReceivingNoteId", "dbo.ReceivingNotes");
            DropForeignKey("dbo.ReceivingNotes", new[] { "ClientId", "DepartmentId" }, "dbo.DepartmentLists");
            DropForeignKey("dbo.DepartmentLists", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DeliveryNotes", new[] { "ClientId", "DepartmentID" }, "dbo.DepartmentLists");
            DropForeignKey("dbo.DepartmentLists", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ReceivingNotes", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ReceivingNoteRows", "LinenId", "dbo.MasterLinens");
            DropForeignKey("dbo.LinenLists", "LinenId", "dbo.MasterLinens");
            DropForeignKey("dbo.LinenLists", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.MasterLinens", "GroupId", "dbo.GroupLinens");
            DropForeignKey("dbo.MasterLinens", "FamilyId", "dbo.FamilyLinens");
            DropForeignKey("dbo.DeliveryNoteRows", "DeliveryNoteId", "dbo.DeliveryNotes");
            DropForeignKey("dbo.DeliveryNoteDetails", "DeliveryTypeId", "dbo.DeliveryTypes");
            DropForeignKey("dbo.DeliveryNoteDetails", "DeliveryNoteId", "dbo.DeliveryNotes");
            DropForeignKey("dbo.DeliveryNotes", "ClientId", "dbo.Clients");
            DropIndex("dbo.InvoiceDetails", new[] { "PaymentId" });
            DropIndex("dbo.InvoiceDetails", new[] { "ClientId" });
            DropIndex("dbo.Invoices", new[] { "ClientId" });
            DropIndex("dbo.InvoiceRows", new[] { "DeliveryNoteId" });
            DropIndex("dbo.InvoiceRows", new[] { "InvoiceId" });
            DropIndex("dbo.ReturnOrders", new[] { "ClientId" });
            DropIndex("dbo.ReturnOrderRows", new[] { "ReturnReasonId" });
            DropIndex("dbo.ReturnOrderRows", new[] { "LinenId" });
            DropIndex("dbo.ReturnOrderRows", new[] { "ReturnOrderId" });
            DropIndex("dbo.DepartmentLists", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentLists", new[] { "ClientId" });
            DropIndex("dbo.ReceivingNotes", new[] { "ClientId", "DepartmentId" });
            DropIndex("dbo.ReceivingNotes", new[] { "ClientId" });
            DropIndex("dbo.ReceivingNoteRows", new[] { "LinenId" });
            DropIndex("dbo.ReceivingNoteRows", new[] { "ReceivingNoteId" });
            DropIndex("dbo.LinenLists", new[] { "LinenId" });
            DropIndex("dbo.LinenLists", new[] { "ClientId" });
            DropIndex("dbo.MasterLinens", new[] { "GroupId" });
            DropIndex("dbo.MasterLinens", new[] { "FamilyId" });
            DropIndex("dbo.MasterLinens", new[] { "TypeId" });
            DropIndex("dbo.DeliveryNoteRows", new[] { "LinenId" });
            DropIndex("dbo.DeliveryNoteRows", new[] { "DeliveryNoteId" });
            DropIndex("dbo.DeliveryNoteDetails", new[] { "DeliveryTypeId" });
            DropIndex("dbo.DeliveryNoteDetails", new[] { "DeliveryNoteId" });
            DropIndex("dbo.DeliveryNotes", new[] { "DeliveryTypeId" });
            DropIndex("dbo.DeliveryNotes", new[] { "ReturnOrderId" });
            DropIndex("dbo.DeliveryNotes", new[] { "ReceivingNoteId" });
            DropIndex("dbo.DeliveryNotes", new[] { "ClientId", "DepartmentID" });
            DropIndex("dbo.DeliveryNotes", new[] { "ClientId" });
            DropIndex("dbo.ClientInfoes", new[] { "InvoiceId" });
            DropIndex("dbo.ClientInfoes", new[] { "NoteId" });
            DropIndex("dbo.ClientInfoes", new[] { "TicketId" });
            DropIndex("dbo.ClientInfoes", new[] { "ClientId" });
            DropTable("dbo.TicketTemplates");
            DropTable("dbo.NoteTemplates");
            DropTable("dbo.InvoiceTemplates");
            DropTable("dbo.Payments");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceRows");
            DropTable("dbo.TypeLinens");
            DropTable("dbo.ReturnReasons");
            DropTable("dbo.ReturnOrders");
            DropTable("dbo.ReturnOrderRows");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentLists");
            DropTable("dbo.ReceivingNotes");
            DropTable("dbo.ReceivingNoteRows");
            DropTable("dbo.LinenLists");
            DropTable("dbo.GroupLinens");
            DropTable("dbo.FamilyLinens");
            DropTable("dbo.MasterLinens");
            DropTable("dbo.DeliveryNoteRows");
            DropTable("dbo.DeliveryTypes");
            DropTable("dbo.DeliveryNoteDetails");
            DropTable("dbo.DeliveryNotes");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientInfoes");
        }
    }
}
