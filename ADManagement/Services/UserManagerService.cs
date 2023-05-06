using Microsoft.Extensions.DependencyInjection;
using UserManagement.Infrastructure;
using UserManagement.Interfaces;

namespace UserManagement.Services
{
    /// <summary>
    /// Service, der die Benutzerverwaltung bereitstellt.
    /// </summary>
    public class UserManagerService
    {
        private readonly IUserManager _userManager;

        public UserManagerService(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Füge den UserManagerService dem ServiceCollection hinzu.
        /// </summary>
        /// <param name="services"></param>
        public static void AddUserManagerService(IServiceCollection services)
        {
            services.AddSingleton<IUserManager, WindowsUserManager>();
            services.AddSingleton<UserManagerService>();
        }

        /// <summary>
        /// Überprüfe, ob der aktuelle Benutzer Administratorrechte hat.
        /// </summary>
        /// <returns></returns>
        public bool IsAdmin()
        {
            return _userManager.IsAdmin();
        }

        /// <summary>
        /// Überprüfe, ob der aktuelle Benutzer in einer bestimmten Gruppe ist.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public bool IsUserInGroup(string groupName)
        {
            return _userManager.IsUserInGroup(groupName);
        }
    }
}