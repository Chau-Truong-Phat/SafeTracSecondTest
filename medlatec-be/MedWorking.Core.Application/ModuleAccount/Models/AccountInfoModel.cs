namespace MedWorking.Core.Application.ModuleAccount.Models;

public class AccountInfoModel
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } 
    public string PasswordHash { get; set; }
    public long EmployeeId { get; set; }
    public bool Auto { get; set; }
    public TimeOnly TimeLogin { get; set; }
    public bool Online { get; set; }
    public int Level { get; set; }
    public string? SignatureUrl { get; set; }
    public string? Email { get; set; }
    public bool Hc { get; set; }
    public bool Active { get; set; }
    public string Position { get; set; } 
    public string Unit { get; set; } 
    public string? AvatarUrl { get; set; }
    public string? SerialNumber { get; set; }
    public string? CreateUser { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
}

