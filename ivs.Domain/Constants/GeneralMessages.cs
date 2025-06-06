﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Constants
{
    public class GeneralMessages
    {
        public static readonly string MinimumWithdrawalAmountMessage = $"Minimum settlement amount is {Helpers.MinimumWithdrawalAmount}";
        public static readonly string WrongQrCodePassed = $"Wrong qr code passed.";
        public static readonly string EnterTicketCode = $"Please enter your ticket code";
    }
}
