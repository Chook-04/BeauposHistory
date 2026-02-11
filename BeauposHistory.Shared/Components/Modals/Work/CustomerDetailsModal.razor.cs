using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using BeauposHistory.Shared.Models;

namespace BeauposHistory.Shared.Components.Modals.Work
{
    public partial class CustomerDetailsModal
    {
        [Parameter] public bool Visible { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        [Parameter] public MemberDetailsDM MemberModel { get; set; } = new MemberDetailsDM();

    }
}
