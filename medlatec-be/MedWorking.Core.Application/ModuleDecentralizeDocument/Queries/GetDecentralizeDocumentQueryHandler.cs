using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleDecentralizeDocument.Queries;

public class GetDecentralizeDocumentQueryHandler : IRequestHandler<GetAllListDecentralizeDocQuery, IPagedList<ViewDecentralizeDocument>>
                                             , IRequestHandler<GetDecentralizeDocumentByIdQuery, DecentralizeDocumentDetailModel>
                                             , IRequestHandler<GetUserByOfficeIdQuery, List<UserDetailByOfficeIdModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetDecentralizeDocumentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IPagedList<ViewDecentralizeDocument>> Handle(GetAllListDecentralizeDocQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewDecentralizeDocument, bool>> expCommon = p => (string.IsNullOrEmpty(request.FullTextSearch)
                                                                          || (p.OfficeName!.ToLower().Contains(request.FullTextSearch.ToLower())));
        var data = await _unitOfWork.GetRepository<ViewDecentralizeDocument>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
        return data;
    }

    public async Task<DecentralizeDocumentDetailModel> Handle(GetDecentralizeDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<DecentralizeDocUser, bool>> expCommon = p => p.DecentralizeDocId == request.DecentralizeDocId;
        var data = await _unitOfWork.GetRepository<DecentralizeDocUser>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        DecentralizeDocumentDetailModel resultDatas = new();
        if (data != null)
        {
            var result = _mapper.Map<DecentralizeDocumentDetailModel>(data);
            var obj = await _unitOfWork.GetRepository<DecentralizeDocument>().GetByWhere(x => x.Id == result.DecentralizeDocId).FirstOrDefaultAsync(cancellationToken);
            var user = await _unitOfWork.GetRepository<Account>().GetByWhere(x => x.EmployeeId == result.EmployeeId).FirstOrDefaultAsync(cancellationToken);
            if (user != null)
            {
                result.EmployeePosition = _unitOfWork.GetRepository<Position>().GetByWhere(x => x.Id == user.Position).FirstOrDefault()!.PositionName;
                result.EmployeeName = user.FullName;
            }
            var office = await _unitOfWork.GetRepository<Office>().GetByWhere(x => x.Id == obj!.OfficeId).FirstOrDefaultAsync(cancellationToken);
            result.Officename = office!.OfficeName;
            result.ListUsers = await GetUsers(result.DecentralizeDocId);
            result.DecentralizeDocState = obj!.DecentralizeDocState;
            result.Description = obj.Description;
            result.OfficeId = obj.OfficeId;
            resultDatas = result;
        }
        return resultDatas!;
    }

    public async Task<List<UserDetailByOfficeIdModel>> Handle(GetUserByOfficeIdQuery request, CancellationToken cancellationToken)
    {
        List<UserDetailByOfficeIdModel> lstDataUser = new();
        var office = await _unitOfWork.GetRepository<Office>().GetByWhere(x => x.Id == request.OfficeId).FirstOrDefaultAsync(cancellationToken);
        var positions = await _unitOfWork.GetRepository<Position>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
        if (office != null)
        {
            UserDetailByOfficeIdModel model = new();
            model.Id = office.Id;
            model.OfficeName = office.OfficeName!;
            var accounts = await _unitOfWork.GetRepository<Account>().GetByWhere(x => x.Office == office.Id).ToListAsync(cancellationToken);
            if (accounts.Count > 0)
            {
                model.ListAccounts = _mapper.Map<List<UserDetail>>(accounts);
                foreach (var itemAccount in model.ListAccounts)
                {
                    itemAccount.PositionName = positions.FirstOrDefault(x => x.Id == itemAccount.Position)!.PositionName;
                }
            }
            lstDataUser.Add(model);
        }
        return lstDataUser;
    }
    private async Task<List<DecentralizeDocUserModel>> GetUsers(Guid DecentralizeDocId)
    {
        List<DecentralizeDocUserModel> lstDataUser = new();
        if (DecentralizeDocId != Guid.Empty)
        {
            var modelUserId = await _unitOfWork.GetRepository<DecentralizeDocUser>().GetByWhere(x => x.DecentralizeDocId == DecentralizeDocId).ToListAsync();
            var dataUsers = await _unitOfWork.GetRepository<Account>().GetByWhere(predicate: null!).ToListAsync();
            var lstPosition = await _unitOfWork.GetRepository<Position>().GetByWhere(predicate: null!).ToListAsync();

            foreach (var item in modelUserId)
            {
                var dataUser = dataUsers.FirstOrDefault(x => x.EmployeeId == item.EmployeeId);
                if (dataUser != null)
                {
                    var result = _mapper.Map<DecentralizeDocUserModel>(dataUser);
                    var dataPosition = lstPosition.Where(x => x.Id == dataUser.Position).FirstOrDefault();
                    result.PositionName = dataPosition!.PositionName!;
                    result.DecentralizeDocumentLevel = item.DecentralizeDocumentLevel;
                    result.DecentralizeDocumentNote = item.DecentralizeDocumentNote;
                    lstDataUser.Add(result);
                }
            }
        }
        return lstDataUser;
    }
}