namespace GalaxyApp.Data.Entities
{
    public class Purchase : BaseEntity
    {
        private decimal CalculateTotalInDiscount()
        {
            decimal Ret = 0;
            foreach (var item in PurchaseItems)
                Ret += item.TotalInDiscount;
            return Ret;
        }


        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public decimal TotalInDiscount => CalculateTotalInDiscount();

        public List<InvoiceItems> PurchaseItems { get; set; } = new List<InvoiceItems>();
    }
}
