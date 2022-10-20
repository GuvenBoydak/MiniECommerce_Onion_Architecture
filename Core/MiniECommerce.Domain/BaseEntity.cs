namespace MiniECommerce.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            Status = DataStatus.Inserted;
            ID = new Guid();
        }

        public Guid ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DataStatus Status { get; set; }
    }
}
