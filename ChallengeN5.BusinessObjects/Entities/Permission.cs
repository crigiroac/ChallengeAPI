namespace ChallengeAPI.BusinessObjects.Entities
{
    public class Permission : EntityBase
    {
        public Guid EmployeeId { get; set; }
        public Guid PermissionTypeId { get; set; }
        public Employee Employee { get; set; }
        public bool Enable { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
