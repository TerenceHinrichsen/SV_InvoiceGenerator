using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV_InventoryInvoiceGenerator
{
    public class InvoiceHeader
    {
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
        String CustomerAccountName { get; set; }
        String CustomerAccountDescription { get; set; }
        String CustomerAddress1 { get; set; }
        String CustomerAddress2 { get; set; }
        String CustomerAddress3 { get; set; }
        String CustomerGPS { get; set; }
        String CustomerTaxNumber { get; set; }
        String CustomerRegistrationNumber { get; set; }
        String CustomerTelephone { get; set; }
        String CustomerFax { get; set; }
        String CustomerContactPerson { get; set; }
        String CustomerAreaCode { get; set; }
        String CustomerAccountTerms { get; set; }
        String CustomerAccountTermsDescription { get; set; }
        String OrderNumber { get; set; }
        String DeliveryNoteNumber { get; set; }
        String ExternalOrderNumber { get; set; }
        String InvoiceNumber { get; set; }
        String CompanyBankAccountName { get; set; }
        String CompanyBankAccountNumber { get; set; }
        String CompanyBankBranchCode { get; set; }
        String CreatedByUserName { get; set; }
        DateTime InvoiceDate { get; set; }
        Int32 EvoInvoiceID { get; set; }
        Int64 BatchNumber { get; set; }
        DateTime CreatedOnDateTime { get; set; }

    }
}
