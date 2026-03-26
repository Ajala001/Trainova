namespace Trainova.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }

        public void SetCreated(string email)
        {
            CreatedBy = email;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetModified(string email)
        {
            ModifiedBy = email;
            ModifiedOn = DateTime.UtcNow;
        }
    }
}