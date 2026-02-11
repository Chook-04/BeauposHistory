using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeauposHistory.Shared.Components.History
{
    public partial class HistoryDetails
    {
        // 页面状态控制
        private bool IsNumpadVisible = false;
        private bool IsEditingPayment = false;
        private bool IsSelectingCashier = false;
        private bool IsBackdateSaleEditing = false;
        private bool showConfirmButtons = false;

        private ServiceItemDM SelectedService = null;
        private PaymentMethodDM SelectedPaymentForNumpad = null;
        private string NumpadBuffer = "";
        //private DateTime DisplayMonth = DateTime.Today;
        //private DateTime? SelectedDate = DateTime.Today;

        // 核心数据模型
        private ReceiptDM Receipt = new ReceiptDM();
        private MemberDM Member = new MemberDM { MemberId = "MEM-8899" };
        private StaffDM Staff = new StaffDM { Name = "Alex Wong", PhoneNumber = "+6012-3456789" };

        private List<string> AvailableMethods = new List<string> { "Cash", "TNG", "Credit Card", "GrabPay" };
        private List<StaffDM> FilteredStaffs = new List<StaffDM>
    {
        new StaffDM { Name = "Bella", PhoneNumber = "011-222333", PhotoUrl = "" },
        new StaffDM { Name = "Chris", PhoneNumber = "011-444555", PhotoUrl = "" }
    };

        protected override void OnInitialized()
        {
            Receipt = new ReceiptDM
            {
                ReceiptNo = "11111111",
                TransactionDate = DateTime.Now.AddHours(-2),
                CashierName = "Alex Wong",
                Remarks = "Customer requested extra care.",
                IsVoided = false,
                Items = new List<ServiceItemDM>
            {
                new ServiceItemDM {
                    Category = "Hair Service",
                    ItemName = "Premium Hair Cut",
                    Price = 150.00m,
                    Quantity = 1,
                    ServedByStaffs = new List<ServedStaffDM> {
                        new ServedStaffDM { Name = "Alex Wong", EffortPercentage = 100, HofPercentage = 10, Value = 150.00m }
                    }
                },
                new ServiceItemDM {
                    Category = "Treatment",
                    ItemName = "Scalp Therapy",
                    Price = 59.00m,
                    Quantity = 1,
                    OutstandingAmount = 59.00m
                }
            },
                Payments = new List<PaymentMethodDM>
            {
                new PaymentMethodDM { MethodName = "TNG", Amount = 150.00m }
            }
            };
        }

        [Parameter] public EventCallback OnClose { get; set; }

        private void EnterEditPayment() => IsEditingPayment = true;
        private void EnterSelectCashier() => IsSelectingCashier = true;
        private void OpenNumpad(PaymentMethodDM pay) { SelectedPaymentForNumpad = pay; NumpadBuffer = pay.Amount.ToString(); IsNumpadVisible = true; }
        private void SelectCashier(StaffDM s) { Receipt.CashierName = s?.Name ?? "No Staff"; IsSelectingCashier = false; }
        private void OnConfirmVoid() { Receipt.IsVoided = true; Receipt.VoidedDate = DateTime.Now; showConfirmButtons = false; }
        private void SaveNumpadValue() { IsNumpadVisible = false; }
        private decimal PaymentDifference => Receipt.TotalSales - Receipt.Payments.Sum(x => x.Amount);
        private IEnumerable<DateTime?> GetCalendarDays()
        {
            var firstDayOfMonth = new DateTime(DisplayMonth.Year, DisplayMonth.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(DisplayMonth.Year, DisplayMonth.Month);

            int offset = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            for (int i = 0; i < offset; i++) yield return null; 
            for (int i = 1; i <= daysInMonth; i++) yield return new DateTime(DisplayMonth.Year, DisplayMonth.Month, i);
        }

        private DateTime DisplayMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        private DateTime? SelectedDate = DateTime.Today;
        private void EnterEditBackdateSale() => IsBackdateSaleEditing = true;
        private void SelectDate(DateTime date)
        {
            SelectedDate = date;
            IsBackdateSaleEditing = false;
        }

        public class ReceiptDM
        {
            public string ReceiptNo { get; set; }
            public DateTime TransactionDate { get; set; }
            public DateTime VoidedDate { get; set; }
            public string CashierName { get; set; }
            public string Remarks { get; set; }
            public bool IsVoided { get; set; }
            public List<ServiceItemDM> Items { get; set; } = new();
            public List<PaymentMethodDM> Payments { get; set; } = new();
            public decimal TotalSales => Items.Sum(i => i.Price * i.Quantity);
            public decimal OutstandingBalance => Items.Sum(i => i.OutstandingAmount);
        }
        public class ServiceItemDM
        {
            public string Category { get; set; }
            public string ItemName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal OutstandingAmount { get; set; }
            public List<ServedStaffDM> ServedByStaffs { get; set; } = new();
        }
        public class PaymentMethodDM { public string MethodName { get; set; } public decimal Amount { get; set; } }
        public class StaffDM { public string Name { get; set; } public string PhoneNumber { get; set; } public string PhotoUrl { get; set; } }
        public class ServedStaffDM { public string Name { get; set; } public decimal EffortPercentage { get; set; } public decimal HofPercentage { get; set; } public decimal Value { get; set; } public string PhotoUrl { get; set; } public string PhoneNumber { get; set; } }
        public class MemberDM { public string MemberId { get; set; } }
    }
}
