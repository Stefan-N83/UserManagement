namespace UserManagement.Interfaces
{
    public interface IUserManager
    {
        bool IsAdmin();
        bool IsUserInGroup(string groupName);
    }
}