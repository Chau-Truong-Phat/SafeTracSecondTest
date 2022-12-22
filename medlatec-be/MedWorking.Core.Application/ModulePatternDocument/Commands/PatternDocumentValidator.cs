using FluentValidation;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulePatternDocument.Commands;

public class PatternDocumentValidator : AbstractValidator<PatternDocumentCommand>
{
    public IUnitOfWork? _unitOfWork { get; set; }
    public PatternDocumentValidator(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public PatternDocumentValidator(string typeValidate)
    {
        RuleFor(x => x.PatternDocCode).NotEmpty().WithMessage("Nhập mã văn bản").MaximumLength(10).WithMessage("Mã văn bản không quá 10 ký tự");
        RuleFor(x => x).Must(x => !IsDuplicate(x)).When(x => typeValidate == EnumActionName.ADD || typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Eror_Exist_PatternDocCode);
    }

    private bool IsDuplicate(PatternDocumentCommand x)
    {
        var item = _unitOfWork!.GetRepository<PatternDocument>().GetFirstOrDefault(predicate: b => b.PatternDocCode == x.PatternDocCode);
        if (item == null)
        {

            return false;
        }
        else
        {
            if(x.PatternDocId == item.PatternDocId && x.PatternDocCode == item.PatternDocCode)
            {
                return false;
            }
            else
            {
                var model = _unitOfWork.GetRepository<PatternDocument>().GetFirstOrDefault(predicate: v => v.PatternDocCode == x.PatternDocCode && v.PatternDocId != x.PatternDocId);
                if(model == null)
                {
                    return false;
                }
                return true;
            }    
        }
    }
}