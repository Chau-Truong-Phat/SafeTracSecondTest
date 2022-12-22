using AutoMapper;
using MedWorking.Core.Application.ApprovalGeneralDocumentProcess.Models;
using MedWorking.Core.Application.ModuleAccount.Models;
using MedWorking.Core.Application.ModuleApprovalGeneralDocProcess.Models;
using MedWorking.Core.Application.ModuleCategory.ModuleGroupDocument.Models;
using MedWorking.Core.Application.ModuleConfigBrowsingStep.Models;
using MedWorking.Core.Application.ModuleDecentralizeDocument.Models;
using MedWorking.Core.Application.ModuleDocument.Commands.ActionCommands;
using MedWorking.Core.Application.ModuleDocument.Models;
using MedWorking.Core.Application.ModuleGroupDocument.Models;
using MedWorking.Core.Application.ModuleLogin.Models;
using MedWorking.Core.Application.ModulePatternDocument.Models;
using MedWorking.Core.Application.ModuleRole.Models;
using MedWorking.Core.Application.ModulUserRole.Models;
using MedWorking.Core.EntityFramework.Models;

namespace MedWorking.Core.Startup.Configurations;

public  class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountLoginModel, Account>();
        CreateMap<Account, AccountLoginModel>();

        CreateMap<AccountDetail, Account>();
        CreateMap<Account, AccountDetail>();

        CreateMap<UserDetail, Account>();
        CreateMap<Account, UserDetail>();

        CreateMap<GroupDocumentModel, GroupDocument>();
        CreateMap<GroupDocument, GroupDocumentModel>();

        CreateMap<ConfigColumnModel, ConfigColumn>();
        CreateMap<ConfigColumn, ConfigColumnModel>();

        CreateMap<AccountInfoModel, Account>();
        CreateMap<Account, AccountInfoModel>();

        CreateMap<RoleModel, Role>();
        CreateMap<Role, RoleModel>();

        CreateMap<RoleModel, RoleDecentralize>();
        CreateMap<RoleDecentralize, RoleModel>();

        CreateMap<RoleDecentralizeModel, Decentralize>();
        CreateMap<Decentralize,RoleDecentralizeModel>();

        CreateMap<RoleDecentralizeModel, RoleDecentralize>();
        CreateMap<RoleDecentralize, RoleDecentralizeModel>();

        CreateMap<ViewDetailRole, Role>();
        CreateMap<Role, ViewDetailRole>();

        CreateMap<UserRole, UserRoleModel>();
        CreateMap<UserRoleModel, UserRole>();

        CreateMap<Office, DepartmentModel>();
        CreateMap<DepartmentModel, Office>();

        CreateMap<DepartmentChildModel, DepartmentModel>();
        CreateMap<DepartmentModel, DepartmentChildModel>();

        CreateMap<DepartmentChildModel, Office>();
        CreateMap<Office, DepartmentChildModel>();

        CreateMap<OfficeDetailModel, Office>();
        CreateMap<Office, OfficeDetailModel>();

        CreateMap<ViewAccountDetail, ViewAccountDetailModel>();
        CreateMap<ViewAccountDetailModel, ViewAccountDetail>();

        CreateMap<ListDecentralizeModel, Decentralize>();
        CreateMap<Decentralize, ListDecentralizeModel>();

        CreateMap<PatternDocumentModel, PatternDocument>();
        CreateMap<PatternDocument, PatternDocumentModel>();

        CreateMap<ViewSampleDocument, PatternDocumentDetailModel>();
        CreateMap<PatternDocumentDetailModel, ViewSampleDocument>();

        CreateMap<ViewDecentralizeDocument, DecentralizeDocument>();
        CreateMap<DecentralizeDocument, ViewDecentralizeDocument>();

        CreateMap<ConfigureBrowsingStep, ConfigBrowsingStepModel>();
        CreateMap<ConfigBrowsingStepModel, ConfigureBrowsingStep>();

        CreateMap<ViewConfigureBrowsingStep, ConfigBrowsingStepModel>();
        CreateMap<ConfigBrowsingStepModel, ViewConfigureBrowsingStep>();

        CreateMap<ImplementingAgency, OfficeImplement>();
        CreateMap<OfficeImplement, ImplementingAgency>();

        CreateMap<ViewApprovalGeneralDocumentProcessUnit, ApprovalGeneralDocumentProcessUnitModel>();
        CreateMap<ApprovalGeneralDocumentProcessUnitModel, ViewApprovalGeneralDocumentProcessUnit>();

        CreateMap<ApprovalGeneralDocumentProcessUnit, ApprovalGeneralDocumentProcessUnitModel>();
        CreateMap<ApprovalGeneralDocumentProcessUnitModel, ApprovalGeneralDocumentProcessUnit>();

        CreateMap<ViewApprovalGeneralDocumentProcess, ApprovalGeneralDocumentProcessModel>();

        CreateMap<DecentralizeDocument, DecentralizeDocumentModel>();
        CreateMap<DecentralizeDocumentModel, DecentralizeDocument>();

        CreateMap<DecentralizeDocUser, DecentralizeDocUserModel>();
        CreateMap<DecentralizeDocUserModel, DecentralizeDocUser>();

        CreateMap<DecentralizeDocument, DecentralizeDocUser>();
        CreateMap<DecentralizeDocUser, DecentralizeDocument>();

        CreateMap<DecentralizeDocumentDetailModel, DecentralizeDocument>();
        CreateMap<DecentralizeDocument, DecentralizeDocumentDetailModel>();

        CreateMap<DecentralizeDocUserModel, Account>();
        CreateMap<Account, DecentralizeDocUserModel>();

        CreateMap<UserDetailByOfficeIdModel, Office>();
        CreateMap<Office, UserDetailByOfficeIdModel>();

        CreateMap<UserDetailByOfficeIdModel, Account>();
        CreateMap<Account, UserDetailByOfficeIdModel>();

        CreateMap<DecentralizeDocumentDetailModel, DecentralizeDocUser>();
        CreateMap<DecentralizeDocUser, DecentralizeDocumentDetailModel>();

        CreateMap<DecentralizeDocument, DecentralizeDocumentModel>();
        CreateMap<DecentralizeDocumentModel, DecentralizeDocument>();

        CreateMap<DecentralizeDocUser, DecentralizeDocUserModel>();
        CreateMap<DecentralizeDocUserModel, DecentralizeDocUser>();

        CreateMap<DecentralizeDocument, DecentralizeDocUser>();
        CreateMap<DecentralizeDocUser, DecentralizeDocument>();

        CreateMap<DecentralizeDocumentDetailModel, DecentralizeDocument>();
        CreateMap<DecentralizeDocument, DecentralizeDocumentDetailModel>();

        CreateMap<DecentralizeDocUserModel, Account>();
        CreateMap<Account, DecentralizeDocUserModel>();

        CreateMap<DecentralizeDocumentDetailModel, DecentralizeDocUser>();
        CreateMap<DecentralizeDocUser, DecentralizeDocumentDetailModel>();

        CreateMap<ApprovalGeneralDocumentProcess, ApprovalGeneralDocumentProcessModel>();
        CreateMap<ApprovalGeneralDocumentProcessModel, ApprovalGeneralDocumentProcess>();

        CreateMap<DecentralizeDocument, DecentralizeDocumentModel>();
        CreateMap<DecentralizeDocumentModel, DecentralizeDocument>();

        CreateMap<DecentralizeDocUser, DecentralizeDocUserModel>();
        CreateMap<DecentralizeDocUserModel, DecentralizeDocUser>();

        CreateMap<DecentralizeDocument, DecentralizeDocUser>();
        CreateMap<DecentralizeDocUser, DecentralizeDocument>();

        CreateMap<DecentralizeDocumentDetailModel, DecentralizeDocument>();
        CreateMap<DecentralizeDocument, DecentralizeDocumentDetailModel>();

        CreateMap<DecentralizeDocUserModel, Account>();
        CreateMap<Account, DecentralizeDocUserModel>();

        CreateMap<DecentralizeDocumentDetailModel, DecentralizeDocUser>();
        CreateMap<DecentralizeDocUser, DecentralizeDocumentDetailModel>();

        CreateMap<ViewApprovalGeneralDocumentProcess, ApprovalGeneralDocumentProcessModel>();
        CreateMap<ApprovalGeneralDocumentProcessModel, ViewApprovalGeneralDocumentProcess>();

        CreateMap<ViewApprovalGeneralDocumentProcess, ApprovalGeneralDocumentProcess>();
        CreateMap<ApprovalGeneralDocumentProcess, ViewApprovalGeneralDocumentProcess>();

        CreateMap<ViewApprovalGeneralDocumentProcessUnit, ApprovalGeneralDocumentProcessUnit>();
        CreateMap<ApprovalGeneralDocumentProcessUnit, ViewApprovalGeneralDocumentProcessUnit>();

        CreateMap<EditDocumentRequestCommand, Document>();
        CreateMap<Document, EditDocumentRequestCommand>();

        CreateMap<DocumentModel, Document>();
        CreateMap<Document, DocumentModel>();

        CreateMap<AdvisoryStaffModel, AdvisoryOffice>();
        CreateMap<AdvisoryOffice, AdvisoryStaffModel>();
    }
}
