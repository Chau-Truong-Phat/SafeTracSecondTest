namespace MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;

public class ConfigColumnModel
{
    public Guid Id { get; set; }
    public int ViewType { get; set; }
    public string? InfoJson { get; set; }
    public DateTime? CreateDate { get; set; }
    public string? CreateUser { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<DisPlayColumn> ListColumns { get; set; } = null!;
}
public class DisPlayColumn
{
    public string ColumnName { get; set; } = null!;
    public bool IsChecked   { get; set; }
}
