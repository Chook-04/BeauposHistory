using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using BeauposHistory.Shared.Models;

namespace BeauposHistory.Shared.Components.Modals.Work
{
    public partial class ItemDetailsModal
    {
        [Parameter] public bool Visible { get; set; }
        [Parameter] public EventCallback OnClose { get; set; }

        [Parameter] public ServiceItemDM ItemModel { get; set; } = new();


        //private bool _closing;
        //private bool _disposed;

        //private async Task Close()
        //{
        //    if (_disposed || _closing) return;

        //    _closing = true;
        //    await OnClose.InvokeAsync();
        //}

        //public void Dispose()
        //{
        //    _disposed = true;
        //}
    }
}
