using System;
using System.Collections.Generic;
using System.Text;
using BeauposHistory.Shared.Enums;

namespace BeauposHistory.Shared.Pages
{
    public partial class History
    {

        protected string Label_FilterDateRange => "01/02/2026 - 09/02/2026";

        protected string Label_DetailHeader => "Collection History - TNG";
        protected string Label_RecordFoundCount => "Found 89 records in this period";

        protected string Label_RecordID => "#HIST-2026-00015";
        protected string Label_RecordAmount => "RM 209.00";
        protected string Label_RecordTimestamp => "05:41 PM, 06 Feb 2026";

        protected override void OnInitialized()
        {
            CurrentView = HistoryView.CollectionTNG;
            activeRowId = "col-tng";
        }
        //protected string Label_FilterDateRange => "06/02/2026";

        protected string Label_CollectionAmount => "209.00";


        protected string Label_TNGAmount => "209.00";


        protected string Label_OrderCount => "1";
        protected string Label_ItemCount => "1";
        protected string Label_CustomerCount => "1";
        protected string Label_StaffCount => "1";


        protected string Label_Outstanding => "Outstanding";
        protected string Label_TotalOutstanding => "Total Outstanding";
        protected string Label_TotalOutstandingAmount => "0.00";
        protected string Label_OutstandingCollection => "Outstanding Collection";
        protected string Label_OutstandingCollectionAmount => "0.00";


        protected string Label_Voucher => "0.00";

        protected string Label_Point => "0 pts";


        protected string Label_CreditAmount => "0.00";








        private HistoryView CurrentView = HistoryView.None;

        void SelectView(HistoryView view)
        {
            CurrentView = view;
        }

        private string activeRowId = ""; 

        private void SelectRow(string rowId)
        {
            activeRowId = rowId;

            CurrentView = rowId switch
            {
                // -------- Collection --------
                "col-cash" => HistoryView.CollectionCash,
                "col-dc" => HistoryView.CollectionDebitCard,
                "col-cc" => HistoryView.CollectionCreditCard,
                "col-tng" => HistoryView.CollectionTNG,
                "col-online" => HistoryView.CollectionOnline,
                "col-qr" => HistoryView.CollectionQRPay,

                // -------- Work --------
                "work-order" => HistoryView.WorkOrder,
                "work-item" => HistoryView.WorkItem,
                "work-customer" => HistoryView.WorkCustomer,
                "work-staff" => HistoryView.WorkStaff,

                // -------- Outstanding --------
                "out-total" => HistoryView.OutstandingTotal,
                "out-coll" => HistoryView.OutstandingCollection,

                // -------- Signup --------
                "signup-credit" => HistoryView.SignupCredit,
                "signup-voucher" => HistoryView.SignupVoucher,
                "signup-point" => HistoryView.SignupPoint,

                // -------- Redeem --------
                "redeem-credit" => HistoryView.RedeemCredit,
                "redeem-voucher" => HistoryView.RedeemVoucher,
                "redeem-point" => HistoryView.RedeemPoint,

                _ => HistoryView.None
            };
        }



        private bool isSidebarExpanded = true;

        private void ToggleSidebar()
        {
            isSidebarExpanded = !isSidebarExpanded;
        }




        /// <summary>
        /// 过后变成一个class
        /// </summary>
        public class PaymentMethod
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? LabelAmount { get; set; } // 对应你前端显示的金额变量名
            public bool IsVisible { get; set; } = true; // 预留 Logic：是否显示
        }

        // 这样写：加一个 = new() 或 = new List<PaymentMethod>()
        public List<PaymentMethod> CollectionMethods { get; set; } = new()
        {
                new PaymentMethod { Id = "col-tng", Name = "TNG", LabelAmount = "0.00" },
                new PaymentMethod { Id = "col-cc", Name = "Credit Card", LabelAmount = "0.00" },
                new PaymentMethod { Id = "col-cash", Name = "Cash", LabelAmount = "0.00" },
                new PaymentMethod { Id = "col-online", Name = "Online", LabelAmount = "0.00" },
                new PaymentMethod { Id = "col-dc", Name = "Debit Card", LabelAmount = "0.00" },
                new PaymentMethod { Id = "col-qr", Name = "QR Pay", LabelAmount = "0.00" }
        };




        bool ShowReceiptModal;

        void OpenReceipt() => ShowReceiptModal = true;
        void CloseReceipt() => ShowReceiptModal = false;




    }
}
