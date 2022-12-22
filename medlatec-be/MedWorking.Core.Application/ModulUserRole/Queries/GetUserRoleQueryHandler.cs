using AutoMapper;
using MediatR;
using MedWorking.Core.Application.ModulUserRole.Models;
using MedWorking.Core.Application.ModulUserRole.Queries;
using MedWorking.Core.Common.UnitOfWork;
using MedWorking.Core.Common.UnitOfWork.Collections;
using MedWorking.Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedWorking.Core.Application.ModulRole.Queries;

public class GetUserRoleQueryHandler : IRequestHandler<GetEmployeeIdQuery, ViewInfoAccountDetail>
                                       ,IRequestHandler<GetAllPositionQuery, List<Position>>
                                       ,IRequestHandler<GetAllOfficeQuery, List<DepartmentModel>>
                                       , IRequestHandler<GetUserRoleListQuery, IPagedList<ViewGetDetailUserRole>>
                                       , IRequestHandler<GetUserRoleDetailQuery, ViewGetDetailUserRole>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserRoleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ViewInfoAccountDetail> Handle(GetEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewInfoAccountDetail, bool>> expCommon = p => p.EmployeeId== request.EmployeeId;
        var data = await _unitOfWork.GetRepository<ViewInfoAccountDetail>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        return data!;
    }
    public async Task<ViewGetDetailUserRole> Handle(GetUserRoleDetailQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewGetDetailUserRole, bool>> expCommon = p => p.UserId == request.UserRoleId;
        var data = await _unitOfWork.GetRepository<ViewGetDetailUserRole>().GetByWhere(predicate: expCommon).FirstOrDefaultAsync(cancellationToken);
        return data!;
    }
    public async Task<IPagedList<ViewGetDetailUserRole>> Handle(GetUserRoleListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<ViewGetDetailUserRole, bool>> expCommon = p =>
        (string.IsNullOrEmpty(request.FullTextSearch)
        || (p.EmployeeCode!.ToLower().Contains(request.FullTextSearch.ToLower()) || p.EmployeeName!.ToLower().Contains(request.FullTextSearch.ToLower())))
        && ((request.ListDepartment!.First() == 0) || request.ListDepartment!.Contains(p.Officeid!.Value))
        && ((request.ListPosition!.First() == 0) || request.ListPosition!.Contains(p.Positionid!.Value))
        && ((request.ListRole!.First() == "") || request.ListRole!.Contains(p.Roleid!));

        var data = await _unitOfWork.GetRepository<ViewGetDetailUserRole>().GetPagedListAsync(predicate: expCommon, orderBy: p => p.OrderByDescending(p => p.CreateDate), null!, request.PageNumber, request.PageSize, request.RowModify, false, cancellationToken);
        return data;
        
    }

    public async Task<List<Position>> Handle(GetAllPositionQuery request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWork.GetRepository<Position>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
        return data;
    }
    public async Task<List<DepartmentModel>> Handle(GetAllOfficeQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Office, bool>> expCommon = p => p.Parent == 0;
        var data = await _unitOfWork.GetRepository<Office>().GetByWhere(predicate: expCommon).ToListAsync(cancellationToken);
        var dataChilds = await _unitOfWork.GetRepository<Office>().GetByWhere(predicate: null!).ToListAsync(cancellationToken);
        var modelDepartments = new List<DepartmentModel>();
        foreach(var itemOffice in data)
        {
            var model = new DepartmentModel();
            model.Id = itemOffice.Id;
            model.OfficeName = itemOffice.OfficeName!;
            var dataChild = dataChilds.Where(x => x.Parent == itemOffice.Id).ToList();
            var result = _mapper.Map<List<DepartmentModel>>(dataChild);
            if (dataChild.Count >0)
            {
                model.ListDepartmentChild = GetOffice(result, dataChilds);
            }
            modelDepartments.Add(model);
        } 
        return modelDepartments;
    }

    public List<DepartmentChildModel> GetOffice(List<DepartmentModel> listDepartment,List<Office> lstOffice)
    {
        var modelChildDepartments = new List<DepartmentChildModel>();
        foreach (var item in listDepartment)
        {
            var model = new DepartmentChildModel();
            model.Id = item.Id;
            model.OfficeName = item.OfficeName;
            var dataChild = lstOffice.Where(x => x.Parent == item.Id).ToList();
            if (dataChild.Count > 0)
            {
                var result = _mapper.Map<List<DepartmentModel>>(dataChild);
                model.ListDepartmentChildin = GetOffice(result, lstOffice);

            }
            modelChildDepartments.Add(model);
        }
        return modelChildDepartments;
    }
}
