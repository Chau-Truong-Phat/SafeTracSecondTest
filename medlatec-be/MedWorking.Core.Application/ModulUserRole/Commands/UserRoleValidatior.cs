using FluentValidation;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulUserRole.Commands;

public class UserRoleValidator : AbstractValidator<UserRoleCommand>
{
    public UserRoleValidator() { }
    public UserRoleValidator(IUnitOfWork _unitOfWork, string employeeName)
    {
        var existEmployeeMessage = "Nhân viên " + employeeName  +" đã được phân vai trò!";
        RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage(ErrorMessage.EmployeeCode_Invalid);
        RuleFor(x => x).Must(x => !IsDuplicate(x,_unitOfWork)).WithMessage(existEmployeeMessage);
        RuleFor(x => x).Must(x => CheckAccountExist(x,_unitOfWork)).WithMessage(ErrorMessage.Error_AccountNotExist);
    }
    private static bool IsDuplicate(UserRoleCommand x, IUnitOfWork _unitOfWork)
    {
        var itemRole = _unitOfWork.GetRepository<UserRole>().GetFirstOrDefault(predicate: b => b.EmployeeCode == x.EmployeeCode);
        if (itemRole == null)
        {

            return false; // Nhân viên [họ và tên nhân viên] chưa đươc phân vai trò 
        }
        else
        {
            if(x.EmployeeCode == itemRole.EmployeeCode && x.UserId == itemRole.UserId)
            {
                return false;
            }
            return true; // Nhân viên [họ và tên nhân viên] đã đươc phân vai trò
        }
    }
    private static bool CheckAccountExist(UserRoleCommand x, IUnitOfWork _unitOfWork)
    {
        var dataAccount = _unitOfWork.GetRepository<Account>().GetFirstOrDefault(predicate: v => v.EmployeeId == x.EmployeeCode);
        if(dataAccount != null)
        {
            return true;
        }    
        return false;
    }
}
