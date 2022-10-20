namespace MiniECommerce.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        //Relational Properties
        public List<AppUserRole> AppUserRoles { get; set; }
    }

}
