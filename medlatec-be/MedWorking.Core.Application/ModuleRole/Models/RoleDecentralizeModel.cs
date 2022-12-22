namespace MedWorking.Core.Application.ModuleRole.Models;

public class RoleDecentralizeModel
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public long ParentId { get; set; }
    public long ChildId { get; set; }
    public string Name { get; set; }

}
