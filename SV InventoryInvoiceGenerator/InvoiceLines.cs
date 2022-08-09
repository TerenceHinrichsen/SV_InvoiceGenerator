using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV_InventoryInvoiceGenerator
{
    public class InvoiceLines
    {
        int InvoiceID { get; set; }
        String ProductCode { get; set; }
        String ProductDescription { get; set; }
        float QuantityDeliveredDoz { get; set; }
        float UnitSellingPriceDoz { get; set; }
        float NumberOfUnits { get; set; }
        float UnitSellingPriceUnit { get; set; }
        float NumberOfBoxes { get; set; }
        float UnitSellingPriceBox { get; set; }
        float LineTotalAmount { get; set; }
        Int64 BatchNumber { get; set; }
    }
}
