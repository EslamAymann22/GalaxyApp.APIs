namespace GalaxyApp.Data.Entities.TransferDetectionFolder
{
    public class TransferDetection : BaseEntity
    {


        public List<TransferDetectionItems> TransferDetectionItems { get; set; } = new List<TransferDetectionItems>();

        public TransferDetectionType transferDetectionType { get; set; }


    }
}
