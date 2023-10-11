namespace CarZone.Services
{
    public interface ISeedUserRoleInitial
    {
        //void SeedRoles();
        //void SeedUsers();

        void UpdateUserRole(string userEmail, string newRole);
    }
}
