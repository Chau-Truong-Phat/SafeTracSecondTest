namespace MedWorking.Core.Application.ModulUserRole.Models;

public class DepartmentModel
{
    public long Id { get; set; }
    public string OfficeName { get; set; } 
    public List<DepartmentChildModel>? ListDepartmentChild { get; set; } 
    
}
public class DepartmentChildModel
{
    public long Id { get; set; }
    public string OfficeName { get; set; } 
    public List<DepartmentChildModel>? ListDepartmentChildin { get; set; } 
}
