using BeauposHistory.Shared.Enums;
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
        public class WorkItem
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Qty { get; set; }
            public string Category { get; set; }
        }

        private List<WorkItem> AllItems = new List<WorkItem>();

        private IEnumerable<WorkItem> FilteredItems
        {
            get
            {
                if (AllItems == null) return Enumerable.Empty<WorkItem>();

                return activeTab == "All"
                    ? AllItems
                    : AllItems.Where(i => i.Category == activeTab);
            }
        }

        protected override void OnInitialized()
        {
            AllItems = new List<WorkItem>
            {
                new WorkItem { Name = "Antiaging facial", Price = 209.00, Qty = 1, Category = "Service" },
                new WorkItem { Name = "Product A", Price = 50.00, Qty = 2, Category = "Product" }
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

        private void OpenItemDetail()
        {
            if (isItemDetailModalVisible) return;

            isItemDetailModalVisible = true;
        }




        private bool isCustomerDetailModalVisible = false;

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
