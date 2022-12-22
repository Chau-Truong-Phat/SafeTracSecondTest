using FluentValidation;
using MedWorking.Core.Common.Constants;

namespace MedWorking.Core.Application.ModuleDocument.Commands;

public class AdvisoryStaffCommandvalidator : AbstractValidator<AdvisoryStaffCommand>
{
    public AdvisoryStaffCommandvalidator()
    {
        RuleFor(x => x).Must(x => CheckListUser(x)).WithMessage(ErrorMessage.Error_NotEmptyAdvisorUnitStep);
    }

    private static bool CheckListUser(AdvisoryStaffCommand x)
    {
        if (x.ListAdvisoryUser!.Count > 0)
        {
            return true;
        }
        return false;
    }
}
