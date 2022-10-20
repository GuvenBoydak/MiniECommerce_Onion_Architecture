namespace MiniECommerce.Domain
{
    public class AppUserRole : BaseEntity
    {
        public Guid AppUserID { get; set; }

        public Guid RoleID { get; set; }

        //Relational Properties
        public Role Role { get; set; }

        public AppUser AppUser { get; set; }
    }

}
