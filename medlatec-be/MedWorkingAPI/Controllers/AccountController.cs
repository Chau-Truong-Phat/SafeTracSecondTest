using MediatR;
using MedWorking.Core.Application.ModuleAccount.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleAccount.Queries;
using MedWorking.Core.Application.ModuleLogin.Commands;
using MedWorking.Core.Application.ModuleLogin.Models;
using MedWorking.Core.Common.Constants;
using MedWorking.Core.Common.Enums;
using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = MedWorking.Core.Common.Static.ConfigurationManager;
using NotImplementedException = MedWorking.Core.Common.Exceptions.NotImplementedException;

namespace MedWorkingAPI.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator? _mediator;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _mediator = serviceProvider.GetService<IMediator>();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogIn([FromBody] LoginRequest request)
    {
        _logger.LogInformation("Call " + nameof(LogIn) + " API");
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new BadRequestException(result.Message!);
        }
        var tokenString = GetToken(result.Result!);
        return Ok(tokenString);
    }

    [HttpPost("update-account-info"), Authorize]
    public async Task<IActionResult> UpdateAccountInfoAsync([FromBody] UpdateAccountInfoCommand request)
    {
        _logger.LogInformation("Call " + nameof(UpdateAccountInfoAsync) + " API");
        var userName = User!.Identity!.Name;
        request.UserName = userName!;
        request.CreateUser = userName;
        request.UpdateUser = userName;
        request.CreateDate = DateTime.UtcNow;
        request.UpdateDate = DateTime.UtcNow;
        var result = await _mediator!.Send(request);
        if (!result.isSuccess)
        {
            throw new NotImplementedException(result.Message!);
        }
        return Ok(result);
            
    }

    [HttpPost("UploadAvatarImage")]
    [Authorize]
    public async Task<IActionResult> UploaAvatarImage(IFormFile image)
    {
        _logger.LogInformation("Call " + nameof(UploaAvatarImage) + " API");
        UpdateAccountInfoCommand request = new UpdateAccountInfoCommand();
        var userName = User!.Identity!.Name;
        request.UserName = userName!;
        request.CreateUser = userName;
        request.UpdateUser = userName;
        request.CreateDate = DateTime.UtcNow;
        request.UpdateDate = DateTime.UtcNow;
        long size = image.Length;
        if (size > FileType.Size)
        {
            throw new BadRequestException(ErrorMessage.Error_FileSize);
        }
        else if (size > 0 && size <= FileType.Size)
        {
            string date = DateTime.Now.ToString("ddMMyyyy");
            var directory = Path.Combine("AvatarImage", date);
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Image", directory);
            bool basePathExists = System.IO.Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            string savePath = Path.Combine(basePath, image.FileName);
            request.AvatarUrl = Path.Combine(directory, image.FileName);
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
                var result = await _mediator!.Send(request);
                return Ok(result);
            }
        }
        else
        {
            throw new BadRequestException(ErrorMessage.Error_FileInvalid);
        }
    }

    [HttpPost("UploadSignatureImage")]
    [Authorize]
    public async Task<IActionResult> UploadSignatureImage(IFormFile image)
    {
        _logger.LogInformation("Call " + nameof(UploadSignatureImage) + " API");
        UpdateAccountInfoCommand request = new UpdateAccountInfoCommand();
        _logger.LogInformation("Call Upload Signature Image");
        var userName = User!.Identity!.Name;
        request.UserName = userName!;
        request.CreateUser = userName;
        request.UpdateUser = userName;
        request.CreateDate = DateTime.UtcNow;
        request.UpdateDate = DateTime.UtcNow;

        long size = image.Length;
        if (size > FileType.Size)
        {
            throw new BadRequestException(ErrorMessage.Error_FileSize);
        }
        else if (size > 0 && size <= FileType.Size)
        {
            string date = DateTime.Now.ToString("ddMMyyyy");
            var directory = Path.Combine("SignatureImage", date);
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Image", directory);
            bool basePathExists = System.IO.Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            string savePath = Path.Combine(basePath, image.FileName);
            request.SignatureUrl = Path.Combine(directory, image.FileName);
            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
                var result = await _mediator!.Send(request);
                return Ok(result);
            }
        }
        else
        {
            throw new BadRequestException(ErrorMessage.Error_FileInvalid);
        }
    }

    [HttpGet("get-account-info"), Authorize]
    public async Task<IActionResult> GetAccountInfoAsync()
    {
        _logger.LogInformation("Call " + nameof(GetAccountInfoAsync) + " API");
        GetAccountInfoCommand request = new GetAccountInfoCommand();
        var userName = User!.Identity!.Name;
        request.UserName = userName!;
        var result = await _mediator!.Send(request);
        if (result == null)
        {
            throw new NotFoundException(ErrorMessage.Error_AccountNotFoundException);
        }
        return Ok(result);
    }


    private static string GetToken(AccountLoginModel user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting[LoginType.JWTSecret]));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: ConfigurationManager.AppSetting[LoginType.JWTValidIssuer],
            audience: ConfigurationManager.AppSetting[LoginType.JWTValidAudience],
            claims: claims,
            expires: DateTime.Now.AddDays(14),
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }
}
