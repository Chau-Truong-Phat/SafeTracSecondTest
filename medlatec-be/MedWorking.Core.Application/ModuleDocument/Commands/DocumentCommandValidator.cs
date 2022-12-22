using FluentValidation;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;

namespace MedWorking.Core.Application.ModuleDocument.Commands;

public class DocumentCommandValidator : AbstractValidator<DocumentCommand>
{
    public DocumentCommandValidator()
    {
        
    }

    public DocumentCommandValidator(string typeValidate, IUnitOfWork _unitOfWork)
    {
        RuleFor(x => x).Must(x=> CheckIsDraftDoc(x)).When(x=>typeValidate == EnumActionName.BROWSE).WithMessage("bản văn nháp mới được trình duyệt");
    }
    
    private static bool CheckIsDraftDoc(DocumentCommand x)
    {
        if(x.Status != EnumStatusDoc.DraftDoc)
        {
            return true;
        }
        return false;
    }
}