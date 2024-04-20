using BlazingTrails.Client.State;
using BlazingTrails.Shared.Features.ManageTrails.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazingTrails.Client.Features.ManageTrails.Shared;

public class FormStateTracker : ComponentBase
{
    [Inject] public AppState? AppState { get; set; }

    [CascadingParameter] private EditContext? CascadedEditContext { get; set; }

    protected override void OnInitialized()
    {
        if (CascadedEditContext is null)
        {
            throw new InvalidOperationException(
                $"{nameof(FormStateTracker)} requires a cascading parameter of type {nameof(EditContext)}");
        }

        if (AppState is null)
        {
            throw new InvalidOperationException(
                $"{nameof(FormStateTracker)} requires a cascading parameter of type {nameof(State.AppState)}");
        }

        CascadedEditContext.OnFieldChanged += CascadedEditContext_OnFieldChanged;
    }

    private void CascadedEditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        var trail = (TrailDto) e.FieldIdentifier.Model;
        // Only new trails will have an ID of 0
        if (trail.Id == 0)
        {
            AppState!.NewTrailState.SaveTrail(trail);
        }
    }
}
