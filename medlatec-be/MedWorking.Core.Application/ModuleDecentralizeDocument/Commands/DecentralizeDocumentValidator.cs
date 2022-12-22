using FluentValidation;
using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;
using MedWorking.Core.Application.ModuleRole.Commands;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using System.Security.AccessControl;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Commands;

public class DecentralizeDocumentValidator : AbstractValidator<DecentralizeDocumentCommand>
{
    public DecentralizeDocumentValidator() { }

    public DecentralizeDocumentValidator(IUnitOfWork unitOfWork, string typeValidate)
    {
        RuleFor(x => x.Description).MaximumLength(500).WithMessage(ErrorMessage.Error_DescriptionOverLength);
        RuleFor(x => x).Must(x => !IsDuplicateOfficeId(x, unitOfWork)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_DecentralizeDocumentOfficeExist);
        RuleFor(x => x).Must(x => !IsDuplicateOfficeId(x, unitOfWork)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_DecentralizeDocumentOfficeExist);
        RuleFor(x => x.OfficeId).NotEmpty().WithMessage(ErrorMessage.Error_OfficeNotEmpty);
        RuleFor(x => x).Must(x => !IsTrueLevelBiggerThanZero(x)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_LevelMustBiggerThanZero);
        RuleFor(x => x).Must(x => !IsTrueLevelBiggerThanZero(x)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_LevelMustBiggerThanZero);
        RuleFor(x => x).Must(x => !IsTrueLevel(x)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_LevelInvalid);
        RuleFor(x => x).Must(x => !IsTrueLevel(x)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_LevelInvalid);
        RuleFor(x => x).Must(x => !IsTrueLevelDiffirentFromOne(x)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_LevelMustBeOne);
        RuleFor(x => x).Must(x => !IsTrueLevelDiffirentFromOne(x)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_LevelMustBeOne);
    }

    private static bool IsDuplicateOfficeId(DecentralizeDocumentCommand x, IUnitOfWork unitOfWork)
    {
        var item = unitOfWork!.GetRepository<DecentralizeDocument>().GetFirstOrDefault(predicate: b => b.OfficeId == x.OfficeId);
        if (item == null)
        {
            return false; // Cấp duyệt chưa tồn tại
        }
        else if (item != null && item.Id == x.Id)
        {
            return false;
        }
        else
        {
            return true;  // Cấp duyệt đã tồn tại
        }
    }

    private static bool IsTrueLevelBiggerThanZero(DecentralizeDocumentCommand x)
    {
        var lstDecdocUser = x.ListDecentralizeDocUsers!.OrderBy(x => x.DecentralizeDocumentLevel).ToList();
        if (lstDecdocUser[0].DecentralizeDocumentLevel < 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private static bool IsTrueLevelDiffirentFromOne(DecentralizeDocumentCommand x)
    {
        var lstDecdocUser = x.ListDecentralizeDocUsers!.OrderBy(x => x.DecentralizeDocumentLevel).ToList();
        if (lstDecdocUser[0].DecentralizeDocumentLevel != 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private static bool IsTrueLevel(DecentralizeDocumentCommand x)
    {
        var lstDecdocUser = x.ListDecentralizeDocUsers!.OrderBy(x => x.DecentralizeDocumentLevel).ToList();

        for (int i = 0; i < lstDecdocUser.Count - 1; i++)
        {
            if ((lstDecdocUser[0].DecentralizeDocumentLevel != 1 && lstDecdocUser[i].DecentralizeDocumentLevel != lstDecdocUser[i + 1].DecentralizeDocumentLevel)
                || (lstDecdocUser[i + 1].DecentralizeDocumentLevel - lstDecdocUser[i].DecentralizeDocumentLevel > 1))
            {
                return true;
            }
        }
        return false;

    }
}