using FluentValidation;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Commands;

public class ConfigBrowsingStepCommandValidator : AbstractValidator<ConfigBrowsingStepCommand>
{
    public ConfigBrowsingStepCommandValidator() { }
    public ConfigBrowsingStepCommandValidator(string typeValidate)
    {
        RuleFor(x => x.StepName).NotEmpty().WithMessage("Tên bước không được để trống");
        RuleFor(x => x.ConfigType).NotEmpty().WithMessage("Phạm vi áp dụng không được để trống");
        RuleFor(x => x).Must(x => LevelIsBiggerThanZero(x)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_LevelMustBiggerThanZero);
        RuleFor(x => x).Must(x => LevelIsBiggerThanZero(x)).When(x => typeValidate == EnumActionName.EDIT).WithMessage(ErrorMessage.Error_LevelMustBiggerThanZero);
        RuleFor(x => x).Must(x => !IsTrueLevel(x)).When(x => typeValidate == EnumActionName.ADD).WithMessage(ErrorMessage.Error_LevelInvalid);
    }

    private static bool LevelIsBiggerThanZero(ConfigBrowsingStepCommand x)
    {
        if(x.ConfigType == EnumConfigType.Secretary || x.ConfigType == EnumConfigType.Internal || x.ConfigType == EnumConfigType.Director)
            return true;
        else
        {
            foreach (var item in x.ListOffice!)
            {
                if (item.ApprovalLevel < 1 && x.IsUnit == false)
                {
                    return false;
                }
            }
            return true;
        }
    }

    private static bool IsTrueLevel(ConfigBrowsingStepCommand x)
    {
        if (x.ConfigType == EnumConfigType.Secretary || x.ConfigType == EnumConfigType.Internal || x.ConfigType == EnumConfigType.Director)
            return false;
        else
        {
            var lstDecdocUser = x.ListOffice!.OrderBy(x => x.ApprovalLevel).ToList();

            for (int i = 0; i < lstDecdocUser.Count - 1; i++)
            {
                if ((lstDecdocUser[0].ApprovalLevel != 1 && lstDecdocUser[i].ApprovalLevel != lstDecdocUser[i + 1].ApprovalLevel)
                    || (lstDecdocUser[i + 1].ApprovalLevel - lstDecdocUser[i].ApprovalLevel > 1))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
