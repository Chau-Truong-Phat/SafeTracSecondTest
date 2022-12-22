using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModulePatternDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModulePatternDocument.Commands;

public class PatternDocumentCommandHandler
    : IRequestHandler<AddPatternDocumentRequestCommand, PatternDocumentCommandResponse>
    , IRequestHandler<EditPatternDocumentRequestCommand, PatternDocumentCommandResponse>
    , IRequestHandler<DeletePatternDocumentRequestCommand, PatternDocumentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public PatternDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }

    public async Task<PatternDocumentCommandResponse> Handle(AddPatternDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        PatternDocumentValidator validator = new PatternDocumentValidator(EnumActionName.ADD);
        validator._unitOfWork = _unitOfWork;
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new PatternDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<PatternDocument>(request);
                data.PatternDocId = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;
                if (request.ListOfficeIds!.Count > 0)
                {
                    await InsertListAdvisoryUnit(request.ListOfficeIds, data.PatternDocId);
                }

                await _unitOfWork.GetRepository<PatternDocument>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<PatternDocumentModel>(data);
                result.ListOfficeIds = request.ListOfficeIds;

                await transaction.CommitAsync(cancellationToken);

                return new PatternDocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new PatternDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }
    }

    public async Task<PatternDocumentCommandResponse> Handle(EditPatternDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        PatternDocumentValidator validator = new PatternDocumentValidator(EnumActionName.EDIT);
        validator._unitOfWork = _unitOfWork;
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new PatternDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = await _unitOfWork.GetRepository<PatternDocument>().GetFirstOrDefaultAsync(predicate: x => x.PatternDocId == request.PatternDocId);
        if (data != null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dataObj = _mapper.Map<PatternDocument>(request);
                    dataObj.CreateDate = data.CreateDate;
                    dataObj.CreateUser = data.CreateUser;

                    await InsertListAdvisoryUnit(request.ListOfficeIds!, request.PatternDocId);

                    _unitOfWork.GetRepository<PatternDocument>().Update(dataObj);
                    await _unitOfWork.SaveChangesAsync();

                    var result = _mapper.Map<PatternDocumentModel>(dataObj);
                    result.ListOfficeIds = request.ListOfficeIds;
                    await transaction.CommitAsync(cancellationToken);
                    return new PatternDocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new PatternDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorEdit };
                }
            }
        }
        else
        {
            return new PatternDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }
    }

    public async Task<PatternDocumentCommandResponse> Handle(DeletePatternDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = new ValidationResult();
        var data = await _unitOfWork.GetRepository<PatternDocument>().GetFirstOrDefaultAsync(predicate: x => x.PatternDocId == request.PatternDocId);

        if (data != null && data.DocumentValue == null)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await RemovePatternDocOffice(data.PatternDocId);

                    _unitOfWork.GetRepository<PatternDocument>().Delete(data);
                    await _unitOfWork.SaveChangesAsync();

                    await transaction.CommitAsync(cancellationToken);
                    return new PatternDocumentCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new PatternDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
                }
            }
        }
        else
        {
            return new PatternDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_DeleteDocumentActive };
        }
    }
    private async Task InsertListAdvisoryUnit(List<long> lstOfficeId, Guid patternDocId)
    {
        await RemovePatternDocOffice(patternDocId);
        var listObj = new List<PatternDocOffice>();
        foreach (var item in lstOfficeId)
        {
            var model = new PatternDocOffice();
            model.Id = Guid.NewGuid();
            model.PatternDocId = patternDocId;
            model.OfficeId = item;
            listObj.Add(model);
        }

        await _unitOfWork.GetRepository<PatternDocOffice>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();
    }
    private async Task RemovePatternDocOffice(Guid patternDocId)
    {
        _unitOfWork.GetRepository<PatternDocOffice>().DeleteByWhere(x => x.PatternDocId == patternDocId);
        await _unitOfWork.SaveChangesAsync();
    }
}
