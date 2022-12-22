using MediatR;
using MedWorking.Core.Application.ModuleApprovation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWorking.Core.Application.ModuleApprovation.Commands
{
    public class ApprovationCommand : ApprovationModel, IRequest<ApprovationCommandResponse>
    {
    }
}
