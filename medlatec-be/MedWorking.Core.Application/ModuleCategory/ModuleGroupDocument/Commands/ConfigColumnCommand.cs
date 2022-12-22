using MediatR;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;

namespace MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Commands;

public class ConfigColumnCommand : ConfigColumnModel, IRequest<ConfigColumnCommandReponse> { }
