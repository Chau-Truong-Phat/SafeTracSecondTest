using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;
using MedWorking.Core.Common.Response;

namespace MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Commands;

public class ConfigColumnCommandReponse : BaseResponse
{
    public ConfigColumnCommandReponse()
        : base()
    {

    }

    public ConfigColumnModel? Result { get; set; } 
}
