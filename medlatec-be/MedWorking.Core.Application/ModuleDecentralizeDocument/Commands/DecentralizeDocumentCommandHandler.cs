using AutoMapper;
using FluentValidation.Results;
using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Commands;

public class DecentralizeDocumentCommandHandler
    : IRequestHandler<AddDecentralizeDocumentRequestCommand, DecentralizeDocumentCommandResponse>
    , IRequestHandler<EditDecentralizeDocumentRequestCommand, DecentralizeDocumentCommandResponse>
    , IRequestHandler<DeleteDecentralizeDocumentRequestCommand, DecentralizeDocumentCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly MedWorkingContext _context;

    public DecentralizeDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, MedWorkingContext medWorkingContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = medWorkingContext;
    }

    public async Task<DecentralizeDocumentCommandResponse> Handle(AddDecentralizeDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new DecentralizeDocumentValidator(_unitOfWork, EnumActionName.ADD);
        ValidationResult validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var data = _mapper.Map<DecentralizeDocument>(request);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.UtcNow;
                data.UpdateDate = DateTime.UtcNow;

                var listObj = new List<DecentralizeDocUserModel>();
                if (request.ListDecentralizeDocUsers!.Count > 0)
                {
                    listObj = await InsertListDecentralizeDocUser(request.ListDecentralizeDocUsers, data.Id);
                }

                await _unitOfWork.GetRepository<DecentralizeDocument>().InsertAsync(data, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<DecentralizeDocumentModel>(data);

                result.ListDecentralizeDocUsers = listObj;

                await transaction.CommitAsync(cancellationToken);

                return new DecentralizeDocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Add_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorAdd };
            }
        }
    }

    public async Task<DecentralizeDocumentCommandResponse> Handle(EditDecentralizeDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new DecentralizeDocumentValidator(_unitOfWork, EnumActionName.EDIT);
        ValidationResult validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = await _unitOfWork.GetRepository<DecentralizeDocument>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id);
        if (data == null)
        {
            return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error };
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var obj = _mapper.Map<DecentralizeDocument>(request);
                obj.CreateDate = data.CreateDate;
                obj.CreateUser = data.CreateUser;

                var listObj = new List<DecentralizeDocUserModel>();
                if (request.ListDecentralizeDocUsers!.Count > 0)
                {
                    listObj = await InsertListDecentralizeDocUser(request.ListDecentralizeDocUsers, request.Id);
                }

                _unitOfWork.GetRepository<DecentralizeDocument>().Update(obj);
                await _unitOfWork.SaveChangesAsync();
                var result = _mapper.Map<DecentralizeDocumentModel>(obj);

                result.ListDecentralizeDocUsers = listObj;

                await transaction.CommitAsync(cancellationToken);

                return new DecentralizeDocumentCommandResponse { isSuccess = true, Result = result, Message = ErrorMessage.Edit_Success };
            }

            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.ErrorEdit };
            }
        }
    }
    public async Task<DecentralizeDocumentCommandResponse> Handle(DeleteDecentralizeDocumentRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new DecentralizeDocumentValidator(_unitOfWork, EnumActionName.DELETE);
        ValidationResult validationResult = new();
        if (!validationResult.IsValid)
        {
            return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = validationResult.Errors[0].ErrorMessage };
        }

        var data = await _unitOfWork.GetRepository<DecentralizeDocument>().GetFirstOrDefaultAsync(predicate: x => x.Id == request.Id && x.DecentralizeDocState != true);

        if (data == null)
        {
            return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Eror_DeleteDecentralizeDocActive };
        }
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var listDecentralizeDocUser = await _unitOfWork.GetRepository<DecentralizeDocUser>().GetByWhere(x => x.DecentralizeDocId == data.Id).ToListAsync(cancellationToken);
                if (listDecentralizeDocUser.Count > 0)
                {
                    _unitOfWork.GetRepository<DecentralizeDocUser>().Delete(listDecentralizeDocUser);
                    await _unitOfWork.SaveChangesAsync();
                }

                _unitOfWork.GetRepository<DecentralizeDocument>().Delete(data);
                await _unitOfWork.SaveChangesAsync();

                await transaction.CommitAsync(cancellationToken);

                return new DecentralizeDocumentCommandResponse { isSuccess = true, Message = ErrorMessage.Delete_Success };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new DecentralizeDocumentCommandResponse(validationResult.Errors) { Message = ErrorMessage.Error_Delete };
            }

        }
    }

    private async Task<List<DecentralizeDocUserModel>> InsertListDecentralizeDocUser(List<DecentralizeDocUserModel> lstDecentralizeDocUser, Guid DecentralizeDocId)
    {
        var listData = await _unitOfWork.GetRepository<DecentralizeDocUser>().GetByWhere(x => x.DecentralizeDocId == DecentralizeDocId).ToListAsync();
        if (listData.Count > 0)
        {
            _unitOfWork.GetRepository<DecentralizeDocUser>().Delete(listData);
            await _unitOfWork.SaveChangesAsync();
        }

        var listObj = new List<DecentralizeDocUser>();

        foreach (var item in lstDecentralizeDocUser)
        {
            DecentralizeDocUser model = new();
            model.Id = Guid.NewGuid();
            model.DecentralizeDocId = DecentralizeDocId;
            model.EmployeeId = item.EmployeeId;
            model.DecentralizeDocumentLevel = item.DecentralizeDocumentLevel;
            model.DecentralizeDocumentNote = item.DecentralizeDocumentNote;
            model.CreateUser = item.CreateUser;
            model.CreateDate = item.CreateDate;
            listObj.Add(model);
        }

        await _unitOfWork.GetRepository<DecentralizeDocUser>().InsertAsync(listObj);
        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<List<DecentralizeDocUserModel>>(listObj);

        return result;
    }
}
