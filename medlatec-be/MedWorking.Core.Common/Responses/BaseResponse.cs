using FluentValidation.Results;
using MedWorking.Core.Common.Responses;

namespace MedWorking.Core.Common.Response;

public class BaseResponse
{
    public BaseResponse()
    {
        isSuccess = false;
    }
    public BaseResponse(IEnumerable<ValidationFailure> failures)
    {
        isSuccess = false;

        ValidationIssues = new List<ValidationIssue>();

        var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            
            // Each PropertyName get's an array of failures associated with it:
            var PropertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            var propertyFailure = new ValidationIssue { PropertyName = propertyName, PropertyFailures = PropertyFailures.ToList() };
            ValidationIssues.Add(propertyFailure);
        }

    }
    public int Code { get; set; }
    public bool isSuccess { get; set; } = false;
    public string? Message { get; set; }
    public IList<ValidationIssue>? ValidationIssues { get; set; }
}


