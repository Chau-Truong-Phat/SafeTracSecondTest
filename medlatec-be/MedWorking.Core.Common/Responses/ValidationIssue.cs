namespace MedWorking.Core.Common.Responses;

public class ValidationIssue
{
    public string? PropertyName { get; set; }
    public List<string>? PropertyFailures { get; set; }
}
