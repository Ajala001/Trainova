namespace Trainova.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }


        protected void CreateDetails(string email, DateTime dateCreated)
        {
            CreatedBy = email;
            CreatedOn = dateCreated;
        }

        protected void ModifyDetails(string email, DateTime dateModified)
        {
            ModifiedBy = email;
            ModifiedOn = dateModified;
        }
    }
}
