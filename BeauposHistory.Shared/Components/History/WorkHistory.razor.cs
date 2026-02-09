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

        string Title => View switch
        {
            HistoryView.WorkOrder => "Order History",
            HistoryView.WorkItem => "Item History",
            HistoryView.WorkCustomer => "Customer History",
            HistoryView.WorkStaff => "Staff History",
            _ => ""
        };

    }
}
