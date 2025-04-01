using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Shared.QuickGrids.Rows
{
    public sealed partial class QuickGridRowClick 
    {
        private IJSObjectReference? _module;

        [Parameter]
        [EditorRequired]
        public required string TableHtmlId { get; set; }

        [Parameter]
        [EditorRequired]
        public required string IdFieldClass { get; set; }

        private DotNetObjectReference<QuickGridRowClick>? Instance { get; set; }

        [Parameter]
        [EditorRequired]
        public required EventCallback<string> OnRowClicked { get; set; }

        [Inject]
        private IJSRuntime? JsRuntime { get; set; }

        [JSInvokable]
        public async Task HandleRowClickedAsync(string rowId)
        {
            await OnRowClicked.InvokeAsync(rowId);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await AssureJavascriptModuleAsync();
                await _module!.InvokeVoidAsync("initialize", Instance, TableHtmlId, IdFieldClass);
            }
        }

        private async Task AssureJavascriptModuleAsync()
        {
            _module ??= await JsRuntime!.InvokeAsync<IJSObjectReference>("import", "/Shared/QuickGrids/Rows/QuickGridRowClick.razor.js");
            Instance ??= DotNetObjectReference.Create(this);
        }
    }
}