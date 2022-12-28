using Microsoft.AspNetCore.Components;
using MudBlazor;
using Nasa.Client.Models.Apod;

namespace Nasa.Client.Pages.APOD.Dialogs
{
    public partial class ImageApodDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public GetApodDataModel GetApodData { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
    }
}
