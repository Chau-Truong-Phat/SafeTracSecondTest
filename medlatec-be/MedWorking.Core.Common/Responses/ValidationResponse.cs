using FluentValidation.Results;

namespace MedWorking.Core.Common.Responses
{
    public class ValidationResponse
    {
        private string Message;
        private IEnumerable<ValidationFailure> Errors;

        public ValidationResponse(string message, IEnumerable<ValidationFailure> errors)
        {
            this.Message = message;
            this.Errors = errors;
        }
    }
}