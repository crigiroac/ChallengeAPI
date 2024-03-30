namespace ChallengeAPI.BusinessObjects.Entities
{
    public class PermissionType : EntityBase
    {
        public string PermissionTypeName { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
