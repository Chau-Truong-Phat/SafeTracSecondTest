using FluentValidation;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Commands;

public class ApprovalGeneralDocProcessCommandValidator : AbstractValidator<ApprovalGeneralDocProcessCommand>
{
    public ApprovalGeneralDocProcessCommandValidator() { }
    public ApprovalGeneralDocProcessCommandValidator(IUnitOfWork unitOfWork, string typeValidate, string groupDoc, string patternDocName, DateTime timeApplication)
    {
        string errorMessage_DuplicateApprovalDoc =  groupDoc + patternDocName + " đã được thiết lập quy trình duyệt trước đó, có hiệu lực từ ngày "  + timeApplication + ". Vui lòng kiểm tra lại!";
        RuleFor(x => x.GroupDocumentId.ToString()).NotNull().WithMessage(ErrorMessage.GroupDocCode_Invalid);
        RuleFor(x => x.TimeApplication).NotNull().WithMessage(ErrorMessage.Error_NotEmptyTimeApplication);
        RuleFor(x => x.Active).NotNull().WithMessage(ErrorMessage.Error_NotEmptyActiveState);
        RuleFor(x => x).Must(x => !OnlyOneAdvisorUnit(x,unitOfWork)).WithMessage(ErrorMessage.Error_AdvisorExist);
        RuleFor(x => x).Must(x => CheckListSteps(x)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_NotEmptyAdvisorUnitStep);
        RuleFor(x => x).Must(x => CheckListSteps(x)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_NotEmptyAdvisorUnitStep);
        RuleFor(x => x).Must(x => !IsDuplicate(x,unitOfWork)).When(x => typeValidate == EnumActionName.ADD).WithMessage(errorMessage_DuplicateApprovalDoc);
    }

    private static bool OnlyOneAdvisorUnit(ApprovalGeneralDocProcessCommand x, IUnitOfWork unitOfWork)
    {
        var advisorSteps = x.ListTextBrowsingStepGeneral!.Select(x=>x.ConfigureBrowsingStepId).ToList();
        var configSteps = unitOfWork.GetRepository<ConfigureBrowsingStep>().GetByWhere(p => p.ConfigType == EnumConfigType.Advisory && advisorSteps.Contains(p.Id)).ToList();
        if(configSteps.Count > 1)
        {
            return true;
        }
        return false;
    }
    private static bool CheckListSteps(ApprovalGeneralDocProcessCommand x)
    {
        if (x.ListTextBrowsingStepGeneral!.Count > 0)
        {
            return true;
        }
        return false;
    }

    private static bool IsDuplicate(ApprovalGeneralDocProcessCommand x, IUnitOfWork unitOfWork)
    {
        var listPatternDoc = x.ListPatternDocumentGeneral!.Select(p => p.PatternDocumentId).ToList();
        var modelApprovalGeneralDocument = unitOfWork.GetRepository<EntityFramework.Models.ApprovalGeneralDocumentProcess>().GetByWhere(p=>p.TimeApplication == x.TimeApplication).FirstOrDefault();
        var listPatternDocDetail = unitOfWork.GetRepository<PatternDocDetailByGroupDocGeneral>().GetByWhere(p=> p.GroupDocumentId == x.GroupDocumentId &&  listPatternDoc.Contains(p.PatternDocumentId)).ToList();
        if(listPatternDocDetail.Count > 1 && modelApprovalGeneralDocument != null)
        {
            return true;
        }
        return false;
    }
}
