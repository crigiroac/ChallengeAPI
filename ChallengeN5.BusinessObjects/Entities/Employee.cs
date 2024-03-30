namespace ChallengeAPI.BusinessObjects.Entities
{
    public class Employee : EntityBase
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }


    }
}
