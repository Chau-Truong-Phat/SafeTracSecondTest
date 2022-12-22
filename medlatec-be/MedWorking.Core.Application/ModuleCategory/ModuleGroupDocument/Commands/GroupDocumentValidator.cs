using FluentValidation;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleGroupDocument.Commands;

public class GroupDocumentValidator : AbstractValidator<GroupDocumentCommand>
{
    public GroupDocumentValidator()
    {
    }
    public GroupDocumentValidator(string typeValidate, IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.GroupDocCode).NotEmpty().WithMessage(ErrorMessage.GroupDocCode_Invalid);
        RuleFor(x => x.GroupDocCode).Length(1, 10).WithMessage(ErrorMessage.GroupDocCode_Lenght);
        RuleFor(x => x.GroupDocName).NotEmpty().WithMessage(ErrorMessage.GroupDocName_Invalid);
        RuleFor(x => x).Must(x => !IsDuplicateAdd(x,unitOfWork)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.IsDuplicate);
        RuleFor(x => x).Must(x => !IsDuplicateEdit(x,unitOfWork)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.IsDuplicate);      
    }
    private static bool IsDuplicateAdd(GroupDocumentCommand x, IUnitOfWork unitOfWork)
    {
        var item = unitOfWork!.GetRepository<GroupDocument>().GetFirstOrDefault(predicate: b => b.GroupDocCode == x.GroupDocCode);
        if (item == null)
        {
            return false; // Mã nhóm không tồn tại trong DB 
        }
        else
        {
            return true; // Có tồn tại mã nhóm (GroupDocCode) trong DB
        }
        
    }
    private static bool IsDuplicateEdit(GroupDocumentCommand x, IUnitOfWork unitOfWork)
    {
        var item = unitOfWork!.GetRepository<GroupDocument>().GetFirstOrDefault(predicate: b => b.GroupDocCode == x.GroupDocCode && b.GroupDocId == x.GroupDocId);
        if(item != null)
        {
            return false; // Mã nhóm không tồn tại trong DB 
        }   
        else
        {
            var data = unitOfWork!.GetRepository<GroupDocument>().GetFirstOrDefault(predicate: b => b.GroupDocCode == x.GroupDocCode && b.GroupDocId != x.GroupDocId);
            if (data != null)
            {
                return true;// Có tồn tại mã nhóm (GroupDocCode) trong DB
            }
            else
                return false;
        }
    }
}
