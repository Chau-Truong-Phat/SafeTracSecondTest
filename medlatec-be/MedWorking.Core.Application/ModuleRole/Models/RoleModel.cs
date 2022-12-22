namespace MedWorking.Core.Application.ModuleRole.Models;

public class RoleModel
{
    public Guid Id { get; set; }
    public string RoleName { get; set; } 
    public string RoleCode { get; set; }

    public string? Description { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }

    public List<ListRoleModel>? ListRole { get; set; }
}
public class ListRoleModel
{
    public long Id { get; set; }
    public long Parent { get; set; }
}
