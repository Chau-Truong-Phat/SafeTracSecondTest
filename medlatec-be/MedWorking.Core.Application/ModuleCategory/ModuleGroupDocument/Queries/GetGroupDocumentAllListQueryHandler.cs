using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Queries;
using MedWorking.Core.Application.ModuleGroupDocument.Models;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.Static;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleGroupDocument.Queries;

public class GetGroupDocumentAllListQueryHandler : IRequestHandler<GetGroupDocumentAllListQuery, List<GroupDocumentModel>>
    , IRequestHandler<GetGroupDocumentListQuery, IPagedList<GroupDocument>>
    , IRequestHandler<GetGroupDocumentByIdQuery, GroupDocumentModel>
    , IRequestHandler<GetConfigColumnByTypeQuery, ConfigColumnModel>
    , IRequestHandler<GetGenGroupDocumentQuery, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetGroupDocumentAllListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GroupDocumentModel>> Handle(GetGroupDocumentAllListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<GroupDocument, bool>> expCommon = p => p.DocActive == true;
        var data = await _unitOfWork.GetRepository<GroupDocument>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<GroupDocumentModel>>(data);

        return result;
    }

    public async Task<IPagedList<GroupDocument>> Handle(GetGroupDocumentListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<GroupDocument, bool>> expCommon = p =>
        (string.IsNullOrEmpty(request.FullTextSearch)
        || (p.GroupDocCode!.ToLower().Contains(request.FullTextSearch.ToLower()) || p.GroupDocName!.ToLower().Contains(request.FullTextSearch.ToLower())))
        && ((request.ListDocType!.First() == 0 ) || request.ListDocType!.Contains(p.DocType!.Value));

        var data = await _unitOfWork.GetRepository<GroupDocument>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify,false,cancellationToken);
        return data;
    }

    public async Task<GroupDocumentModel> Handle(GetGroupDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<GroupDocument, bool>> expCommon = p => p.GroupDocId.ToString() == request.GroupDocId;
        var data = await _unitOfWork.GetRepository<GroupDocument>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        var result = _mapper.Map<GroupDocumentModel>(data);

        return result;
    }
    public async Task<ConfigColumnModel> Handle(GetConfigColumnByTypeQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ConfigColumn, bool>> expCommon = p => p.ViewType == request.ViewType;
        var data = await _unitOfWork.GetRepository<ConfigColumn>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        ConfigColumnModel model = new();
        if(data != null)
        {
            var result = _mapper.Map<ConfigColumnModel>(data);
            result.ListColumns = JsonConvert.DeserializeObject<List<DisPlayColumn>>(data!.InfoJson!)!;
            model = result;
        }
        return model;
    }
    public async Task<string> Handle(GetGenGroupDocumentQuery request, CancellationToken cancellationToken)
    {
        List<string> arrGroupDocCode = await _unitOfWork.GetRepository<GroupDocument>().GetByWhere(predicate: p => p.GroupDocCode!.StartsWith(EnumActionName.GroupCode.ToString())).Select(v => v.GroupDocCode!).ToListAsync(cancellationToken);
        string strGen = AutoGenCode.AutoGenerateCode(arrGroupDocCode, EnumActionName.GroupCode);
        return strGen;
    }
}
