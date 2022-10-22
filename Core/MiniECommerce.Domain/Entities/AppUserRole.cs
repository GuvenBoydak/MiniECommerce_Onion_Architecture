namespace MiniECommerce.Domain
{
    public class AppUserRole : BaseEntity
    {
        public Guid AppUserID { get; set; }

        public Guid RoleID { get; set; }

        //Relational Properties
        public virtual Role Role { get; set; }

        public virtual AppUser AppUser { get; set; }
    }

}
