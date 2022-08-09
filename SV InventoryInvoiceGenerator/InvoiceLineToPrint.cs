using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV_InventoryInvoiceGenerator
{
    public class InvoiceLineToPrint
    {
        int EvoInvoiceID { get; set; }
        String ProductCode { get; set; }
        String ProductDescription { get; set; }
        float QuantityDeliveredDoz { get; set; }
        float UnitSellingPriceDoz { get; set; }
        float NumberOfUnits { get; set; }
        float UnitSellingPrice { get; set; }
        float NumberOfBoxes { get; set; }
        float BoxSellingPrice { get; set; }
        float LineTotal { get; set; }
        String CompanyRegisteredName { get; set; }
        String CompanyName { get; set; }
        String CompanyAddress1 { get; set; }
        String CompanyAddress2 { get; set; }
        String CompanyAddress3 { get; set; }
        String CompanyCell { get; set; }
        String CompanyEmail { get; set; }
        String CompanyTelephone { get; set; }
        String CompanyFax { get; set; }
        String SalesRepCode { get; set; }
        String SalesRepName { get; set; }
        String CustomerAccountNumber { get; set; }
        String CustomerAccountname { get; set; }
        String CustomerAccountDescription { get; set; }
        String CustomerAddress1 { get; set; }
        String CustomerAddress2 { get; set; }
        String CustomerAddress3 { get; set; }
        String CustomerGPS { get; set; }
        String CustomerTaxNumber { get; set; }
        String CustomerInvoiceToAddress1 { get; set; }
        String CustomerInvoiceToAddress2 { get; set; }
        String CustomerInvoiceToAddress3 { get; set; }
        String CustomerInvoiceToAddress4 { get; set; }
        String CustomerInvoiceToTaxNumber { get; set; }
        String CustomerRegistrationNumber { get; set; }
        String CustomerTelephone { get; set; }
        String CustomerFax { get; set; }
        String CustomerContactPerson { get; set; }
        String CustomerAreaCode { get; set; }
        String CustomerAccountTerms { get; set; }
        String CustomerTermsDescription { get; set; }
        DateTime InvDate { get; set; }
        String OrderNum { get; set; }
        String DeliveryNote { get; set; }
        String ExtOrderNum { get; set; }
        String InvoiceNumber { get; set; }
        String CompanyBankName { get; set; }
        String CompanyBankAccountNumber { get; set; }
        String CompanyBranchCode { get; set; }
        Int64 BatchNumber { get; set; }
        String CreatedByUser { get; set; }
        Int64 StaginID { get; set; }
    }
}
