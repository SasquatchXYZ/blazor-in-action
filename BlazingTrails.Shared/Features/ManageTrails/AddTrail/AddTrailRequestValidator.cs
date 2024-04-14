using BlazingTrails.Shared.Features.ManageTrails.Shared;
using FluentValidation;

namespace BlazingTrails.Shared.Features.ManageTrails.AddTrail;

public class AddTrailRequestValidator : AbstractValidator<AddTrailRequest>
{
    public AddTrailRequestValidator()
    {
        RuleFor(x => x.Trail).SetValidator(new TrailValidator());
    }
}
