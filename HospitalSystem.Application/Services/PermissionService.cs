using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using HospitalSystem.Domain;
using HospitalSystem.Infrastructure.Repositories.Base;
using HospitalSystem.Application.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalSystem.Application.Services
{
    // صلاحيات المستخدم الحالي (تُقرأ من قاعدة البيانات مرة واحدة لكل طلب)
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _http;

        private HashSet<string>? _permissions;

        public PermissionService(IUnitOfWork unitOfWork, IHttpContextAccessor http)
        {
            _unitOfWork = unitOfWork;
            _http = http;
        }

        private int? CurrentUserId
        {
            get
            {
                var value = _http.HttpContext?.User.FindFirst(UserService.ClaimUserId)?.Value;
                return int.TryParse(value, out var id) ? id : null;
            }
        }

        public HashSet<string> GetPermissions()
        {
            if (_permissions == null)
            {
                var userId = CurrentUserId;
                _permissions = userId == null
                    ? new HashSet<string>()
                    : new HashSet<string>(_unitOfWork.PermissionRepo.GetUserPermissions(userId.Value));
            }
            return _permissions;
        }

        public bool Has(string permission)
        {
            return GetPermissions().Contains(permission);
        }

        // رقم الطبيب المرتبط بحساب المستخدم الحالي (إن وجد)
        public int? GetDoctorId()
        {
            var userId = CurrentUserId;
            return userId == null ? null : _unitOfWork.UserRepo.GetDoctorId(userId.Value);
        }
    }

    // يُكتب فوق الكنترولر أو الأكشن: [HasPermission(AppPermissions.PatientsDelete)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasPermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _permissions;

        public HasPermissionAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // غير مسجل دخول
            if (context.HttpContext.User.Identity?.IsAuthenticated != true)
            {
                context.Result = new ChallengeResult();
                return;
            }

            // يكفي أن يملك المستخدم واحدة من الصلاحيات المطلوبة
            var permissionService = context.HttpContext.RequestServices.GetRequiredService<IPermissionService>();
            if (!_permissions.Any(permissionService.Has))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
