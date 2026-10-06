namespace HospitalSystem.Domain
{
    public static class AppPermissions
    {
        public const string ClinicsView = "Clinics.View";
        public const string ClinicsManage = "Clinics.Manage";

        public const string DoctorsView = "Doctors.View";
        public const string DoctorsManage = "Doctors.Manage";
        public const string JobsManage = "Jobs.Manage";

        public const string PatientsView = "Patients.View";
        public const string PatientsCreate = "Patients.Create";
        public const string PatientsEdit = "Patients.Edit";
        public const string PatientsDelete = "Patients.Delete";

        public const string AppointmentsView = "Appointments.View";
        public const string AppointmentsViewOwn = "Appointments.ViewOwn";
        public const string AppointmentsCreate = "Appointments.Create";
        public const string AppointmentsEdit = "Appointments.Edit";
        public const string AppointmentsChangeStatus = "Appointments.ChangeStatus";
        public const string AppointmentsDelete = "Appointments.Delete";

        public const string MedicalRecordsView = "MedicalRecords.View";
        public const string MedicalRecordsCreate = "MedicalRecords.Create";
        public const string MedicalRecordsEdit = "MedicalRecords.Edit";
        public const string MedicalRecordsDelete = "MedicalRecords.Delete";

        public const string UsersManage = "Users.Manage";
        public const string RolesManage = "Roles.Manage";

        public static readonly IReadOnlyDictionary<string, string> DisplayNames = new Dictionary<string, string>
        {
            [ClinicsView] = "عرض العيادات",
            [ClinicsManage] = "إدارة العيادات (إضافة/تعديل/حذف)",
            [DoctorsView] = "عرض الأطباء",
            [DoctorsManage] = "إدارة الأطباء (إضافة/تعديل/حذف)",
            [JobsManage] = "إدارة المسميات الوظيفية",
            [PatientsView] = "عرض المرضى",
            [PatientsCreate] = "إضافة مريض",
            [PatientsEdit] = "تعديل مريض",
            [PatientsDelete] = "حذف مريض",
            [AppointmentsView] = "عرض كل المواعيد",
            [AppointmentsViewOwn] = "عرض مواعيد الطبيب نفسه فقط",
            [AppointmentsCreate] = "حجز موعد",
            [AppointmentsEdit] = "تعديل موعد",
            [AppointmentsChangeStatus] = "تغيير حالة الموعد (تأكيد/إكمال/إلغاء)",
            [AppointmentsDelete] = "حذف موعد",
            [MedicalRecordsView] = "عرض السجلات الطبية",
            [MedicalRecordsCreate] = "إضافة سجل طبي",
            [MedicalRecordsEdit] = "تعديل سجل طبي",
            [MedicalRecordsDelete] = "حذف سجل طبي",
            [UsersManage] = "إدارة المستخدمين",
            [RolesManage] = "إدارة الأدوار والصلاحيات",
        };

        public static IEnumerable<string> All => DisplayNames.Keys;

        public static string DisplayName(string? key) =>
            key != null && DisplayNames.TryGetValue(key, out var name) ? name : key ?? "";

        public static bool IsSystem(string? key) => key != null && DisplayNames.ContainsKey(key);

        // أسماء الأدوار الأساسية
        public const string AdminRole = "Admin";
        public const string DoctorRole = "Doctor";
        public const string ReceptionRole = "Reception";

        // الصلاحيات الافتراضية لأدوار الطبيب والاستقبال
        public static readonly IReadOnlyDictionary<string, string[]> DefaultRoles = new Dictionary<string, string[]>
        {
            [DoctorRole] = new[]
            {
                ClinicsView, DoctorsView, PatientsView,
                AppointmentsViewOwn, AppointmentsChangeStatus,
                MedicalRecordsView, MedicalRecordsCreate, MedicalRecordsEdit
            },
            [ReceptionRole] = new[]
            {
                ClinicsView, DoctorsView,
                PatientsView, PatientsCreate, PatientsEdit,
                AppointmentsView, AppointmentsCreate, AppointmentsEdit, AppointmentsChangeStatus
            },
        };
    }
}
