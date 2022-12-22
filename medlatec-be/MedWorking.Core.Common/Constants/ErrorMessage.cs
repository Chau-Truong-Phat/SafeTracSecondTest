using Microsoft.AspNetCore.Http;
using System.Diagnostics.Contracts;

namespace MedWorking.Core.Common.Constants;

public static class ErrorMessage
{
    public const string Edit_Success = "Cập nhật thành công.";
    public const string Add_Success = "Tạo mới thành công.";
    public const string Delete_Success = "Xóa thành công.";
    public const string ErrorAdd = "Có lỗi trong quá trình tạo!";
    public const string ErrorEdit = "Có lỗi trong quá trình sửa!";
    public const string Error_Delete = "Có lỗi trong quá trình xóa!";
    public const string Error = "Bản ghi không tông tại!";
    public const string Error_DeleteGroupDocument = "Không thể xóa nhóm văn bản đã được sử dụng để tạo mẫu văn bản. Vui lòng kiểm tra lại";
    public const string Error_AccountNotExist = "Mã nhân viên không đúng. Vui lòng kiểm tra lại";

    public const string Error_DeleteActive = "Bản ghi đang hoạt động, không được xóa!";
    public const string Eror_NotExistDelete = "Vai trò đang được phân quyền cho user không được xóa!";
    public const string Error_PatternDocExistCannotDelete = "Nhóm văn bản đang được sử dụng. Vui lòng kiểm tra lại!";
    public const string Eror_DeleteActive = "Mẫu văn bản đang được kích hoạt không thể xóa!";
    public const string Eror_DeleteDocumentActive = "Mẫu văn bản đang được sử dụng không thể xóa. Vui lòng kiểm tra lại!";
    public const string Eror_DeleteStepActive = "Các bước cấp duyệt đang được sử dụng không thể xóa. Vui lòng kiểm tra lại!";
    public const string Eror_DeleteDecentralizeDocActive = "Phân cấp văn bản đang được sử dụng không thể xóa. Vui lòng kiểm tra lại!";
    public const string Error_DeleteProcessUnitActive = "Không được xóa quy trình duyệt văn bản đang hoạt động. Vui lòng kiểm tra lại!";
    public const string Error_ApprovalGeneralDocProcessDelete = "Không được xóa quy trình duyệt văn bản đang hoạt động. Vui lòng kiểm tra lại.";

    public const string Error_DescriptionOverLength = "Diễn giải không được vượt quá 500 kí tự";
    public const string Error_LevelMustBiggerThanZero = "Cấp duyệt phải lớn hơn 0";
    public const string Error_DocumentDecentralizeLevelNotEmpty = "Cấp duyệt không được để trống";
    public const string Error_OfficeNotEmpty = "Đơn vị không được để trống";
    public const string Error_EmployeeNotEmpty = "Nhân viên không được để trống";
    public const string Error_DecentralizeDocumentOfficeExist = "Đơn vị đã được thiết lập cấp duyệt. Vui lòng kiếm tra lại!";
    public const string Error_LevelInvalid = "Các bước duyệt phải theo thứ tự 1 -> 2 -> ... -> n. Vui lòng kiểm tra lại!";
    public const string Error_AdvisorExist = "Đã có bước tham mưu được chọn. Vui lòng kiểm tra lại!";
    public const string Error_LevelMustBeOne = "Cấp duyệt phải bắt đầu từ 1";
    public const string Eror_Login = "Tài khoản hoặc mật khẩu không đúng";
    public const string Eror_LoginExits = "Tài khoản không tồn tại.";
    public const string GroupDocCode_Invalid = "Mã nhóm văn bản không được để trống";
    public const string GroupDocId_Invalid = "Nhóm văn bản không được để trống";
    public const string GroupDocName_Invalid = "Tên nhóm văn bản không được để trống";
    public const string EmployeeCode_Invalid = "Mã nhân viên không được để trống";
    public const string Role_Invalid = "Vai trò không được để trống";
    public const string RoleCode_Invalid = "Mã vai trò không được để trống";
    public const string RoleName_Invalid = "Tên vai trò không được để trống";
    public const string RoleCode_LengthInvalid = "Mã vai trò không được quá 10 kí tự";
    public const string IsDuplicate = "Mã nhóm văn bản đã được tạo!";
    public const string IsDuplicate_RoleCode = "Mã vai trò đã được tạo!";
    public const string IsDuplicate_RoleName = "Tên vai trò đã được tạo!";
    public const string GroupDocCode_Lenght = "Không nhập quá 10 ký tự";
    public const string Eror_UserRole = "Có lỗi trong quá trình phân quyền!";
    public const string Eror_Exist = "Nhân viên [họ và tên nhân viên] đã đươc phân vai trò!";
    public const string Eror_NotExist = "Nhân viên không tồn tại!";
    public const string Eror_Exist_PatternDocCode = "Mã mẫu văn bản đã tồn tại!";
    public const string Error_NotEmptyAdvisorUnitStep = "Các bước duyệt không được để trống";
    public const string Error_NotEmptyAdvisorUnitPattern = "Mẫu văn bản không được để trống";
    public const string Error_NotEmptyTimeApplication = "Thời gian áp dụng không được để trống";
    public const string Error_NotEmptyActiveState = "Kích hoạt không được để trống";
    public const string Error_TimeApplication = "Thời gian áp dụng không được để trống";
    public const string Error_DuplicateApprovalGeneralDoc = "[Tên nhóm văn bản/mẫu văn bản] đã được thiết lập quy trình duyệt trước đó, có hiệu lực từ ngày [thông tin ngày áp dụng]. Vui lòng kiểm tra lại!";
    
    public const string Error_FileSize = "Kích thước file vượt quá 256MB vui lòng upload lại!";
    public const string Error_FileInvalid = "File không hợp lệ vui lòng upload lại!";
    public const string Error_DataNotFoundException = "Data not found";
    public const string Error_AccountNotFoundException = "Không tìm thấy thông tin nhân viên trên HRM. Vui lòng kiểm tra lại!";
    public const string Error_NotEmptyAdvisorUser = "Người nhận không được bỏ trống";
}
