using MediatR;
using MedWorking.Core.Application.ModulUserRole.Commands.ActionCommands;
using MedWorking.Core.Application.ModulUserRole.Queries;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedWorkingAPI.Controllers
{
    [Route("api/user-role")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator? _mediator;
        private readonly ILogger<UserRoleController> _logger;
        public UserRoleController(ILogger<UserRoleController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _mediator = serviceProvider.GetService<IMediator>();
        }

        [HttpPost("get-user-role-by-paging")]
        public async Task<IActionResult> GetPagedListUserRoleAsync([FromBody] GetUserRoleListQuery request)
        {
            _logger.LogInformation("Call " + nameof(GetPagedListUserRoleAsync) + " API");
            var result = await _mediator!.Send(request);
            if (result == null)
            {
                throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
            }
            return Ok(result);
        }

        [HttpGet("get-all-office")]
        public async Task<IActionResult> GetAllOfficeAsync()
        {
            _logger.LogInformation("Call " + nameof(GetAllOfficeAsync) + " API");
            GetAllOfficeQuery request = new();
            var result = await _mediator!.Send(request);
            if (result == null)
            {
                throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
            }
            return Ok(result);
        }

        [HttpGet("get-all-position")]
        public async Task<IActionResult> GetAllpositionAsync()
        {
            _logger.LogInformation("Call " + nameof(GetAllpositionAsync) + " API");
            GetAllPositionQuery request = new();
            var result = await _mediator!.Send(request);
            if (result == null)
            {
                throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
            }
            return Ok(result);
        }

        [HttpGet("get-detail-account/{employeeId}")]
        public async Task<IActionResult> GetdetailAccountAsync(string employeeId)
        {
            _logger.LogInformation("Call " + nameof(GetdetailAccountAsync) + " API");
            GetEmployeeIdQuery request = new();
            request.EmployeeId = employeeId;
            var result = await _mediator!.Send(request);
            if (result == null)
            {
                throw new NotFoundException(ErrorMessage.Error_AccountNotFoundException);
            }
            return Ok(result);
        }
        [HttpGet("get-detail-user-role/{userRoleId}")]
        public async Task<IActionResult> GetdetailUserRoleAsync(Guid userRoleId)
        {
            _logger.LogInformation("Call " + nameof(GetdetailUserRoleAsync) + " API");
            GetUserRoleDetailQuery request = new();
            request.UserRoleId = userRoleId;
            var result = await _mediator!.Send(request);
            if (result == null)
            {
                throw new NotFoundException(ErrorMessage.Error_DataNotFoundException);
            }
            return Ok(result);
        }
        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserRoleAsync([FromBody] AddUserRoleRequestCommand request)
        {
            _logger.LogInformation("Call " + nameof(AddUserRoleAsync) + " API");
            var userName = User!.Identity!.Name;
            request.CreateUser = userName;
            request.CreateDate = DateTime.UtcNow;
            request.UpdateDate = DateTime.UtcNow;
            var result = await _mediator!.Send(request);
            if (!result.isSuccess)
            {
                throw new BadRequestException(result.Message!);
            }
            return Ok(result);
        }

        [HttpPut("edit-user-role")]
        public async Task<IActionResult> EditUserRoleAsync([FromBody] EditUserRoleRequestCommand request)
        {
            _logger.LogInformation("Call " + nameof(EditUserRoleAsync) + " API");
            var userName = User!.Identity!.Name;
            request.CreateUser = userName;
            request.UpdateUser = userName;
            var result = await _mediator!.Send(request);
            if (!result.isSuccess)
            {
                throw new BadRequestException(result.Message!);
            }
            return Ok(result);
        }
        [HttpDelete("delete-user-role/{id}")]
        public async Task<IActionResult> DeleteUserRoleAsync(Guid id)
        {
            _logger.LogInformation("Call " + nameof(DeleteUserRoleAsync) + " API");
            DeleteUserRoleRequestCommand request = new();
            request.UserId = id;
            var result = await _mediator!.Send(request);
            if (!result.isSuccess)
            {
                throw new BadRequestException(result.Message!);
            }
            return Ok(result);
        }
    }
}
