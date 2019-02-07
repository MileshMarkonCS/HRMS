using ModelCore.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelCore.CRM.Lead
{
    public class CRMLeadViewModel
    {
    }

    public class CRMLeadIndex
    {
        [Key]

        [Required]
        [Display(Name = "CRMLeadId")]
        public Int64 CRMLeadId { get; set; }

        [Required]
        [Display(Name = "Lead No.")]
        public string LeadNo { get; set; }

        [Required]
        [Display(Name = "Lead Date")]
        public DateTime LeadDate { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "MobileNo1")]
        public string MobileNo1 { get; set; }

        [Display(Name = "MobileNo2")]
        public string MobileNo2 { get; set; }

    }


    [NotMapped]
    public class CRMLeadEntry
    {
        [Key]
        [Display(Name = "CRMLeadId")]
        public Int64 CRMLeadId { get; set; }

        [Display(Name = "Lead Date")]
        public string LeadDate { get; set; }

        [Required]
        [Display(Name = "Lead User")]
        public Int64 LeadUserId { get; set; }

        [Required]
        [Display(Name = "Enquiry Source")]
        public Int64 EnquirySourceId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public Int64 TitleId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Mobile No.1")]
        public string MobileNo1 { get; set; }

        [Display(Name = "Mobile No.  2")]
        public string MobileNo2 { get; set; }


        [Display(Name = "Phone No. 1")]
        public string PhoneNo1 { get; set; }


        [Display(Name = "Phone No. 2")]
        public string PhoneNo2 { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "WebSite")]
        public string WebSite { get; set; }


        [Display(Name = "Skype ID")]
        public string SkypeID { get; set; }


        [Display(Name = "LinkedID")]
        public string LinkedID { get; set; }


        [Display(Name = "TwitterID")]
        public string TwitterID { get; set; }

        [Required]
        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }

        [Required]
        [Display(Name = "Country")]
        public Int64 CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        public Int64 StateId { get; set; }

        [Required]
        [Display(Name = "City")]
        public Int64 CityId { get; set; }

        [Required]
        [Display(Name = "PIN / ZIP Code")]
        public string PINZIPCode { get; set; }


        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Industry")]
        public Int64 IndustryId { get; set; }

        [Required]
        [Display(Name = "Segment")]
        public Int64 SegmentId { get; set; }

        [Display(Name = "PI No.")]
        public string PINo { get; set; }


        [Display(Name = "PI Date")]
        public string PIDate { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public Int64 BrandId { get; set; }

        [Required]
        [Display(Name = "Model")]
        public Int64 ModelId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Transaction Currency")]
        public Int64 TransactionCurrencyId { get; set; }

        [Required]
        [Display(Name = "Transaction Currency Rate")]
        public string TransactionCurrencyRate { get; set; }

        [Required]
        [Display(Name = "Traansaction Total Amount")]
        public string TransactionTotalAmount { get; set; }

        [Required]
        [Display(Name = "Alternate Transaction Currency")]
        public Int64 AlternateTransactionCurrencyId { get; set; }

        [Required]
        [Display(Name = "Alternate Transaction Currency Rate")]
        public string AlternateTransactionCurrencyRate { get; set; }

        [Required]
        [Display(Name = "Alternate Transaction Total Amount")]
        public string AlternateTransactionTotalAmount { get; set; }

        [Required]
        [Display(Name = "Base Currency")]
        public Int64 BaseCurrencyId { get; set; }

        [Required]
        [Display(Name = "Base Currency Rate")]
        public string BaseCurrencyRate { get; set; }

        [Required]
        [Display(Name = "Base Total Amount")]
        public string BaseTotalAmount { get; set; }

        [Required]
        [Display(Name = "Alternate Base Currency")]
        public Int64 AlternateBaseCurrencyId { get; set; }

        [Required]
        [Display(Name = "Alternate Base Currency Rate")]
        public string AlternateBaseCurrencyRate { get; set; }

        [Required]
        [Display(Name = "Alternate Base Total Amount")]
        public string AlternateBaseTotalAmount { get; set; }

        [Required]
        [Display(Name = "Foreign Currency")]
        public Int64 ForeignCurrencyId { get; set; }

        [Required]
        [Display(Name = "Foreign Currency Rate")]
        public string ForeignCurrencyRate { get; set; }

        [Required]
        [Display(Name = "Foreign Total Amount")]
        public string ForeignTotalAmount { get; set; }

        [Required]
        [Display(Name = "Alternate Foreign Currency")]
        public Int64 AlternateForeignCurrencyId { get; set; }

        [Required]
        [Display(Name = "Alternate Foreign Currency Rate")]
        public string AlternateForeignCurrencyRate { get; set; }

        [Required]
        [Display(Name = "Alternate Foreign Total Amount")]
        public string AlternateForeignTotalAmount { get; set; }

        [Required]
        [Display(Name = "Payment Mode")]
        public Int64 PaymentModeId { get; set; }

        [Required]
        [Display(Name = "Last Contact")]
        public string LastContact { get; set; }

        [Required]
        [Display(Name = "Next Action")]
        public Int64 NextActionId { get; set; }

        [Required]
        [Display(Name = "Next Action Description")]
        public string NextActionDescription { get; set; }

        [Required]
        [Display(Name = "Next Contact")]
        public string NextContact { get; set; }

        [Required]
        [Display(Name = "Enquiry Status")]
        public Int64 EnquiryStatusId { get; set; }

        [Required]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required]
        [Display(Name = "CHA No.")]
        public string CHANo { get; set; }

        [Required]
        [Display(Name = "Duty Tax")]
        public Int64 DutyTaxId { get; set; }

        [Required]
        [Display(Name = "Delivery Date")]
        public string DeliveryDate { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public Int64 RatingId { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "File")]
        public Int64 FileId { get; set; }

        [Required]
        [Display(Name = "Audit Columns")]
        public AuditColumns AuditColumns { get; set; }
    }

}
