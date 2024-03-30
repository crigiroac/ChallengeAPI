namespace ChallengeAPI.BusinessObjects.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }    
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
    }
}
