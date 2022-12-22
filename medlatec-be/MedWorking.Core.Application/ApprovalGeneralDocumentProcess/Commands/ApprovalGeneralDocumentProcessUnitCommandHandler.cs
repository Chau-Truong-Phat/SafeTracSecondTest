using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands.ActionCommand;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Commands;

public class ApprovalGeneralDocumentProcessUnitCommandHandler
    : IRequestHandler<AddApprovalGeneralDocumentProcessUnitcommand, ApprovalGeneralDocumentProcessUnitCommandRespone>
    , IRequestHandler<EditApprovalGeneralDocumentProcessUnit, ApprovalGeneralDocumentProcessUnitCommandRespone>
    , IRequestHandler<DeleteApprovalGeneralDocumentProcessUnit, ApprovalGeneralDocumentProcessUnitCommandRespone>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public ApprovalGeneralDocumentProcessUnitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }
    public async Task<ApprovalGeneralDocumentProcessUnitCommandRespone> Handle(AddApprovalGeneralDocumentProcessUnitcommand request, CancellationToken cancellationToken)
    {
        var validator = new ApprovalGeneralDocumentProcessUnitCommandValidator(EnumActionName.ADD, _unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<ApprovalGeneralDocumentProcessUnit>(request);
                data.Id = Guid.NewGuid();
                data.ApplicableUnit = request.OfficeId;
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;

                await InsertAndUpdatePatternDocumentByGroupDocument(request.ListPatternDocument!, data.Id, request.GroupDocumentId);

                await InsertAndUpdateTextBrowsingStepUnit(request.ListTextBrowsingStep!, data.Id);

                await _unitOfWork.GetRepository<ApprovalGeneralDocumentProcessUnit>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<ApprovalGeneralDocumentProcessUnitModel>(data);
                result.ListTextBrowsingStep = request.ListTextBrowsingStep;
                result.ListPatternDocument = request.ListPatternDocument;
                await transaction.CommitAsync(cancellationToken);
                return new ApprovalGeneralDocumentProcessUnitCommandRespone { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }
    }
    public async Task<ApprovalGeneralDocumentProcessUnitCommandRespone> Handle(EditApprovalGeneralDocumentProcessUnit request, CancellationToken cancellationToken)
    {
        var validator = new ApprovalGeneralDocumentProcessUnitCommandValidator(EnumActionName.EDIT, _unitOfWork);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }
        var data = await _unitOfWork.GetRepository<ApprovalGeneralDocumentProcessUnit>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data == null)
        {
            return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = ErrorMessage.Error };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var objConfigBrowsingStep = _mapper.Map<ApprovalGeneralDocumentProcessUnit>(request);
                objConfigBrowsingStep.ApplicableUnit = data.ApplicableUnit;
                objConfigBrowsingStep.CreateDate = data.CreateDate;
                objConfigBrowsingStep.CreateUser = data.CreateUser;

                if (data.TimeApplication < DateTime.UtcNow)
                {
                    objConfigBrowsingStep.GroupDocumentId = data.GroupDocumentId;
                    objConfigBrowsingStep.TimeApplication = data.TimeApplication;
                    objConfigBrowsingStep.Description = request.Description;
                    objConfigBrowsingStep.Active = request.Active;
                    objConfigBrowsingStep.UpdateUser = request.UpdateUser;
                    objConfigBrowsingStep.UpdateDate = request.UpdateDate;
                }
                   
                await InsertAndUpdateTextBrowsingStepUnit(request.ListTextBrowsingStep!, data.Id);

                if (data.TimeApplication > DateTime.UtcNow)
                {
                    await InsertAndUpdatePatternDocumentByGroupDocument(request.ListPatternDocument!, data.Id,request.GroupDocumentId);
                }

                _unitOfWork.GetRepository<ApprovalGeneralDocumentProcessUnit>().Update(objConfigBrowsingStep);
                await _unitOfWork.SaveChangesAsync();

                var result = _mapper.Map<ApprovalGeneralDocumentProcessUnitModel>(objConfigBrowsingStep);
                result.ListTextBrowsingStep = request.ListTextBrowsingStep!;
                result.ListPatternDocument = request.ListPatternDocument!;

                await transaction.CommitAsync(cancellationToken);
                return new ApprovalGeneralDocumentProcessUnitCommandRespone { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = ErrorMessage.ErrorEdit };
            }
        }

    }
    public async Task<ApprovalGeneralDocumentProcessUnitCommandRespone> Handle(DeleteApprovalGeneralDocumentProcessUnit request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new();
        var data = await _unitOfWork.GetRepository<ApprovalGeneralDocumentProcessUnit>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id && x.Active == false);
        if (data == null)
        {
            var dataObj = await _unitOfWork.GetRepository<ApprovalGeneralDocumentProcessUnit>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id && x.Active == true);
            if (dataObj != null)
            {
                return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = ErrorMessage.Error_DeleteProcessUnitActive };
            }
            return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = ErrorMessage.Error };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                await RemoveTextBrowsingSteps(data.Id);
                await RemovePatternDocument(data.Id);

                _unitOfWork.GetRepository<ApprovalGeneralDocumentProcessUnit>().Delete(data);
                await _unitOfWork.SaveChangesAsync();

                await transaction.CommitAsync(cancellationToken);
                return new ApprovalGeneralDocumentProcessUnitCommandRespone { isSuccess = true, Message = ErrorMessage.Delete_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ApprovalGeneralDocumentProcessUnitCommandRespone(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
            }
        }
    }
    private async Task InsertAndUpdateTextBrowsingStepUnit(List<TextBrowsingStepsUnit> lstSteps, Guid approvalGeneralUnitId)
    {
        await RemoveTextBrowsingSteps(approvalGeneralUnitId);

        var listObj = new List<TextBrowsingStepsUnit>();
        foreach (var step in lstSteps)
        {
            TextBrowsingStepsUnit model = new();
            model.Id = Guid.NewGuid();
            model.Stt = step.Stt;
            model.ConfigureBrowsingStepId = step.ConfigureBrowsingStepId;
            model.ApprovalGeneralDocumentProcessUnitId = approvalGeneralUnitId;
            listObj.Add(model);
        }
        await _unitOfWork.GetRepository<TextBrowsingStepsUnit>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task InsertAndUpdatePatternDocumentByGroupDocument(List<PatternDocumentDetailByGroupDocument> lstPatternDocument, Guid approvalGeneralUnitId, Guid? groupDocumentId)
    {
        await RemovePatternDocument(approvalGeneralUnitId);
        var listObj = new List<PatternDocumentDetailByGroupDocument>();
        foreach (var patternDoc in lstPatternDocument)
        {
            PatternDocumentDetailByGroupDocument model = new();
            model.Id = Guid.NewGuid();
            model.GroupDocumentId = groupDocumentId;
            model.PatternDocumentId = patternDoc.PatternDocumentId;
            model.ApprovalGeneralDocumentProcessUnitId = approvalGeneralUnitId;
            listObj.Add(model);
        }
        await _unitOfWork.GetRepository<PatternDocumentDetailByGroupDocument>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task RemoveTextBrowsingSteps(Guid browingStepId)
    {
        _unitOfWork.GetRepository<TextBrowsingStepsUnit>().DeleteByWhere(x => x.ApprovalGeneralDocumentProcessUnitId == browingStepId);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task RemovePatternDocument(Guid patternDocId)
    {
        _unitOfWork.GetRepository<PatternDocumentDetailByGroupDocument>().DeleteByWhere(x => x.ApprovalGeneralDocumentProcessUnitId == patternDocId);
        await _unitOfWork.SaveChangesAsync();
    }
}

