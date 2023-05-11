using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class PaymentDTO
    {
        public int paymentID { get; set; }
        public Nullable<int> contract_no { get; set; }
        public string contractorName { get; set; }
        public string num_release { get; set; }
        public int yearestablishedId { get; set; }
        

    }
}