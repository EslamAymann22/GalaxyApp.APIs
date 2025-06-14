namespace GalaxyApp.Data.Entities
{
    public class Purchase : BaseEntity
    {

        public DateTime Date { get; set; } = DateTime.Now;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public Supplier SupplierLst { get; set; }



        public decimal TotalInDiscount
        {
            get
            {
                return CalculateTotalInDiscount();
            }
        }

        public List<PurchaseItems> PurchaseItems { get; set; } = new List<PurchaseItems>();


        private decimal CalculateTotalInDiscount()
        {
            decimal Ret = 0;
            foreach (var item in PurchaseItems)
                Ret += item.TotalInDiscount;
            return Ret;
        }
    }
}
