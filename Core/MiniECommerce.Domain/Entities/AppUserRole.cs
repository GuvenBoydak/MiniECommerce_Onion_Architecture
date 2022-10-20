namespace MiniECommerce.Domain
{
    public class AppUserRole : BaseEntity
    {
        public int AppUserID { get; set; }

        public int RoleID { get; set; }

        //Relational Properties
        public Role Role { get; set; }

        public AppUser AppUser { get; set; }
    }

}
