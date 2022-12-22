using FluentValidation;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleRole.Commands;

public class RoleValidator : AbstractValidator<RoleCommand>
{
    public RoleValidator()
    {
    }

    public RoleValidator(IUnitOfWork unitOfWork,string typeValidate)
    {
        RuleFor(x => x.RoleCode).NotEmpty().WithMessage(ErrorMessage.RoleCode_Invalid);
        RuleFor(x => x.RoleCode.Length).LessThanOrEqualTo(EnumActionName.Value).WithMessage(ErrorMessage.RoleCode_LengthInvalid);
        RuleFor(x => x.RoleName).NotEmpty().WithMessage(ErrorMessage.RoleName_Invalid);
        RuleFor(x => x).Must(x => !IsDuplicateCode(x,unitOfWork)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.IsDuplicate_RoleCode);
        RuleFor(x => x).Must(x => !IsDuplicateCodeEdit(x,unitOfWork)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.IsDuplicate_RoleCode);
    }
    private static bool IsDuplicateCode(RoleCommand x, IUnitOfWork unitOfWork)
    {
        var item = unitOfWork!.GetRepository<Role>().GetFirstOrDefault(predicate: b => b.RoleCode == x.RoleCode);
        if (item == null)
        {
            return false; // Mã vai trò không tồn tại trong DB 
        }
        else
        {
            return true;  // Có tồn tại mã vai trò trong DB
        }
    }

    private static bool IsDuplicateCodeEdit(RoleCommand x, IUnitOfWork unitOfWork)
    {
        var checkRoleCode = unitOfWork!.GetRepository<Role>().GetByWhere(b => b.RoleCode != null);

        var item = unitOfWork.GetRepository<Role>().GetFirstOrDefault(predicate: b => b.Id == x.Id);

        if (checkRoleCode.Any(b => b.RoleCode == x.RoleCode) && item.RoleCode != x.RoleCode)
        {
            return true; // Mã vai trò có tồn tại trong DB 
        }
        else
        {
            return false;  // Không tồn tại mã vai trò trong DB
        }
    }
}
