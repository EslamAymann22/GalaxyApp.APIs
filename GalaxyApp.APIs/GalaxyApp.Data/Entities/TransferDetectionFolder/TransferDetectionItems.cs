namespace GalaxyApp.Data.Entities.TransferDetectionFolder
{
    public class TransferDetectionItems : BaseEntity
    {

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int TransferDetectionId { get; set; }
        public TransferDetection transferDetection { get; set; }


        public int Quantity { get; set; }

    }
}
