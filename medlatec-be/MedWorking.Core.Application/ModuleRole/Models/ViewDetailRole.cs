using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Application.ModuleRole.Models;

public class ViewDetailRole
{
    public Guid Id { get; set; }
    public string RoleCode { get; set; } 

    public string RoleName { get; set; }

    public string Description { get; set; } 

    public List<Decentralize>? ListRole { get; set; }
    public List<ListDecentralizeModel>? ListDecentralize { get; set; } 


}

