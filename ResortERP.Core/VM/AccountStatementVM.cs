using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortERP.Core.VM
{
    public class AccountStatementVM
    {

        //public long ENTRY_ID { get; set; }

        //public int? CUST_ACC_ID { get; set; }

        //public string BILL_AR_NAME { get; set; }

        //public double Credit { get; set; }

        //public double Debit { get; set; }


        public double? CREDIDT { get; set; }

        public double? DEBIT { get; set; }

        public double BAL { get; set; }

        public string CHEET { get; set; }

        public string ACCOUNT { get; set; }

        public Int64? BILL_ID { get; set; }

        public Int64? ENTRY_ID { get; set; }

        public DateTime? DATE { get; set; }
        public string DateString { get; set; }
        public string NOTE { get; set; }

        public string BILL_AR_NAME { get; set; }

        public int? BILL_NUMBER { get; set; }

        public int? ENTRY_NUMBER { get; set; }
        public double? Price { get; set; }
        public string BILL_REMARKS { get; set; }
        public string DeliveryPersonName { get; set; }
        public string ACC_AR_NAME { get; set; }

    }
}
