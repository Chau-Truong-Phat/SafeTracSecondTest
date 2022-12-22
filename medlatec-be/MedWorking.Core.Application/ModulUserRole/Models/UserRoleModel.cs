namespace MedWorking.Core.Application.ModulUserRole.Models;

public class UserRoleModel
{
    public Guid UserId { get; set; }
    public string EmployeeCode { get; set; } 
    public string EmployeeName { get; set; }
    public long? OfficeId { get; set; }
    public long? PositionId { get; set; }
    public string? Description { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string? UpdateUser { get; set; }
    public List<Guid>? ListRole { get; set; }
}
