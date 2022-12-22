using MediatR;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;

namespace MedWorking.Core.Application.ModuleConfigBrowsingStep.Queries;

public class GetListConfigBrowsingStepQuery : IRequest<List<ConfigBrowsingStepModel>> { }
