using System.Data.Entity;
using PALMS.Data.Objects;
using PALMS.Data.Objects.ClientModel;
using PALMS.Data.Objects.LinenModel;
using PALMS.Data.Objects.NoteModel;

namespace PALMS.Data.Services
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientInfo> ClientInfos { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<NoteTemplate> NoteTemplates { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TicketTemplate> TicketTemplates { get; set; }
        public DbSet<InvoiceTemplate> InvoiceTemplates { get; set; }
        public DbSet<DepartmentList> DepartmentLists { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<FamilyLinen> FamilyLinens { get; set; }
        public DbSet<GroupLinen> GroupLinens { get; set; }
        public DbSet<LinenList> LinenLists { get; set; }
        public DbSet<MasterLinen> MasterLinens { get; set; }
        public DbSet<TypeLinen> TypeLinens { get; set; }

        public DbSet<DeliveryNote> DeliveryNotes { get; set; }
        //public DbSet<DeliveryNoteDetails> DeliveryNoteDetailses { get; set; }
        public DbSet<DeliveryNoteRows> DeliveryNoteRowses { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<ReceivingNote> ReceivingNotes { get; set; }
        public DbSet<ReceivingNoteRows> ReceivingNoteRowses { get; set; }
        public DbSet<ReturnOrder> ReturnOrders { get; set; }
        public DbSet<ReturnOrderRows> ReturnOrderRowses { get; set; }
        public DbSet<ReturnReason> ReturnReasons { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceRow> InvoiceRows { get; set; }


        public DataContext() : base("name=PrimeConnection")
        {
            
        }
    }
}
