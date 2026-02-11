using BeauposHistory.Shared.Enums;
using BeauposHistory.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeauposHistory.Shared.Components.History
{
    public partial class WorkHistory : ComponentBase
    {

        [Parameter] public HistoryView View { get; set; }

        private string activeTab = "All";
        private string[] itemTabs = new[] { "All", "Service", "Product", "Package" };




        private IEnumerable<ReceiptDM> FilteredReceipts
        {
            get
            {
                if (RawReceipts == null) return Enumerable.Empty<ReceiptDM>();

                if (activeTab == "All") return RawReceipts;

                return RawReceipts.Where(r => r.Items != null &&
                                             r.Items.Any(i => i.Category == activeTab));
            }
        }

        private List<ReceiptDM> RawReceipts = new();


        private MemberDetailsDM ChookMember = new MemberDetailsDM
        {
            MemberId = "123",
            Name = "Chook",
            PhoneNumber = "012-3456789",
            Sex = "Male",
            DateRegistered = DateTime.Now
        };

        protected override void OnInitialized()
        {


            RawReceipts = new List<ReceiptDM>
            {
                new ReceiptDM
                {
                    ReceiptNo = "13",
                    TransactionDate = new DateTime(2026, 02, 1),
                    Status = ReceiptDM.EInvoiceStatus.Cancelled,
                    Member = ChookMember,
                    Items = new List<ServiceItemDM>
                    {
                        new ServiceItemDM {Category="Service", ItemName = "Treatment", Price = 13.13m, Quantity = 1 }
                    },
                    Payments = new List<PaymentMethodDM>
                    {
                        new PaymentMethodDM { MethodName="QR Pay", Amount=13.13m }
                    }
                },
                new ReceiptDM
                {
                    ReceiptNo = "14",
                    TransactionDate = new DateTime(2026, 02, 1),
                    Status = ReceiptDM.EInvoiceStatus.NoStatus,
                    Member = ChookMember,
                    Items = new List<ServiceItemDM>
                    {
                        new ServiceItemDM {Category="Package", ItemName = "Package 10 free 100", Price = 14.14m, Quantity = 1 },
                        new ServiceItemDM {Category="Service", ItemName = "Treatment", Price = 14.14m, Quantity = 1 }
                    },
                    Payments = new List<PaymentMethodDM>
                    {
                        new PaymentMethodDM { MethodName="Cash", Amount=14.14m }
                    }
                },
                new ReceiptDM
                {
                    ReceiptNo = "15",
                    TransactionDate = new DateTime(2026, 01, 1),
                    Status = ReceiptDM.EInvoiceStatus.Cancelled,
                    Member = ChookMember,
                    Items = new List<ServiceItemDM>
                    {
                        new ServiceItemDM { Category="Product",ItemName = "Treatment", Price = 15.15m, Quantity = 1 }
                    },
                    Payments = new List<PaymentMethodDM>
                    {
                        new PaymentMethodDM { MethodName="TNG", Amount=15.15m }
                    }
                },
                new ReceiptDM
                {
                    ReceiptNo = "15",
                    TransactionDate = new DateTime(2026, 01, 1),
                    Status = ReceiptDM.EInvoiceStatus.Cancelled,
                    Member = ChookMember,
                    Items = new List<ServiceItemDM>
                    {
                        new ServiceItemDM { Category="Product",ItemName = "Treatment", Price = 15.15m, Quantity = 1 }
                    },
                    Payments = new List<PaymentMethodDM>
                    {
                        new PaymentMethodDM { MethodName="TNG", Amount=15.15m }
                    }
                },
                new ReceiptDM
                {
                    ReceiptNo = "15",
                    TransactionDate = new DateTime(2026, 01, 1),
                    Status = ReceiptDM.EInvoiceStatus.Cancelled,
                    Member = ChookMember,
                    Items = new List<ServiceItemDM>
                    {
                        new ServiceItemDM { Category="Product",ItemName = "Treatment", Price = 15.15m, Quantity = 1 }
                    },
                    Payments = new List<PaymentMethodDM>
                    {
                        new PaymentMethodDM { MethodName="TNG", Amount=15.15m }
                    }
                },
                new ReceiptDM
                {
                    ReceiptNo = "15",
                    TransactionDate = new DateTime(2026, 01, 1),
                    Status = ReceiptDM.EInvoiceStatus.Cancelled,
                    Member = ChookMember,
                    Items = new List<ServiceItemDM>
                    {
                        new ServiceItemDM { Category="Product",ItemName = "Treatment", Price = 15.15m, Quantity = 1 }
                    },
                    Payments = new List<PaymentMethodDM>
                    {
                        new PaymentMethodDM { MethodName="TNG", Amount=15.15m }
                    }

                },
            };
        }

        private string GetViewTitle() => View switch
        {
            HistoryView.WorkOrder => "Orders",
            HistoryView.WorkItem => "Items",
            HistoryView.WorkCustomer => "Customers",
            HistoryView.WorkStaff => "Staff",
            _ => "Work"
        };

        private string GetIcon() => View switch
        {
            HistoryView.WorkOrder => "📄",
            HistoryView.WorkItem => "📦",
            HistoryView.WorkCustomer => "👥",
            HistoryView.WorkStaff => "👔",
            _ => "•"
        };

        private int MockCount => View switch
        {
            HistoryView.WorkOrder => 15,
            HistoryView.WorkCustomer => 5,
            _ => 1
        };




        private bool isStaffModalVisible = false;

        private string selectedStaffName = "Effie";

        private async Task OpenStaffDetail(string name)
        {
            selectedStaffName = name;
            isStaffModalVisible = true;
            await InvokeAsync(StateHasChanged);
        }
        private void CloseStaffDetail()
        {
            isStaffModalVisible = false;
        }



        private bool isItemDetailModalVisible = false;

        private void CloseItemDetail()
        {
            isItemDetailModalVisible = false;
        }


        public ServiceItemDM SelectedItem { get; set; } = new();
        private void OpenItemDetail(ServiceItemDM item)
        {
            if (isItemDetailModalVisible) return;

            SelectedItem = item;
            isItemDetailModalVisible = true;
        }







        private bool isCustomerDetailModalVisible = false;

        public MemberDetailsDM SelectedMember = new MemberDetailsDM
        {
            MemberId = "MEM-888-999",
            Name = "Chook",
            PhoneNumber = "012-345 6789",
            Sex = "Male",
            DateRegistered = new DateTime(2025, 12, 25),
            PhotoUrl = "https://i.pravatar.cc/150?u=jason",
            Credit = 888.50m,
            Point = 5200
        };

        private void CloseCustomerModal()
        {
            isCustomerDetailModalVisible = false;
        }

        private void OpenCustomerModal()
        {
            if (isCustomerDetailModalVisible) return;

            isCustomerDetailModalVisible = true;
        }


        bool ShowReceiptModal;

        void OpenReceipt() => ShowReceiptModal = true;
        void CloseReceipt() => ShowReceiptModal = false;




    }
}
