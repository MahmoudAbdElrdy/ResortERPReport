using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortERP.Core.VM
{
 public class Entry_ReportVM
    {
    
        public string ENTRY_SETTING_AR_NAME { get; set; }
      
        public string Date { get; set; }
       // public System.DateTime Date { get; set; }
  
        public double? TotalCredit { get; set; }
        public double? TotalDepit { get; set; }
        public double? TotalGoldCredit24 { get; set; }
        public double? TotalGoldDepit24 { get; set; }
        public double? TotalGoldCredit22 { get; set; }
        public double? TotalGoldDepit22 { get; set; }
        public double? TotalGoldCredit21 { get; set; }
        public double? TotalGoldDepit21 { get; set; }
        public double? TotalGoldCredit18 { get; set; }
        public double? TotalGoldDepit18 { get; set; }
        public double? Total { get; set; }

        //ضرائب
    
    }

    public class EntryDetails_ReportVM
    {

        public Int64? entryNumber { get; set; }

        public DateTime DATE { get; set; }
        public string stringDATE { get; set; }
        public string monthDATE { get; set; }
        // public System.DateTime Date { get; set; }
        public string entryName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double? Credit { get; set; }
        public double? Debit { get; set; }
        public double? GOLD24_CREDIT { get; set; }
        public double? GOLD24_DEBIT { get; set; }
        public double? GOLD22_CREDIT { get; set; }
        public double? GOLD21_CREDIT { get; set; }
        public double? GOLD18_CREDIT { get; set; }
        public double? GOLD22_DEBIT { get; set; }
        public double? GOLD21_DEBIT { get; set; }
        public double? GOLD18_DEBIT { get; set; }
        public string PersonName { get; set; }

        //ضرائب

    }
}
