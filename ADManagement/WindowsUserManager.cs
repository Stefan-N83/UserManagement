using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Principal;
using UserManagement.Interfaces;

namespace UserManagement.Infrastructure
{
    [SupportedOSPlatform("windows")]
    public class WindowsUserManager : IUserManager
    {
        public WindowsUserManager(WindowsIdentity? currentUser)
        {
            CurrentUser = currentUser;
        }

        public WindowsUserManager()
        {
        }

        public WindowsIdentity? CurrentUser { get; private set; } = WindowsIdentity.GetCurrent();

        /// <summary>
        /// Überprüfe, ob der aktuelle Benutzer Administratorrechte hat.
        /// </summary>
        /// <returns></returns>

        public bool IsAdmin()
        {
            return UserIsInGroup();
        }

        /// <summary>
        /// Überprüfe, ob der aktuelle Benutzer in einer bestimmten Gruppe ist.
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        [SupportedOSPlatform("windows")]
        public bool IsUserInGroup(string groupName)
        {
            return UserIsInGroup(groupName);

        }

        #region WindowsAPI

        [SupportedOSPlatform("windows")]
        static bool UserIsInGroup(string? groupName = null)
        {

            if (string.IsNullOrEmpty(groupName))
            {
                {
                    if (WindowsIdentity.GetCurrent() == null)
                    {
                        return false;
                    }
                    else
                    {
                        WindowsPrincipal? currentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                        if (currentPrincipal == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (currentPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (WindowsIdentity.GetCurrent() == null)
                {
                    return false;
                }
                else
                {
                    WindowsPrincipal? currentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                    if (currentPrincipal == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (currentPrincipal.IsInRole(groupName))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        #endregion // WindowsAPI
    }
}