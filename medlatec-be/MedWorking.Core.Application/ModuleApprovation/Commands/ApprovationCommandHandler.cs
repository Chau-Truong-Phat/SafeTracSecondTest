using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleApprovation.Commands.ActionCommands;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleApprovation.Commands
{
    public class ApprovationCommandHandler : IRequestHandler<ApproveApprovationCommand, ApprovationCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MedWorkingContext _context;

        public ApprovationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = medWorkingContext;
        }

        public async Task<ApprovationCommandResponse> Handle(ApproveApprovationCommand request, CancellationToken cancellationToken)
        {
            var validator = new ApprovationCommandValidator(EnumActionName.EDIT, _unitOfWork);
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new ApprovationCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Expression<Func<ApprovalStaffLevel, bool>> expCommon = _ => _.Id.Equals(request.ApprovalStaffLevelId);
                    var entity = _unitOfWork.GetRepository<ApprovalStaffLevel>().GetFirstOrDefault(predicate: expCommon);

                    entity.IsApproved = true;
                    var listApprovedStaff = await _unitOfWork.GetRepository<ApprovalStaffLevel>()
                        .GetByWhere(_ => _.ApprovalOfficeLevelId.Equals(entity.ApprovalOfficeLevelId))
                        .ToListAsync(cancellationToken);

                    var approvedOffice = await _unitOfWork.GetRepository<ApprovalOfficeLevel>()
                        .GetByWhere(_ => _.Id.Equals(entity.ApprovalOfficeLevelId))
                        .FirstOrDefaultAsync(cancellationToken);

                    approvedOffice.Status = true;

                    var listApprovedOffice = await _unitOfWork.GetRepository<ApprovalOfficeLevel>()
                        .GetByWhere(_ => _.ApprovalStepLevelId.Equals(approvedOffice.ApprovalStepLevelId))
                        .ToListAsync(cancellationToken);

                    var countApprovedOffice = listApprovedOffice.Where(_ => _.Status == true).Count();

                    if(countApprovedOffice == listApprovedOffice.Count())
                    {
                        var approvedStep = await _unitOfWork.GetRepository<ApprovalStepLevel>()
                            .GetByWhere(_ => _.Id.Equals(approvedOffice.ApprovalStepLevelId))
                            .FirstOrDefaultAsync(cancellationToken);

                        approvedStep.Status = true;
                    }

                    foreach (var approvedStaff in listApprovedStaff)
                    {
                        if(approvedStaff.Id != entity.Id)
                        {
                            _unitOfWork.GetRepository<ApprovalStaffLevel>().Delete(approvedStaff);
                        }
                    }

                    await transaction.CommitAsync(cancellationToken);
                    //return new ApprovationCommandResponse { isSuccess = true, Result = "", Message = ErrorMessage.Add_Success };
                    return new ApprovationCommandResponse { isSuccess = true, Message = ErrorMessage.Add_Success };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new ApprovationCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
                }
            }
            throw new NotImplementedException();
        }

        public async Task<ApprovationCommandResponse> Handle(ApproveInternalApprovationCommand request, CancellationToken cancellationToken)
        {
            var validator = new ApprovationCommandValidator(EnumActionName.EDIT, _unitOfWork);
            ValidationResult validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new ApprovationCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Expression<Func<ApprovalStaffLevel, bool>> expCommon = _ => _.Id.Equals(request.ApprovalStaffLevelId);
                    var entity = _unitOfWork.GetRepository<ApprovalStaffLevel>().GetFirstOrDefault(predicate: expCommon);

                    var approvedOffice = await _unitOfWork.GetRepository<ApprovalOfficeLevel>()
                        .GetByWhere(_ => _.Id.Equals(entity.ApprovalOfficeLevelId))
                        .FirstOrDefaultAsync(cancellationToken);

                    if (approvedOffice.ApprovationRequestType == EnumApprovationRequestType.ApprovationWithLevel)
                    {

                    }

                    entity.IsApproved = true;
                    var listApprovedStaff = await _unitOfWork.GetRepository<ApprovalStaffLevel>()
                        .GetByWhere(_ => _.ApprovalOfficeLevelId.Equals(entity.ApprovalOfficeLevelId))
                        .ToListAsync(cancellationToken);

                    var approvedOffice = await _unitOfWork.GetRepository<ApprovalOfficeLevel>()
                        .GetByWhere(_ => _.Id.Equals(entity.ApprovalOfficeLevelId))
                        .FirstOrDefaultAsync(cancellationToken);

                    approvedOffice.Status = true;

                    var listApprovedOffice = await _unitOfWork.GetRepository<ApprovalOfficeLevel>()
                        .GetByWhere(_ => _.ApprovalStepLevelId.Equals(approvedOffice.ApprovalStepLevelId))
                        .ToListAsync(cancellationToken);

                    var countApprovedOffice = listApprovedOffice.Where(_ => _.Status == true).Count();

                    if (countApprovedOffice == listApprovedOffice.Count())
                    {
                        var approvedStep = await _unitOfWork.GetRepository<ApprovalStepLevel>()
                            .GetByWhere(_ => _.Id.Equals(approvedOffice.ApprovalStepLevelId))
                            .FirstOrDefaultAsync(cancellationToken);

                        approvedStep.Status = true;
                    }

                    foreach (var approvedStaff in listApprovedStaff)
                    {
                        if (approvedStaff.Id != entity.Id)
                        {
                            _unitOfWork.GetRepository<ApprovalStaffLevel>().Delete(approvedStaff);
                        }
                    }

                    await transaction.CommitAsync(cancellationToken);
                    //return new ApprovationCommandResponse { isSuccess = true, Result = "", Message = ErrorMessage.Add_Success };
                    return new ApprovationCommandResponse { isSuccess = true, Message = ErrorMessage.Add_Success };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new ApprovationCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
                }
            }
            throw new NotImplementedException();
        }
    }
}
