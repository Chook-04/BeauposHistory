using System;
using System.Collections.Generic;
using System.Text;

namespace BeauposHistory.Shared.Enums
{
    public enum HistoryView
    {
        None,

        // Collection
        CollectionCash,
        CollectionDebitCard,
        CollectionCreditCard,
        CollectionTNG,
        CollectionOnline,
        CollectionQRPay,


        // Work
        WorkOrder,
        WorkItem,
        WorkCustomer,
        WorkStaff,

        // Outstanding
        OutstandingTotal,
        OutstandingCollection,

        // Signup
        SignupCredit,
        SignupVoucher,
        SignupPoint,

        // Redeem
        RedeemCredit,
        RedeemVoucher,
        RedeemPoint
    }
}
