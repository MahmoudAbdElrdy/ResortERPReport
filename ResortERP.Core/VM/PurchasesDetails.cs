using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortERP.Core.VM
{
    public class PurchasesDetails 
    {
        public double? DEBIT_Gold24 { get; set; }

        public double? CREDIT_Gold24 { get; set; }

        public double? BAL_Gold24 { get; set; }



        public double? DEBIT_Gold22 { get; set; }

        public double? CREDIT_Gold22 { get; set; }

        public double? BAL_Gold22 { get; set; }



        public double? DEBIT_Gold21 { get; set; }

        public double? CREDIT_Gold21 { get; set; }

        public double? BAL_Gold21 { get; set; }



        public double? DEBIT_Gold18 { get; set; }

        public double? CREDIT_Gold18 { get; set; }

        public double? BAL_Gold18 { get; set; }
        public double? CREDIDT { get; set; }

        public double? DEBIT { get; set; }

    
        public Int64? BILL_ID { get; set; }

        public Int64? ENTRY_ID { get; set; }

        public DateTime? DATE { get; set; }
        public string DateString { get; set; }
        public string DateMonthString { get; set; }
        
        public string BILL_AR_NAME { get; set; }

        public string BILL_NUMBER { get; set; }

        public int? ENTRY_NUMBER { get; set; }
        public double? Price { get; set; }
        public string BILL_REMARKS { get; set; }
        public string DeliveryPersonName { get; set; }
        public string ACC_AR_NAME { get; set; }
        public int? CUST_ACC_ID { get; set; }
    }
    
}
