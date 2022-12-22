using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.Static;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleRole.Queries;

public class GetRoleAllListQueryHandler : IRequestHandler<GetRoleAllListQuery, List<RoleModel>>
                                        , IRequestHandler<GetRoleListQuery, IPagedList<Role>>
                                        , IRequestHandler<GetRoleByIdQuery, ViewDetailRole>
                                        ,IRequestHandler<GetGenRoleCodeQuery,string>
                                        ,IRequestHandler<GetAllListRoleQuery, List<ListDecentralizeModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetRoleAllListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<RoleModel>> Handle(GetRoleAllListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Role, bool>> expCommon = p => p.RoleName != null;
        var data = await _unitOfWork.GetRepository<Role>().GetByWhere(predicate: expCommon).OrderByDescending(p => p.CreateDate).ToListAsync(cancellationToken);
        var result = _mapper.Map<List<RoleModel>>(data);

        return result;
    }

    public async Task<IPagedList<Role>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Role, bool>> expCommon = p =>
               (string.IsNullOrEmpty(request.FullTextSearch)
               || (p.RoleName!.ToLower().Contains(request.FullTextSearch.ToLower()) || p.RoleCode!.ToLower().Contains(request.FullTextSearch.ToLower())));

        var data = await _unitOfWork.GetRepository<Role>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
        return data;
    }

    public async Task<ViewDetailRole> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Role, bool>> expCommon = p => p.Id == request.RoleId;
        var data = await _unitOfWork.GetRepository<Role>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        var result = _mapper.Map<ViewDetailRole>(data);
        var roleModels =await _unitOfWork.GetRepository<RoleDecentralize>().GetByWhere(x => x.RoleId == data!.Id).ToListAsync(cancellationToken);
        var models = await _unitOfWork.GetRepository<Decentralize>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
        List<Decentralize> decentralizes = new List<Decentralize>();
        foreach (var itemRole in roleModels)
        {
            var model = models.FirstOrDefault(x => x.Id == itemRole.DecentralizeId);
            decentralizes.Add(model!);

        }
        result.ListRole = decentralizes.OrderBy(x=>x.Id).ToList();
        return result;
    }
    public async Task<string> Handle(GetGenRoleCodeQuery request, CancellationToken cancellationToken)
    {
        List<string> arrGroupDocCode = await _unitOfWork.GetRepository<Role>().GetByWhere(predicate: p => p.RoleCode!.StartsWith(EnumActionName.RoleCode.ToString())).Select(v => v.RoleCode!).ToListAsync(cancellationToken);
        string strGen = AutoGenCode.AutoGenerateCode(arrGroupDocCode, EnumActionName.RoleCode);
        return strGen;
    }
    public async Task<List<ListDecentralizeModel>> Handle(GetAllListRoleQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Decentralize, bool>> expCommon = p => p.Parent == 0;
        var data = await _unitOfWork.GetRepository<Decentralize>().GetByWhere(predicate: expCommon).OrderBy(x => x.Id).ToListAsync(cancellationToken);
        var dataChilds = await _unitOfWork.GetRepository<Decentralize>().GetByWhere(predicate: null!).OrderBy(x => x.Id).ToListAsync(cancellationToken);
        var modelDepartments = new List<ListDecentralizeModel>();

        foreach (var itemDecentralize in data)
        {
            var model = new ListDecentralizeModel();
            model.Id = itemDecentralize.Id;
            model.Name = itemDecentralize.Name!;
            model.Parent = itemDecentralize.Parent!.Value;
            var dataChild = dataChilds.Where(x => x.Parent == itemDecentralize.Id).OrderBy(x=>x.Id).ToList();
            if (dataChild.Count > 0)
            {
                model.ListFunctionName = dataChild;
            }
            modelDepartments.Add(model);
        }
        return modelDepartments;
    }
}
