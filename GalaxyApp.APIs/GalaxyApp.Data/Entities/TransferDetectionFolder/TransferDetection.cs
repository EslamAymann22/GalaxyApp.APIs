using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp.Data.Entities.TransferDetectionFolder
{
    public class TransferDetection : BaseEntity
    {


        public List<TransferDetectionItems> TransferDetectionItems { get; set; } = new List<TransferDetectionItems>();

        public TransferDetectionType transferDetectionType { get; set; }
        

    }
}
