using FluentValidation;
using MedWorking.Core.Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleApprovation.Commands;
public class ApprovationCommandValidator : AbstractValidator<ApprovationCommand>
{
    public ApprovationCommandValidator()
    {

    }

    public ApprovationCommandValidator(string typeValidate, IUnitOfWork _unitOfWork)
    {

    }
}