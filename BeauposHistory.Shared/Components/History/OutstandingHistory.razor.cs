using BeauposHistory.Shared.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeauposHistory.Shared.Components.History
{
    public partial class OutstandingHistory : ComponentBase
    {
        [Parameter] public HistoryView View { get; set; }
    }
}
