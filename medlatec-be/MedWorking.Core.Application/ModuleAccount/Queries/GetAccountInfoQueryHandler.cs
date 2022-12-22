using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModuleAccount.Models;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModuleAccount.Queries;

public class GetAccountInfoQueryHandler : IRequestHandler<GetAccountInfoCommand, ViewAccountDetailModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAccountInfoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ViewAccountDetailModel> Handle(GetAccountInfoCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewAccountDetail, bool>> expCommon = p => p.UserName == request.UserName;
        var data = await _unitOfWork.GetRepository<ViewAccountDetail>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        ViewAccountDetailModel viewAccountDetailModel = new ViewAccountDetailModel();
        if (data != null)
        {
            var resultDetail = _mapper.Map<ViewAccountDetailModel>(data);
            var modelUserRole = await _unitOfWork.GetRepository<UserRole>().GetByWhere(x => x.EmployeeCode == data.EmployeeId!.ToString()).FirstOrDefaultAsync(cancellationToken);
            
            resultDetail.ListRole = await GetUserRole(modelUserRole!);
            viewAccountDetailModel = resultDetail;
        }    
        return viewAccountDetailModel;
    }
    
    private async Task<List<ViewDetailRole>> GetUserRole(UserRole model) 
    {
        List<ViewDetailRole> lstRole = new();
        if (model != null)
        {
            var modelUserIdRoles = await _unitOfWork.GetRepository<UserIdRole>().GetByWhere(x => x.UserId == model.UserId).ToListAsync();
            var dataRoles = await _unitOfWork.GetRepository<Role>().GetByWhere(predicate: null!).ToListAsync();
            foreach (var itemRole in modelUserIdRoles)
            {
                var dataRole = dataRoles.FirstOrDefault(x => x.Id == itemRole.RoleId);
                if (dataRole != null)
                {
                    lstRole.Add(await GetViewDetailRole(dataRole));
                }
            }
        }
        return lstRole;
    }
    private async Task<ViewDetailRole> GetViewDetailRole(Role dataRole)
    {
        var result = _mapper.Map<ViewDetailRole>(dataRole);
        var models = await _unitOfWork.GetRepository<RoleDecentralize>().GetByWhere(x => x.RoleId == dataRole!.Id).Select(x => x.DecentralizeId).ToListAsync();
        var dataParent = await _unitOfWork.GetRepository<Decentralize>().GetByWhere(v => models.Contains(v.Id) && v.Parent == 0).ToListAsync();
        var modelDecentralizes = await _unitOfWork.GetRepository<Decentralize>().GetByWhere(predicate: null!).ToListAsync();
        List<ListDecentralizeModel> decentralizes = new();
        foreach (var itemParent in dataParent)
        {
            var modelDecentralize = modelDecentralizes.FirstOrDefault(x => x.Id == itemParent.Id);
            if(modelDecentralize != null)
            {
                var decentralizeModel = _mapper.Map<ListDecentralizeModel>(modelDecentralize);
                var modelChildRole = modelDecentralizes.Where(x => x.Parent == modelDecentralize!.Id).OrderBy(x => x.Id).ToList();
                decentralizeModel.ListFunctionName = modelChildRole;
                decentralizes.Add(decentralizeModel);
            }
        }
        result.ListDecentralize = decentralizes;
        if (dataParent.Count <= 0)
        {
            var dataChild = await _unitOfWork.GetRepository<Decentralize>().GetByWhere(v => models.Contains(v.Id) && v.Parent != 0).Select(x => x.Parent).Distinct().ToListAsync();
            List<ListDecentralizeModel> decentralizeschild = new();
            foreach (var itemChild in dataChild)
            {
                var modelParent = modelDecentralizes.FirstOrDefault(x => x.Id == itemChild);
                if(modelParent != null)
                {
                    var decentralizeModel = _mapper.Map<ListDecentralizeModel>(modelParent);
                    var modelChilds = modelDecentralizes.Where(x => models.Contains(x.Id) && x.Parent == itemChild).OrderBy(x => x.Id).ToList();
                    decentralizeModel.ListFunctionName = modelChilds;
                    decentralizeschild.Add(decentralizeModel);
                }
                
            }
            result.ListDecentralize = decentralizeschild;
        }
        return result;
    }
}
