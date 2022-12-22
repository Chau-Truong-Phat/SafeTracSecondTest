using FluentValidation;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands;

public class ApprovalGeneralDocumentProcessUnitCommandValidator : AbstractValidator<ApprovalGeneralDocumentProcessUnitCommand>
{
    public ApprovalGeneralDocumentProcessUnitCommandValidator()
    {
    }
    public ApprovalGeneralDocumentProcessUnitCommandValidator(string typeValidate,IUnitOfWork _unitOfWork)
    {

        RuleFor(x => x.OfficeId).NotEmpty().WithMessage(ErrorMessage.Error_OfficeNotEmpty);
        RuleFor(x => x.GroupDocumentId).NotEmpty().WithMessage(ErrorMessage.GroupDocId_Invalid);
        RuleFor(x => x.TimeApplication).Must(BeAValidDate).WithMessage(ErrorMessage.Error_TimeApplication);
        RuleFor(x => x).Must(x=>CheckListSteps(x)).When(x=>typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_NotEmptyAdvisorUnitStep);
        RuleFor(x => x).Must(x=>CheckListSteps(x)).When(x=>typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_NotEmptyAdvisorUnitStep);
        RuleFor(x => x).Must(x => !OnlyOneAdvisorUnit(x,_unitOfWork)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_AdvisorExist);
        RuleFor(x => x).Must(x => !OnlyOneAdvisorUnit(x,_unitOfWork)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_AdvisorExist);
    }

    private static bool OnlyOneAdvisorUnit(ApprovalGeneralDocumentProcessUnitCommand x, IUnitOfWork _unitOfWork)
    {
        var advisorUnitBrowingSteps = x.ListTextBrowsingStep!.Select(v => v.ConfigureBrowsingStepId).ToList();
        var lstconfigStep = _unitOfWork.GetRepository<ConfigureBrowsingStep>().GetByWhere(p => p.ConfigType == EnumCapDuyet.ApplyUnit && advisorUnitBrowingSteps.Contains(p.Id)).ToList();
        if (lstconfigStep.Count > 1)
        {
            return true;
        }
        return false;
    }
    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
    private static bool CheckListSteps(ApprovalGeneralDocumentProcessUnitCommand x)
    {
        if(x.ListTextBrowsingStep!.Count > 0)
        {
            return true;
        }
        return false;
    }
}
