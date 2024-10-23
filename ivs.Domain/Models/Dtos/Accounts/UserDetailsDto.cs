using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Accounts
{
    public class UserDetailsDto
    {
        public string _id { get; set; }
        public string fullname { get; set; }
        public string organisation_id { get; set; }
        public string email { get; set; }
        public bool isVerified { get; set; }
        public bool isActive { get; set; }
        public string createdAt { get; set; }
        public string UpdatedAt { get; set; }
        public string activatedOn { get; set; }
        public string passwordUpdatedOn { get; set; }
        public string role { get; set; }
        public Settlementaccount[] settlementAccounts { get; set; }

    }

    public class Settlementaccount
    {
        public string userId { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public bool isEnable { get; set; }
        public string createdAt { get; set; }
    }
}
