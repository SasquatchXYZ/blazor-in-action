using BlazingTrails.Shared.Features.ManageTrails.Shared;
using FluentValidation;

namespace BlazingTrails.Shared.Features.ManageTrails.EditTrail;

public class EditTrailRequestValidator : AbstractValidator<EditTrailRequest>
{
    public EditTrailRequestValidator()
    {
        RuleFor(x => x.Trail).SetValidator(new TrailValidator());
    }
}
