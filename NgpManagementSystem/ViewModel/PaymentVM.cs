using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.ViewModel
{
    public class PaymentVM
    {
        public int paymentID { get; set; }
        public Nullable<int> contract_no { get; set; }
        public string contractorName { get; set; }
        public string num_release { get; set; }

        public virtual ngp_contract ngp_contract { get; set; }
    }
}